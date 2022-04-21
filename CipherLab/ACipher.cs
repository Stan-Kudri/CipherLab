namespace CipherLab
{
    /*
        Создать класс ACipher, реализующий интерфейс ICipher. Класс шифрует 
    строку посредством сдвига каждого символа на одну «алфавитную» позицию 
    выше. Например, в результате такого сдвига буква А становится буквой Б. 
     */
    public class ACipher : ICipher
    {
        public ACipher()
        {

        }

        public string Decode(string decodeStr)
        {
            var arrayStr = decodeStr.ToCharArray();
            for (var i = 0; i < decodeStr.Length; i++)
            {
                if (arrayStr[i] == 1040)
                {
                    arrayStr[i] = Convert.ToChar(1071);
                }
                else if (arrayStr[i] == 1072)
                {
                    arrayStr[i] = Convert.ToChar(1103);
                }
                else if (arrayStr[i] >= 1040 && arrayStr[i] <= 1103)
                {
                    var number = arrayStr[i] - 1;
                    arrayStr[i] = Convert.ToChar(number);
                }
            }
            return new string(arrayStr);
        }

        public string Encode(string encodeStr)
        {
            var arrayStr = encodeStr.ToCharArray();
            for (var i = 0; i < encodeStr.Length; i++)
            {
                if (arrayStr[i] == 1071)
                {
                    arrayStr[i] = Convert.ToChar(1040);
                }
                else if (arrayStr[i] == 1103)
                {
                    arrayStr[i] = Convert.ToChar(1072);
                }
                else if (arrayStr[i] >= 1040 && arrayStr[i] <= 1103)
                {
                    var number = arrayStr[i] + 1;
                    arrayStr[i] = Convert.ToChar(number);
                }
            }
            return new string(arrayStr);
        }
    }
}
