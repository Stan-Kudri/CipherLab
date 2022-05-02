namespace CipherLab
{
    public class CombinedСipher : ICipher
    {
        private readonly ICipher _firstCipher;
        private readonly ICipher _secondCipher;

        public CombinedСipher(CombineEncryptors type)
        {
            switch (type)
            {
                case CombineEncryptors.ReverseAndNextLetter:
                    _firstCipher = new LettersReverseCipher();
                    _secondCipher = new NextLetterCipher();
                    break;
                case CombineEncryptors.NextLetterAndReverse:
                    _firstCipher = new NextLetterCipher();
                    _secondCipher = new LettersReverseCipher();
                    break;
            }
        }

        public string Decode(string decodeStr)
        {
            var str = _secondCipher.Encode(decodeStr);

            return _firstCipher.Encode(str);
        }

        public string Encode(string encodeStr)
        {
            var str = _firstCipher.Encode(encodeStr);

            return _secondCipher.Encode(str);
        }
    }
}
