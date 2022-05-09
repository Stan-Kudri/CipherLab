using System.Text;

namespace CipherLab
{
    public class MorseCodeCipher : ICipher
    {
        private const string EncryptionDelimiter = "$$$";

        private static readonly Dictionary<char, string> MorseEnCode = new Dictionary<char, string>()
        {
            {'А', "._"},
            {'Б', "_..."},
            {'В', ".__"},
            {'Г', "__."},
            {'Д', "_.."},
            {'Е', "."},
            {'Ж', "..._"},
            {'З', "__.."},
            {'И', ".."},
            {'Й', ".___"},
            {'К', "_._"},
            {'Л', "._.."},
            {'М', "__"},
            {'Н', "_."},
            {'О', "___"},
            {'П', ".__."},
            {'Р', "._."},
            {'С', "..."},
            {'Т', "_"},
            {'У', ".._"},
            {'Ф', ".._."},
            {'Х', "...."},
            {'Ц', "_._."},
            {'Ч', "___."},
            {'Ш', "____"},
            {'Щ', "__._"},
            {'Ъ', ".__._."},
            {'Ы', "_.__"},
            {'Ь', "_.._"},
            {'Э', ".._.."},
            {'Ю', "..__"},
            {'Я', "._._"},
        };

        private static readonly Dictionary<string, char> MorseDeCode = new Dictionary<string, char>()
        {
            {"._",'А'},
            {"_...",'Б'},
            {".__",'В'},
            {"__.",'Г'},
            {"_..",'Д'},
            {".",'Е'},
            {"..._",'Ж'},
            {"__..",'З'},
            {"..",'И'},
            {".___",'Й'},
            {"_._",'К'},
            {"._..",'Л'},
            {"__",'М'},
            {"_.",'Н'},
            {"___",'О'},
            {".__.",'П'},
            {"._.",'Р'},
            {"...",'С'},
            {"_",'Т'},
            {".._",'У'},
            {".._.",'Ф'},
            {"....",'Х'},
            {"_._.",'Ц'},
            {"___.",'Ч'},
            {"____",'Ш'},
            {"__._",'Щ'},
            {".__._.",'Ъ'},
            {"_.__",'Ы'},
            {"_.._",'Ь'},
            {".._..",'Э'},
            {"..__",'Ю'},
            {"._._",'Я'},
        };

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
                if (MorseDeCode.TryGetValue(element, out char letterCipher))
                {
                    cipherStr.Append(letterCipher);
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
                if (MorseEnCode.TryGetValue(letter, out var strCipher))
                {
                    arrayStr[index] = strCipher;
                }
                else
                {
                    arrayStr[index] = letter.ToString();
                }
                index++;
            }

            return string.Join(EncryptionDelimiter, arrayStr);
        }
    }
}
