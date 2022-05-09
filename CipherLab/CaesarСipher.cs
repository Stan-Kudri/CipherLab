namespace CipherLab
{
    public class CaesarСipher : ICipher
    {
        private const int StartBigLetter = 'А';
        private const int EndBigLetter = 'Я';

        private readonly int _stepCipher;

        public CaesarСipher(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("Больше нуля должен быть шаг шифровки!");

            _stepCipher = value % (EndBigLetter - StartBigLetter);
        }
        public string Decode(string decodeStr)
        {
            if (decodeStr == null)
                throw new ArgumentNullException("Строка нулевая!");
            if (decodeStr.Length == 0)
                throw new ArgumentException("Строка не верна!");
            var arrayStr = decodeStr.ToCharArray();
            for (var i = 0; i < decodeStr.Length; i++)
            {
                if (char.ToUpper(arrayStr[i]) >= StartBigLetter && char.ToUpper(arrayStr[i]) <= EndBigLetter)
                {
                    arrayStr[i] = DecryptionChar(char.ToUpper(arrayStr[i]));
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
                if (char.ToUpper(arrayStr[i]) >= StartBigLetter && char.ToUpper(arrayStr[i]) <= EndBigLetter)
                {
                    arrayStr[i] = EncryptionChar(char.ToUpper(arrayStr[i]));
                }
            }
            return new string(arrayStr);
        }

        private char EncryptionChar(char letter)
        {
            if (letter + _stepCipher <= EndBigLetter)
                return Convert.ToChar(letter + _stepCipher);
            else
                return Convert.ToChar(StartBigLetter - EndBigLetter + _stepCipher + letter - 1);
        }

        private char DecryptionChar(char letter)
        {
            if (letter - _stepCipher >= StartBigLetter)
                return Convert.ToChar(letter - _stepCipher);
            else
                return Convert.ToChar(EndBigLetter + letter - StartBigLetter - _stepCipher + 1);
        }
    }
}
