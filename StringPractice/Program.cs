using System;
using System.Collections.Generic;
using System.Text;

Console.WriteLine("Введите CSV-строку:");
string line = Console.ReadLine() ?? "";

string[] fields = ParseCsv(line);

foreach (string field in fields)
{
    Console.WriteLine(field);
}

static string[] ParseCsv(string line)
{
    List<string> fields = new List<string>();
    StringBuilder field = new StringBuilder();
    bool inQuotes = false;

    for (int i = 0; i < line.Length; i++)
    {
        char c = line[i];

        if (c == '"')
        {
            if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
            {
                field.Append('"');
                i++;
            }
            else
            {
                inQuotes = !inQuotes;
            }
        }
        else if (c == ',' && !inQuotes)
        {
            fields.Add(field.ToString());
            field.Clear();
        }
        else
        {
            field.Append(c);
        }
    }

    fields.Add(field.ToString());

    return fields.ToArray();
}