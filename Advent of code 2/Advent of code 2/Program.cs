using System.Linq.Expressions;

int redLimit = 12;
int greenLimit = 13;
int blueLimit = 14;

int total = 0;
int counter = 1;
using (StreamReader reader = new StreamReader("input.txt"))
{
    
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        line = line.Split(':')[1];
        string[] hands = line.Split(';');
        bool add = true;
        for (int i = 0; i < hands.Count(); i++)
        {
            string[] pulls = hands[i].Split(',');
            
            for (int j = 0; j < pulls.Count(); j++)
            {
                string[] components = pulls[j].Trim().Split(' ');

                switch (components[1])
                {
                    case "red":
                        if (int.Parse(components[0]) > redLimit)
                        {
                            add = false;
                        }
                        break;
                    case "green":
                        if (int.Parse(components[0]) > greenLimit)
                        {
                            add = false;
                        }
                        break;
                    case "blue":
                        if (int.Parse(components[0]) > blueLimit)
                        {
                            add = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Oh no");
                        break;
                }
            }
        }
        if (add)
        {
            total += counter;
        }
        counter++;
    }
}
Console.WriteLine(total);