using System;

Console.WriteLine("Введите текст:");
string text = Console.ReadLine() ?? "";

Console.WriteLine("Введите сдвиг:");
int k = int.Parse(Console.ReadLine() ?? "0");

string encrypted = Encrypt(text, k);
string decrypted = Decrypt(encrypted, k);

Console.WriteLine($"Зашифрованный текст: {encrypted}");
Console.WriteLine($"Расшифрованный текст: {decrypted}");

static string Encrypt(string text, int k)
{
    char[] chars = text.ToCharArray();

    k = ((k % 26) + 26) % 26;

    for (int i = 0; i < chars.Length; i++)
    {
        char c = chars[i];

        if (c >= 'a' && c <= 'z')
        {
            chars[i] = (char)('a' + (c - 'a' + k) % 26);
        }
        else if (c >= 'A' && c <= 'Z')
        {
            chars[i] = (char)('A' + (c - 'A' + k) % 26);
        }
    }

    return new string(chars);
}

static string Decrypt(string text, int k)
{
    return Encrypt(text, -k);
}