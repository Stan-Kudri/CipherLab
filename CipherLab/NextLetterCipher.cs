namespace CipherLab
{
    /*
        Создать класс ACipher, реализующий интерфейс ICipher. Класс шифрует 
    строку посредством сдвига каждого символа на одну «алфавитную» позицию 
    выше. Например, в результате такого сдвига буква А становится буквой Б. 
     */
    public class NextLetterCipher : ICipher
    {
        private const int StartBigLetter = 'А';
        private const int EndBigLetter = 'Я';

        private const int StartSmallLetter = 'а';
        private const int EndSmallLetter = 'я';

        public string Decode(string decodeStr)
        {
            if (decodeStr == null)
                throw new ArgumentNullException("Строка нулевая!");
            if (decodeStr.Length == 0)
                throw new ArgumentException("Строка не верна!");
            var arrayStr = decodeStr.ToCharArray();
            for (var i = 0; i < decodeStr.Length; i++)
            {
                if (arrayStr[i] == (char)StartBigLetter)
                {
                    arrayStr[i] = Convert.ToChar(EndBigLetter);
                }
                else if (arrayStr[i] == (char)StartSmallLetter)
                {
                    arrayStr[i] = Convert.ToChar(EndSmallLetter);
                }
                else if (arrayStr[i] >= StartBigLetter && arrayStr[i] <= EndSmallLetter)
                {
                    var number = arrayStr[i] - 1;
                    arrayStr[i] = Convert.ToChar(number);
                }
            }
            return new string(arrayStr);
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
                if (arrayStr[i] == (char)EndBigLetter)
                {
                    arrayStr[i] = Convert.ToChar(StartBigLetter);
                }
                else if (arrayStr[i] == (char)EndSmallLetter)
                {
                    arrayStr[i] = Convert.ToChar(StartSmallLetter);
                }
                else if (arrayStr[i] >= StartBigLetter && arrayStr[i] <= EndSmallLetter)
                {
                    var number = arrayStr[i] + 1;
                    arrayStr[i] = Convert.ToChar(number);
                }
            }
            return new string(arrayStr);
        }
    }
}
