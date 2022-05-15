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
                var letter = char.ToUpper(arrayStr[i]);
                if (CheckLetter(letter))
                {
                    arrayStr[i] = Decryption(letter);
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
                var letter = char.ToUpper(arrayStr[i]);
                if (CheckLetter(letter))
                {
                    arrayStr[i] = Encryption(letter);
                }
            }
            return new string(arrayStr);
        }

        private char Encryption(char letter)
        {
            if (letter + _stepCipher <= EndBigLetter)
            {
                return Convert.ToChar(letter + _stepCipher);
            }
            else
            {
                return Convert.ToChar(StartBigLetter - EndBigLetter + _stepCipher + letter - 1);
            }
        }

        private char Decryption(char letter)
        {
            if (letter - _stepCipher >= StartBigLetter)
            {
                return Convert.ToChar(letter - _stepCipher);
            }
            else
            {
                return Convert.ToChar(EndBigLetter + letter - StartBigLetter - _stepCipher + 1);
            }
        }

        private bool CheckLetter(char letter)
        {
            return letter >= StartBigLetter && letter <= EndBigLetter;
        }
    }
}
