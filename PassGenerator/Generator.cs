using System;

namespace PassGenerator
{
    class Generator
    {
        private string digits = "0123456789";
        private string latin = "abcdefghijklmnopqrstuvwxyz";
        private string specialСhar = "!#$%&'()*+,-.:;<=>?@[]^_`{|}~";
        private string passSimbols;
        
        public Generator(int typeSelected, bool digitsOn, bool latinOn, bool specialCharOn)
        {
            if (digitsOn) passSimbols += Digits;
            if (latinOn)
            {
                if (typeSelected == 0) passSimbols += Latin;
                else if (typeSelected == 1) passSimbols += Latin.ToUpper();
                else passSimbols += passSimbols += Latin + Latin.ToUpper();
            }
            if (specialCharOn) passSimbols += SpecialСhar;
        }

        public string Digits { get => digits; }
        public string Latin { get => latin; }
        public string SpecialСhar { get => specialСhar; }

        public string GetPassword(int length)
        {
            if (passSimbols == null) return default;
            string password = null;
            Random index = new Random();
            for (int i = 0; i < length; i++)
            {
                password += passSimbols[index.Next(0, passSimbols.Length)];
            }
            return password; 
        }
    }

    enum Case { Upper, Lower }

    enum Type
    {
        Digit,
        Letter,
        Special,
        DigitAndLetter,
        DigitAndSpecial,
        LetterAndSpecial,
        All    
    }
}
