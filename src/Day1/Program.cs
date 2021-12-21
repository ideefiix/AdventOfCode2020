
List<int> integers = new List<int>();
int answer1 = 0;
// Read input
foreach (string line in System.IO.File.ReadLines("input.txt"))
{
    integers.Add(int.Parse(line));
}

foreach (int num in integers)
{
    foreach (int num2 in integers)
    {
        foreach (int num3 in integers)
        {
            if (num + num2 + num3 == 2020)
            {
                answer1 = num * num2 * num3;
            }
        }
    }
}

Console.WriteLine("Answer task 2: " + answer1);
