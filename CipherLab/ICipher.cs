namespace CipherLab
{
    interface ICipher
    {
        public string Encode(string encodeStr);

        public string Decode(string decodeStr);
    }
}
