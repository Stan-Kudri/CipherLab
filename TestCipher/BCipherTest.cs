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
        public void Perform_encryption(string str, string expectStr)
        {
            var encryptionStr = new BCipher().Encode(str);
            Assert.Equal(expectStr, encryptionStr);
        }

        [Theory]
        [InlineData("ЯюэЬ ЫЫ", "АбвГ ДД")]
        [InlineData("Юях", "Бак")]
        [InlineData("ЯХХЯ", "АККА")]
        public void Performing_decryption(string str, string expectStr)
        {
            var decryptionStr = new BCipher().Decode(str);
            Assert.Equal(expectStr, decryptionStr);
        }

        [Theory]
        [InlineData("МалаКОЛД")]
        [InlineData("Юях")]
        [InlineData("ЯХХЯ")]
        public void Perform_encryption_with_decryption(string expectStr)
        {
            var encryptionStr = new BCipher().Decode(expectStr);
            var decryptionStr = new BCipher().Encode(encryptionStr);
            Assert.Equal(expectStr, decryptionStr);
        }
    }
}
