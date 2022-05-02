namespace CipherLab
{
    public class CombinedСipher : ICipher
    {
        public string Decode(string decodeStr)
        {
            var decoderLetterNextLetter = new NextLetterCipher();
            var str = decoderLetterNextLetter.Encode(decodeStr);

            var decoderReverseLetters = new LettersReverseCipher();

            return decoderReverseLetters.Encode(str);
        }

        public string Encode(string encodeStr)
        {
            var encoderReverseLetters = new LettersReverseCipher();
            var str = encoderReverseLetters.Encode(encodeStr);

            var encoderLetterNextLetter = new NextLetterCipher();

            return encoderLetterNextLetter.Encode(str);

        }
    }
}
