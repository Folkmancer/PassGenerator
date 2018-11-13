using System;

namespace Folkmancer.Simple.PassGenerator
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

        public string GetLine(CharType typeSymbols = CharType.Digit, CharCase caseSymbols = CharCase.Lower)
        {
            switch (typeSymbols)
            {
                case CharType.Digit:
                    return Digits;
                case CharType.Letter:
                    return GetLetter(caseSymbols);
                case CharType.Special:
                    return SpecialСhar;
                case CharType.DigitAndLetter:
                    return Digits + GetLetter(caseSymbols);
                case CharType.DigitAndSpecial:
                    return Digits + SpecialСhar;
                case CharType.LetterAndSpecial:
                    return GetLetter(caseSymbols) + SpecialСhar;
                case CharType.All:
                    return Digits + GetLetter(caseSymbols) + SpecialСhar;
                default: return default;
            }
        }

        private string GetLetter(CharCase caseLetter)
        {
            if (caseLetter == CharCase.Lower)
            {
                return Latin;
            }
            else if (caseLetter == CharCase.Upper)
            {
                return Latin.ToUpper();
            }
            else
            {
                return Latin + Latin.ToUpper();
            }
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
}
