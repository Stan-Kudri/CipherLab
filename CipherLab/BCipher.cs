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
        public BCipher()
        {

        }

        public string Decode(string decodeStr)
        {
            return Encode(decodeStr);
        }

        public string Encode(string encodeStr)
        {
            var arrayStr = encodeStr.ToCharArray();
            for (var i = 0; i < encodeStr.Length; i++)
            {
                if (arrayStr[i] >= 1040 && arrayStr[i] <= 1103)
                {
                    if (char.IsLower(encodeStr[i]))
                    {
                        arrayStr[i] = CodingLetter(arrayStr[i], 1072, 1103);
                    }
                    else if (char.IsUpper(encodeStr[i]))
                    {
                        arrayStr[i] = CodingLetter(arrayStr[i], 1040, 1071);
                    }
                }
            }
            return new string(arrayStr);
        }

        private char CodingLetter(char letter, int a, int b)
        {
            if (letter == a)
                return Convert.ToChar(b);
            else if (letter == b)
                return Convert.ToChar(a);
            else
            {
                if (letter - a < (b - a) / 2)
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
