using CipherLab;
using System;
using Xunit;

namespace TestCipher
{
    public class LettersReverseCipherTest
    {
        [Theory]
        [InlineData("Мама+Папа", "Уяуя+Ряря")]
        [InlineData("Банка", "Юятхя")]
        [InlineData("Атака-кота", "Яняхя-хсня")]
        [InlineData("--==--:::::А", "--==--:::::Я")]
        public void Encode(string str, string expectStr)
        {
            var encryption = new LettersReverseCipher();

            var encryptionStr = encryption.Encode(str);

            Assert.Equal(expectStr, encryptionStr);
        }

        [Theory]
        [InlineData("Уяуя+Ряря", "Мама+Папа")]
        [InlineData("Юятхя", "Банка")]
        [InlineData("Яняхя-хсня", "Атака-кота")]
        [InlineData("--==--:::::А", "--==--:::::Я")]
        public void Decode(string str, string expectStr)
        {
            var decryption = new LettersReverseCipher();

            var decryptionStr = decryption.Decode(str);

            Assert.Equal(expectStr, decryptionStr);
        }

        [Theory]
        [InlineData("Малахит")]
        [InlineData("Кровля + Черепица = Крыша?")]
        [InlineData("Яхта, море и песок, то что нужно......")]
        [InlineData("--==--:::::Говорун_ГО-ГО")]
        public void Encode_Then_Decode(string expectStr)
        {
            var coder = new LettersReverseCipher();

            var encryptionStr = coder.Encode(expectStr);
            var decryptionStr = coder.Decode(encryptionStr);

            Assert.Equal(expectStr, decryptionStr);
        }

        [Theory]
        [InlineData(null)]
        public void Null_String_Coder(string nullStr)
        {
            var coder = new LettersReverseCipher();

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
