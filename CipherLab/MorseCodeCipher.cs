using System.Text;

namespace CipherLab
{
    public class MorseCodeCipher : ICipher
    {
        private const int StartBigLetter = 'А';
        private const int EndBigLetter = 'Я';

        private static readonly Dictionary<char, string> MorseCode = new Dictionary<char, string>()
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

        public string Decode(string decodeStr)
        {
            if (decodeStr == null)
                throw new ArgumentNullException("Строка нулевая!");
            if (decodeStr.Length == 0)
                throw new ArgumentException("Строка не верна!");

            var cipherStr = new StringBuilder();

            var array = decodeStr.Split("$$$");
            foreach (var element in array)
            {
                if (MorseCode.ContainsValue(element))
                {
                    cipherStr.Append(MorseCode.FirstOrDefault(x => x.Value == element).Key);
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
                if (char.ToUpper(letter) >= StartBigLetter && char.ToUpper(letter) <= EndBigLetter)
                {
                    arrayStr[index] = MorseCode[letter];
                }
                else
                {
                    arrayStr[index] = letter.ToString();
                }
                index++;
            }

            return string.Join("$$$", arrayStr);
        }
    }
}
