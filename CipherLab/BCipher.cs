namespace CipherLab
{
    /*
        Создать класс BCipher, реализующий интерфейс ICipher. Класс шифрует 
    строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на 
    букву того же регистра, расположенную в алфавите на i-й позиции с конца 
    алфавита. Например, буква В заменяется на букву Э.
     */
    public class BCipher : ICipher
    {
        private const int StartIndexBigLatter = 1040;
        private const int EndIndexBigLatter = 1071;

        private const int StartIndexSmallLatter = 1072;
        private const int EndIndexSmallLatter = 1103;

        public string Decode(string decodeStr)
        {
            return Encode(decodeStr);
        }

        public string Encode(string encodeStr)
        {
            CheckStrFormat(encodeStr);
            var arrayStr = encodeStr.ToCharArray();
            for (var i = 0; i < encodeStr.Length; i++)
            {
                if (arrayStr[i] >= StartIndexBigLatter && arrayStr[i] <= EndIndexSmallLatter)
                {
                    if (char.IsLower(encodeStr[i]))
                    {
                        arrayStr[i] = EncryptionLetter(arrayStr[i], StartIndexSmallLatter, EndIndexSmallLatter);
                    }
                    else if (char.IsUpper(encodeStr[i]))
                    {
                        arrayStr[i] = EncryptionLetter(arrayStr[i], StartIndexBigLatter, EndIndexBigLatter);
                    }
                }
            }
            return new string(arrayStr);
        }

        private char EncryptionLetter(char letter, int a, int b)
        {
            if (letter == a)
                return Convert.ToChar(b);
            else if (letter == b)
                return Convert.ToChar(a);
            else
            {
                var midSpacingLetters = (b - a) / 2;
                if (letter - a < midSpacingLetters)
                {
                    return Convert.ToChar(b - (letter - a));
                }
                else
                {
                    return Convert.ToChar(a + (b - letter));
                }
            }
        }
        private void CheckStrFormat(string str)
        {
            if (str == null)
                throw new NullReferenceException("Строка нулевая!");
            if (str.Length == 0)
                throw new ArgumentException("Строка не верна!");
        }
    }
}
