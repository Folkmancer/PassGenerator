using System;

namespace Folkmancer.Simple.PassGenerator
{
    static class Generator
    {
        private static string digits = "0123456789";
        private static string letters = "abcdefghijklmnopqrstuvwxyz";
        private static string specialСhar = "!#$%&'()*+,-.:;<=>?@[]^_`{|}~";

        public static string Digits { get => digits; }
        public static string Letters { get => letters; }
        public static string SpecialСhar { get => specialСhar; }

        public static string GetLine(CharType typeSymbols = CharType.Digit, CharCase caseSymbols = CharCase.Lower)
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

        private static string GetLetter(CharCase caseLetter)
        {
            if (caseLetter == CharCase.Lower)
            {
                return Letters;
            }
            else if (caseLetter == CharCase.Upper)
            {
                return Letters.ToUpper();
            }
            else
            {
                return Letters + Letters.ToUpper();
            }
        }

        public static string GetPassword(int length, string passSimbols)
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
