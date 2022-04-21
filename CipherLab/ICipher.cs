namespace CipherLab
{
    interface ICipher
    {
        public string Encoder(string encoderStr);

        public string Decoder(string decoderStr);
    }
}
