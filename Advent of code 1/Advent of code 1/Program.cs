using System;

List<string> numbers = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

using (StreamReader reader = new StreamReader("input.txt"))
{
    int total = 0;
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        string number = "";
        number += lfind(line.ToLower());
        number += rfind(line.ToLower());
        total += Int32.Parse(number);
        Console.WriteLine($"{line} :: {number}");
    }
    Console.WriteLine(total);
}


char lfind(string line)
{
    int endIndex = int.MaxValue;
    char output = 'X';
    for (int i = 0; i < 9; i++) 
    {
        if (line.Contains(numbers[i]))
        {
            int newEndIndex = line.IndexOf(numbers[i]);
            if (newEndIndex < endIndex) 
            {
                endIndex = newEndIndex;
                output = char.Parse((i + 1).ToString());
            }
        }
    }
    for (int i = 0; i < endIndex; i++)
    {
        if (Char.IsDigit(line[i]))
        {
            return output = line[i];
        }
    }
    return output;
}

char rfind(string line)
{

    int startIndex = int.MinValue;
    char output = 'X';
    for (int i = 0; i < 9; i++)
    {
        if (line.Contains(numbers[i]))
        {
            string inputString = line;
            string searchString = numbers[i];
            int newStartIndex = line.Select((c, i) => inputString.Substring(i))
                                               .Select((substring, index) => new { substring, index })
                                               .Where(pair => pair.substring.StartsWith(searchString))
                                               .Select(pair => pair.index)
                                               .DefaultIfEmpty(-1)
                                               .Max();
            if (newStartIndex > startIndex)
            {
                startIndex = newStartIndex;
                output = char.Parse((i + 1).ToString());
            }
        }
    }
    for (int i = line.Length - 1; i >= startIndex; i--)
    {
        if (Char.IsDigit(line[i]))
        {
            return output = line[i];
        }
    }
    return output;
}
