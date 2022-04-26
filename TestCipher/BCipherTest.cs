using CipherLab;
using Xunit;

namespace TestCipher
{
    public class BCipherTest
    {
        [Theory]
        [InlineData("АбвГ ДД", "ЯюэЬ ЫЫ")]
        [InlineData("Бак", "Юях")]
        [InlineData("АЛЛА", "ЯФФЯ")]
        public void Encode(string str, string expectStr)
        {
            var encryptionStr = new BCipher().Encode(str);
            Assert.Equal(expectStr, encryptionStr);
        }

        [Theory]
        [InlineData("ЯюэЬ ЫЫ", "АбвГ ДД")]
        [InlineData("Юях", "Бак")]
        [InlineData("ЯХХЯ", "АККА")]
        public void Decode(string str, string expectStr)
        {
            var decryptionStr = new BCipher().Decode(str);
            Assert.Equal(expectStr, decryptionStr);
        }

        [Theory]
        [InlineData("МалаКОЛД")]
        [InlineData("Юях")]
        [InlineData("ЯХХЯ")]
        public void Encode_Then_Decode(string expectStr)
        {
            var encryptionStr = new BCipher().Decode(expectStr);
            var decryptionStr = new BCipher().Encode(encryptionStr);
            Assert.Equal(expectStr, decryptionStr);
        }
    }
}
