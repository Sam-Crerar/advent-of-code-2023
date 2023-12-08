using System.Linq.Expressions;


int total = 0;
int counter = 1;
using (StreamReader reader = new StreamReader("input.txt"))
{
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        line = line.Split(':')[1];
        string[] hands = line.Split(';');
        int redLimit = 0;
        int greenLimit = 0;
        int blueLimit = 0;
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
                            redLimit = int.Parse(components[0]);
                        }
                        break;
                    case "green":
                        if (int.Parse(components[0]) > greenLimit)
                        {
                            greenLimit = int.Parse(components[0]);
                        }
                        break;
                    case "blue":
                        if (int.Parse(components[0]) > blueLimit)
                        {
                            blueLimit = int.Parse(components[0]);
                        }
                        break;
                    default:
                        Console.WriteLine("Oh no");
                        break;
                }
            }
        }

        total += (redLimit * greenLimit * blueLimit);
    }
}
Console.WriteLine(total);