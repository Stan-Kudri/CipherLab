namespace CipherLab
{
    /*
        Создать класс ACipher, реализующий интерфейс ICipher. Класс шифрует 
    строку посредством сдвига каждого символа на одну «алфавитную» позицию 
    выше. Например, в результате такого сдвига буква А становится буквой Б. 
     */
    public class ACipher : ICipher
    {
        private const int StartIndexBigLatter = 1040;
        private const int EndIndexBigLatter = 1071;

        private const int StartIndexSmallLatter = 1072;
        private const int EndIndexSmallLatter = 1103;

        public string Decode(string decodeStr)
        {
            var arrayStr = decodeStr.ToCharArray();
            for (var i = 0; i < decodeStr.Length; i++)
            {
                if (arrayStr[i] == StartIndexBigLatter)
                {
                    arrayStr[i] = Convert.ToChar(EndIndexBigLatter);
                }
                else if (arrayStr[i] == StartIndexSmallLatter)
                {
                    arrayStr[i] = Convert.ToChar(EndIndexSmallLatter);
                }
                else if (arrayStr[i] >= StartIndexBigLatter && arrayStr[i] <= EndIndexSmallLatter)
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
                if (arrayStr[i] == EndIndexBigLatter)
                {
                    arrayStr[i] = Convert.ToChar(StartIndexBigLatter);
                }
                else if (arrayStr[i] == EndIndexSmallLatter)
                {
                    arrayStr[i] = Convert.ToChar(StartIndexSmallLatter);
                }
                else if (arrayStr[i] >= StartIndexBigLatter && arrayStr[i] <= EndIndexSmallLatter)
                {
                    var number = arrayStr[i] + 1;
                    arrayStr[i] = Convert.ToChar(number);
                }
            }
            return new string(arrayStr);
        }
    }
}
