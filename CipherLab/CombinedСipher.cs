namespace CipherLab
{
    public class CombinedСipher : ICipher
    {
        private List<ICipher> cipherList;

        public CombinedСipher(IReadOnlyCollection<ICipher> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            cipherList = new List<ICipher>(list);
        }

        public string Decode(string decodeStr)
        {
            foreach (ICipher cipher in cipherList)
                decodeStr = cipher.Decode(decodeStr);

            return decodeStr;
        }

        public string Encode(string encodeStr)
        {
            foreach (ICipher cipher in cipherList)
                encodeStr = cipher.Encode(encodeStr);

            return encodeStr;
        }
    }
}
