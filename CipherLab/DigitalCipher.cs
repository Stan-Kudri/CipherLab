using System.Text;

namespace CipherLab
{
    public class DigitalCipher : ICipher
    {
        private const string EncryptionDelimiter = "$$$";

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

            var cipherStr = new StringBuilder();

            var array = decodeStr.Split(EncryptionDelimiter);
            foreach (var element in array)
            {
                if (Int32.TryParse(element, out int value))
                {
                    if (value >= StartBigLetter && value <= EndSmallLetter)
                        cipherStr.Append(Convert.ToChar(Int32.Parse(element)));
                    else
                        cipherStr.Append(value);
                }
                else
                {
                    cipherStr.Append(element);
                }
            }

            return cipherStr.ToString();
        }

        public string Encode(string encodeStr)
        {
            if (encodeStr == null)
                throw new ArgumentNullException("Строка нулевая!");
            if (encodeStr.Length == 0)
                throw new ArgumentException("Строка не верна!");
            var arrayStr = new string[encodeStr.Length];
            var index = 0;
            foreach (var letter in encodeStr)
            {
                if (letter >= StartBigLetter && letter <= EndSmallLetter)
                {
                    arrayStr[index] = Convert.ToInt64(letter).ToString();
                }
                else
                {
                    arrayStr[index] = letter.ToString();
                }
                index++;
            }
            return string.Join(EncryptionDelimiter, arrayStr); ;
        }
    }
}
