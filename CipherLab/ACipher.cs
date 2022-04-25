namespace CipherLab
{
    /*
        Создать класс ACipher, реализующий интерфейс ICipher. Класс шифрует 
    строку посредством сдвига каждого символа на одну «алфавитную» позицию 
    выше. Например, в результате такого сдвига буква А становится буквой Б. 
     */
    public class ACipher : ICipher
    {
        private const int startIndexBigLatter = 1040;
        private const int endIndexBigLatter = 1071;

        private const int startIndexSmallLatter = 1072;
        private const int endIndexSmallLatter = 1103;

        public string Decode(string decodeStr)
        {
            var arrayStr = decodeStr.ToCharArray();
            for (var i = 0; i < decodeStr.Length; i++)
            {
                if (arrayStr[i] == startIndexBigLatter)
                {
                    arrayStr[i] = Convert.ToChar(endIndexBigLatter);
                }
                else if (arrayStr[i] == startIndexSmallLatter)
                {
                    arrayStr[i] = Convert.ToChar(endIndexSmallLatter);
                }
                else if (arrayStr[i] >= startIndexBigLatter && arrayStr[i] <= endIndexSmallLatter)
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
                if (arrayStr[i] == endIndexBigLatter)
                {
                    arrayStr[i] = Convert.ToChar(startIndexBigLatter);
                }
                else if (arrayStr[i] == endIndexSmallLatter)
                {
                    arrayStr[i] = Convert.ToChar(startIndexSmallLatter);
                }
                else if (arrayStr[i] >= startIndexBigLatter && arrayStr[i] <= endIndexSmallLatter)
                {
                    var number = arrayStr[i] + 1;
                    arrayStr[i] = Convert.ToChar(number);
                }
            }
            return new string(arrayStr);
        }
    }
}
