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

        public string Decoder(string decoderStr)
        {
            return Encoder(decoderStr);
        }

        public string Encoder(string encoderStr)
        {
            var arrayStr = encoderStr.ToCharArray();
            for (var i = 0; i < encoderStr.Length; i++)
            {
                if (arrayStr[i] >= 1040 && arrayStr[i] <= 1103)
                {
                    if (char.IsLower(encoderStr[i]))
                    {
                        arrayStr[i] = EncoderCharIsLetter(arrayStr[i], 1072, 1103);
                    }
                    else if (char.IsUpper(encoderStr[i]))
                    {
                        arrayStr[i] = EncoderCharIsLetter(arrayStr[i], 1040, 1071);
                    }
                }
            }
            return new string(arrayStr);
        }

        private char EncoderCharIsLetter(char letter, int a, int b)
        {
            if (letter == a)
                return Convert.ToChar(b);
            else if (letter == b)
                return Convert.ToChar(a);
            else
            {
                if (letter - a < 16)
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
