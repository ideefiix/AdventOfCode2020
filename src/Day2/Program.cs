
class Program
{
    static void task1()
    {
        int validCount = 0;
        int invalidCount = 0;
        foreach (string line in System.IO.File.ReadLines("input.txt"))
        {
            string[] arr  = line.Split(' ');

            char letter = arr[1][0];
            int letterCount = 0;

            string[] rules = arr[0].Split('-');
            int min = int.Parse(rules[0]);
            int max = int.Parse(rules[1]);

            foreach (char c in arr[2]){
                if (c == letter){
                    letterCount++;
                }
            }

            if (letterCount < min || letterCount > max){
                invalidCount++;
            }else{
                validCount++;
            }

        }
        Console.WriteLine("Valid lines: " + validCount);
        Console.WriteLine("Invalid lines: " + invalidCount);
    }

    static void task2()
    {
        int validCount = 0;
        int invalidCount = 0;
        foreach (string line in System.IO.File.ReadLines("input.txt"))
        {
            string[] arr  = line.Split(' ');

            char letter = arr[1][0];

            string[] rules = arr[0].Split('-');
            int index1 = int.Parse(rules[0]);
            int index2 = int.Parse(rules[1]);

            // XOR: Exactly one
            if (arr[2][index1 - 1] == letter ^ arr[2][index2 - 1] == letter){
                validCount++;
            }else {
                invalidCount++;
            }

        }
        Console.WriteLine("Valid lines: " + validCount);
        Console.WriteLine("Invalid lines: " + invalidCount);
    }
    static void Main(string[] args)
    {
        task2();
    }
}
