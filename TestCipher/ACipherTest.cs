using CipherLab;
using Xunit;

namespace TestCipher
{
    public class ACipherTest
    {
        [Theory]
        [InlineData("јвЅг≈ƒжз»йкЋћ", "Ѕг¬д∆≈зи…клћЌ")]
        [InlineData("ћама", "Ќбнб")]
        [InlineData("ѕо ро-ро", "–п сп-сп")]
        public void Encode(string str, string expectStr)
        {
            var encryptionStr = new ACipher().Encode(str);
            Assert.Equal(expectStr, encryptionStr);
        }

        [Theory]
        [InlineData("Ѕг¬д∆≈зи…клћЌ", "јвЅг≈ƒжз»йкЋћ")]
        [InlineData("Ќбнб", "ћама")]
        [InlineData("–п сп-сп", "ѕо ро-ро")]
        public void Decode(string str, string expectStr)
        {
            var decryptionStr = new ACipher().Decode(str);
            Assert.Equal(expectStr, decryptionStr);
        }

        [Theory]
        [InlineData("ћала ќЋƒ")]
        [InlineData("ё€х")]
        [InlineData("я’’я")]
        public void Encode_Then_Decode(string expectStr)
        {
            var encryptionStr = new ACipher().Decode(expectStr);
            var decryptionStr = new ACipher().Encode(encryptionStr);
            Assert.Equal(expectStr, decryptionStr);
        }
    }
}