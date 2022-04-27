using CipherLab;
using System;
using Xunit;

namespace TestCipher
{
    public class ACipherTest
    {
        [Theory]
        [InlineData("����", "����")]
        [InlineData("����", "����")]
        [InlineData("��-��-��!", "��-��-��!")]
        [InlineData("����, ����� � ����...!!!", "����, ����� � ����...!!!")]
        [InlineData("--==--:::::�", "--==--:::::�")]
        public void Encode(string str, string expectStr)
        {
            var encryptionStr = new ACipher().Encode(str);
            Assert.Equal(expectStr, encryptionStr);
        }

        [Theory]
        [InlineData("����", "����")]
        [InlineData("����", "����")]
        [InlineData("��-��-��", "��-��-��")]
        [InlineData("����, ����� � ����...!!!", "����, ����� � ����...!!!")]
        [InlineData("--==--:::::�", "--==--:::::�")]
        public void Decode(string str, string expectStr)
        {
            var decryptionStr = new ACipher().Decode(str);
            Assert.Equal(expectStr, decryptionStr);
        }

        [Theory]
        [InlineData("�������")]
        [InlineData("������ + �������� = �����?")]
        [InlineData("����, ���� � �����, �� ��� ����� ��� ���.....")]
        [InlineData("--==--::::::���!")]
        public void Encode_Then_Decode(string expectStr)
        {
            var encryptionStr = new ACipher().Decode(expectStr);
            var decryptionStr = new ACipher().Encode(encryptionStr);
            Assert.Equal(expectStr, decryptionStr);
        }

        [Theory]
        [InlineData(null)]
        public void Null_String_Coder(string nullStr)
        {
            var coder = new ACipher();

            Assert.Throws<NullReferenceException>(() => coder.Encode(nullStr));
        }

        [Theory]
        [InlineData("")]
        public void Empty_String_Coder(string nullStr)
        {
            var coder = new ACipher();

            Assert.Throws<ArgumentException>(() => coder.Encode(nullStr));
        }
    }
}