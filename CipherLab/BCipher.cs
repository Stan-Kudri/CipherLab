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
        private const int StartBigLetter = 1040;
        private const int EndBigLetter = 1071;

        private const int StartSmallLetter = 1072;
        private const int EndSmallLetter = 1103;

        public string Decode(string decodeStr)
        {
            return Encode(decodeStr);
        }

        public string Encode(string encodeStr)
        {
            if (encodeStr == null)
                throw new ArgumentNullException("Строка нулевая!");
            if (encodeStr.Length == 0)
                throw new ArgumentException("Строка не верна!");
            var arrayStr = encodeStr.ToCharArray();
            for (var i = 0; i < encodeStr.Length; i++)
            {
                if (arrayStr[i] >= (int)StartBigLetter && arrayStr[i] <= (int)EndSmallLetter)
                {
                    if (char.IsLower(encodeStr[i]))
                    {
                        arrayStr[i] = EncryptionLetter(arrayStr[i], StartSmallLetter, EndSmallLetter);
                    }
                    else if (char.IsUpper(encodeStr[i]))
                    {
                        arrayStr[i] = EncryptionLetter(arrayStr[i], StartBigLetter, EndBigLetter);
                    }
                }
            }
            return new string(arrayStr);
        }

        private char EncryptionLetter(char letter, int a, int b)
        {
            if (letter == (char)a)
                return Convert.ToChar(b);
            else if (letter == (char)b)
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
    }
}
