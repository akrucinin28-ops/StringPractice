using System;
using System.Linq;

Console.WriteLine("Введите текст:");
string text = Console.ReadLine() ?? "";

char[] separators = { ' ', ',', '.', '!', '?', '\n', '\r', '\t', ';', ':' };

string[] words = text.Split(
    separators,
    StringSplitOptions.RemoveEmptyEntries
);

Console.WriteLine($"Символов с пробелами: {text.Length}");
Console.WriteLine($"Символов без пробелов: {text.Count(c => !char.IsWhiteSpace(c))}");
Console.WriteLine($"Количество слов: {words.Length}");

int sentences = text.Split(
    new char[] { '.', '!', '?' },
    StringSplitOptions.RemoveEmptyEntries
).Count(s => !string.IsNullOrWhiteSpace(s));

Console.WriteLine($"Количество предложений: {sentences}");

if (words.Length > 0)
{
    Console.WriteLine($"Самое длинное слово: {words.OrderByDescending(w => w.Length).First()}");
    Console.WriteLine($"Самое короткое слово: {words.OrderBy(w => w.Length).First()}");

    Console.WriteLine("Топ-5 частых слов:");

    var topWords = words
        .GroupBy(w => w.ToLower())
        .OrderByDescending(g => g.Count())
        .Take(5);

    foreach (var group in topWords)
    {
        Console.WriteLine($"{group.Key}: {group.Count()}");
    }
}