/*
 * Упражнение 10.1.Создать интерфейс ICipher, который определяет 
методы поддержки шифрования строк. В интерфейсе объявляются два метода 
encode() и decode(), которые используются для шифрования и дешифрования 
строк, соответственно. 

Создать класс ACipher, реализующий интерфейс ICipher. Класс шифрует 
строку посредством сдвига каждого символа на одну «алфавитную» позицию 
выше. Например, в результате такого сдвига буква А становится буквой Б. 

Создать класс BCipher, реализующий интерфейс ICipher. Класс шифрует 
строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на 
букву того же регистра, расположенную в алфавите на i-й позиции с конца 
алфавита. Например, буква В заменяется на букву Э.

Написать программу, демонстрирующую функционирование классов.
*/
using CipherLab;

string strBigLetters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
string strSlowLetters = "абвгдеёжзийклмнопрстуфхцчшщъыэюя";

foreach (char c in strBigLetters.ToArray())
{
    Console.WriteLine(c + " = " + (int)c);
}

foreach (char c in strSlowLetters.ToArray())
{
    Console.WriteLine(c + " = " + (int)c);
}

string str = "А Н Г У С Ю Я";
var aCipher = new NextLetterCipher();
Console.WriteLine(str);
var encoderStr = aCipher.Encode(str);
Console.WriteLine(encoderStr);
var decoderStr = aCipher.Decode(encoderStr);
Console.WriteLine(decoderStr);

Console.WriteLine();
var bCipher = new LettersReverseCipher();
var encoderStrB = bCipher.Encode(str);
Console.WriteLine(encoderStrB);
var decoderStrB = bCipher.Decode(encoderStrB);
Console.WriteLine(decoderStrB);

var cipherList = new CombinedСipher(new List<ICipher> { new LettersReverseCipher(), new LettersReverseCipher(), new NextLetterCipher() });
var strCipherEncode = cipherList.Encode(str);
Console.WriteLine(strCipherEncode);
var strCipherDecode = cipherList.Decode(strCipherEncode);
Console.WriteLine(strCipherDecode);
Console.WriteLine();

var morseCoder = new MorseCodeCipher();
var morseEncode = morseCoder.Encode(str);
Console.WriteLine(morseEncode);
var morseDecode = morseCoder.Decode(morseEncode);
Console.WriteLine(morseDecode);

Console.WriteLine();
var caesarCoder = new CaesarСipher(1);
var caesarEncode = caesarCoder.Encode(str);
Console.WriteLine(caesarEncode);
var caesarDecode = caesarCoder.Decode(caesarEncode);
Console.WriteLine(caesarDecode);

Console.WriteLine();
var digitalCoder = new DigitalCipher();
var digitalEncode = digitalCoder.Encode(str);
Console.WriteLine(digitalEncode);
var digitalDecode = digitalCoder.Decode(digitalEncode);
Console.WriteLine(digitalDecode);


