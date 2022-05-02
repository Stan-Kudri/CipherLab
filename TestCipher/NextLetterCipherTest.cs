using CipherLab;
using System;
using Xunit;

namespace TestCipher
{
    public class NextLetterCipherTest
    {
        [Theory]
        [InlineData("Крот", "Лспу")]
        [InlineData("Мама", "Нбнб")]
        [InlineData("По-ро-ро!", "Рп-сп-сп!")]
        [InlineData("Буря, дождь и мгла...!!!", "Вфса, епзеэ й ндмб...!!!")]
        [InlineData("--==--:::::А", "--==--:::::Б")]
        public void Encode(string str, string expectStr)
        {
            var encryptionStr = new NextLetterCipher().Encode(str);
            Assert.Equal(expectStr, encryptionStr);
        }

        [Theory]
        [InlineData("Лспу", "Крот")]
        [InlineData("Нбнб", "Мама")]
        [InlineData("Рп-сп-сп", "По-ро-ро")]
        [InlineData("Вфса, епзеэ й ндмб...!!!", "Буря, дождь и мгла...!!!")]
        [InlineData("--==--:::::Б", "--==--:::::А")]
        public void Decode(string str, string expectStr)
        {
            var decryptionStr = new NextLetterCipher().Decode(str);
            Assert.Equal(expectStr, decryptionStr);
        }

        [Theory]
        [InlineData("Малахит")]
        [InlineData("Кровля + Черепица = Крыша?")]
        [InlineData("Яхта, море и песок, то что нужно мне тут.....")]
        [InlineData("--==--::::::Кол!")]
        public void Encode_Then_Decode(string expectStr)
        {
            var encryptionStr = new NextLetterCipher().Decode(expectStr);
            var decryptionStr = new NextLetterCipher().Encode(encryptionStr);
            Assert.Equal(expectStr, decryptionStr);
        }

        [Theory]
        [InlineData(null)]
        public void Null_String_Coder(string nullStr)
        {
            var coder = new NextLetterCipher();

            Assert.Throws<ArgumentNullException>(() => coder.Encode(nullStr));
        }

        [Theory]
        [InlineData("")]
        public void Empty_String_Coder(string nullStr)
        {
            var coder = new NextLetterCipher();

            Assert.Throws<ArgumentException>(() => coder.Encode(nullStr));
        }
    }
}