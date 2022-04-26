using CipherLab;
using Xunit;

namespace TestCipher
{
    public class ACipherTest
    {
        [Theory]
        [InlineData("�������������", "�������������")]
        [InlineData("����", "����")]
        [InlineData("�� ��-��", "�� ��-��")]
        public void Encode(string str, string expectStr)
        {
            var encryptionStr = new ACipher().Encode(str);
            Assert.Equal(expectStr, encryptionStr);
        }

        [Theory]
        [InlineData("�������������", "�������������")]
        [InlineData("����", "����")]
        [InlineData("�� ��-��", "�� ��-��")]
        public void Decode(string str, string expectStr)
        {
            var decryptionStr = new ACipher().Decode(str);
            Assert.Equal(expectStr, decryptionStr);
        }

        [Theory]
        [InlineData("��������")]
        [InlineData("���")]
        [InlineData("����")]
        public void Encode_Then_Decode(string expectStr)
        {
            var encryptionStr = new ACipher().Decode(expectStr);
            var decryptionStr = new ACipher().Encode(encryptionStr);
            Assert.Equal(expectStr, decryptionStr);
        }
    }
}