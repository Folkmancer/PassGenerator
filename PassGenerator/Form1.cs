using System;
using System.Windows.Forms;

namespace Folkmancer.Simple.PassGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") this.toolStripStatusLabel1.Text = "Неверная длина пароля!";
            else if (!(checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)) this.toolStripStatusLabel1.Text = "Не выбран тип!";
            else
            {
                CharCase caseType = GetCharCase();
                CharType typeType = GetCharType();
                textBox2.Text = Generator.GetPassword(int.Parse(textBox1.Text), Generator.GetLine(typeType, caseType));
                if (textBox2.Text != "") this.toolStripStatusLabel1.Text = "Пароль сгенерирован!";
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") this.toolStripStatusLabel1.Text = "Пароль не сгенерирован!";
            else
            {
                saveFileDialog1.Filter = "Text file|*.txt";
                saveFileDialog1.Title = "Сохранить пароль";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
                    this.toolStripStatusLabel1.Text = "Пароль сохранён в файл!";
                }
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") this.toolStripStatusLabel1.Text = "Пароль не сгенерирован!";
            else
            {
                Clipboard.SetText(textBox2.Text);
                this.toolStripStatusLabel1.Text = "Пароль скопирован в буфер!";
            }               
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) > 256) textBox1.Text = "256";
        }

        private CharType GetCharType()
        {
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked) return CharType.All;
            else if (checkBox2.Checked && checkBox3.Checked) return CharType.LetterAndSpecial;
            else if (checkBox1.Checked && checkBox3.Checked) return CharType.DigitAndSpecial;
            else if (checkBox1.Checked && checkBox2.Checked) return CharType.DigitAndLetter;
            else if (checkBox3.Checked) return CharType.Special;
            else if (checkBox2.Checked) return CharType.Letter;
            else return CharType.Digit;
        }

        private CharCase GetCharCase()
        {
            if (radioButton1.Checked) return CharCase.Lower;
            else if (radioButton2.Checked) return CharCase.Upper;
            else return CharCase.Both;
        }    
    }
}
