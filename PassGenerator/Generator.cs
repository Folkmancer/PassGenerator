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
            if (digitsOn) passSimbols += digits;
            if (latinOn)
            {
                if (typeSelected == 0) passSimbols += latin;
                else if (typeSelected == 1) passSimbols += latin.ToUpper();
                else passSimbols += passSimbols += latin + latin.ToUpper();
            }
            if (specialCharOn) passSimbols += specialСhar;
        }

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
}
