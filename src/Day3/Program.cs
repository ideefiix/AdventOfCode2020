using System.Linq;
class Program
{
    static int task1(int rightSpeed, int downSpeed)
    {
        // Determine how many times we need to repeat the pattern
        string[] lines = System.IO.File.ReadAllLines("input.txt");
        int lineLength = lines[0].Length;

        int ticks_to_goal = (int)(Math.Ceiling((double)lines.Count() / downSpeed));
        int width = ticks_to_goal * rightSpeed;
        int repeat = (int)(Math.Ceiling((double)width / lineLength));

        // Repeat pattern
        for (int j = 0; j < lines.Count(); j++){
            lines[j] = string.Concat(Enumerable.Repeat(lines[j], repeat));
        }
        
        //Slide down the sloop
        int treesHit = 0;
        for (int i = 0; i < ticks_to_goal; i++)
        {
            char cHit = lines[i * downSpeed][i * rightSpeed];
            if (cHit == '#') treesHit++;  

        }
        return treesHit;
        //Console.WriteLine($"You hited {treesHit} trees;");
    }

    static int task2(int rightSpeed, int downSpeed)
    {
         // Determine how many times we need to repeat the pattern
        string[] lines = System.IO.File.ReadAllLines("input.txt");
        int numLines = lines.Count();
        int lineLength = lines[0].Length;
        int ticks_to_lastLine = (int)(Math.Ceiling((double)lines.Count() / downSpeed));
        int width = ticks_to_lastLine * rightSpeed;
        int repeat = (int)(Math.Ceiling((double)width / lineLength));

        // Repeat pattern
        for (int j = 0; j < numLines; j++){
            lines[j] = string.Concat(Enumerable.Repeat(lines[j], repeat));
        }
        
        int treesHit = 0;
        int currTick = 0;
        //Slide down slope
        while (currTick * downSpeed < numLines){
            char cHit = lines[currTick * downSpeed][currTick * rightSpeed];
            if (cHit == '#') treesHit++;  
            //Debugging code
            /* lines[currTick * downSpeed] = lines[currTick * downSpeed].Remove(currTick * rightSpeed, 1).Insert(currTick * rightSpeed, "X");
            Console.WriteLine(lines[currTick * downSpeed]); */
            currTick ++;
        }

        return treesHit;
    }

    static void Main(string[] args){
        //1119827008 to low
        /* int first = task2(1, 1); //90
        int second = task2(3, 1); //278
        int third = task2(5, 1); //88
        int fourth =  task2(7, 1); //98
        int fifth = task2(1, 2); //45
        int answer2 = first * second * third * fourth * fifth;
        Console.WriteLine(answer2); */
        int first = task2(1, 1); //90
        int second = task2(3, 1); //278
        int third = task2(5, 1); //88
        int fourth =  task2(7, 1); //98
        int fifth = task2(1, 2); //45
        Int64 answer2 = first;
        answer2 = answer2 * second;
        answer2 = answer2 * third;
        answer2 = answer2 * fourth;
        answer2 = answer2 * fifth;

        Console.WriteLine(answer2); 

    }
}
