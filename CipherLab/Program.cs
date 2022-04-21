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
var aCipher = new ACipher();
Console.WriteLine(str);
var encoderStr = aCipher.Encoder(str);
Console.WriteLine(encoderStr);
var decoderStr = aCipher.Decoder(encoderStr);
Console.WriteLine(decoderStr);

Console.WriteLine();
var bCipher = new BCipher();
var encoderStrB = bCipher.Encoder(str);
Console.WriteLine(encoderStrB);
var decoderStrB = bCipher.Decoder(encoderStrB);
Console.WriteLine(decoderStrB);
