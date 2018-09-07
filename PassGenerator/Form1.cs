using System;
using System.Windows.Forms;

namespace PassGenerator
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
                int type =
                    radioButton1.Checked == true ? 0 :
                    radioButton2.Checked == true ? 1 : 2;
                textBox2.Text = new Generator(
                    type,
                    checkBox1.Checked,
                    checkBox2.Checked,
                    checkBox3.Checked
                    ).GetPassword(int.Parse(textBox1.Text));
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
    }
}
