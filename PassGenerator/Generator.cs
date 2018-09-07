using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string GetPass(int length)
        {
            string password = null;
            if (passSimbols == null) return "";
            else
            {
                
                Random index = new Random();
                for (int i = 0; i < length; i++)
                {
                    password += passSimbols[index.Next(0, passSimbols.Length)];
                }
            }
            return password;
        }
    }
}
