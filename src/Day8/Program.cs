class Program
{
    static void Task1()
    {
        //Read file
        string[] lines = System.IO.File.ReadAllLines(("input.txt"));

        //Variables
        int pointer = 0;
        int accumulator = 0;
        List<int> visitedLines = new List<int>();

        //Run program
        while (true)
        {
            if (visitedLines.Contains(pointer)) break;
            visitedLines.Add(pointer);
            (pointer, accumulator) = ExecuteInstruction(lines[pointer], pointer, accumulator);
        }

        Console.WriteLine("Before the infinite loop accumulator had value " + accumulator);

    }

    static (int pointer, int acc) ExecuteInstruction(string instruction, int pointer, int accumulator)
    {
        string[] parts = instruction.Split(" ");
        if (parts[0] == "nop")
        {
            return (pointer + 1, accumulator);
        }
        else if (parts[0] == "acc")
        {
            try
            {
                int val = int.Parse(parts[1]);
                return (pointer + 1, accumulator + val);
            }
            catch (Exception)
            {
                Console.WriteLine("Could not parse " + parts[1]);
            }
        }
        else if (parts[0] == "jmp")
        {
            try
            {
                int val = int.Parse(parts[1]);
                return (pointer + val, accumulator);
            }
            catch (Exception)
            {
                Console.WriteLine("Could not parse " + parts[1]);
            }
        }
        else
        {
            Console.WriteLine("Unknown instruction: " + parts[0]);
        }
        return (pointer + 1, accumulator);
    }

    //We must fix the instruction before OR on line 535. Since we are always stuck in a loop there
    static void Task2()
    {
        //Read file
        string[] lines = System.IO.File.ReadAllLines(("input.txt"));

        bool programWork = false;
        int accumulator = 0;

        //Change NOP to JMP and run program
        //Then change back and test next instruction
        for (int i = 0; i < 536; i++)
        {
            if (lines[i].Substring(0, 3) == "nop")
            {
                lines[i] = lines[i].Replace("nop", "jmp");
                (programWork, accumulator) = ProgramIsWorking(lines);
                if (programWork)
                {
                    Console.WriteLine($"If you cange instruction on line {i} then the program will execute with a accumulator value of {accumulator}");
                    break;
                }
                else
                {
                    lines[i] = lines[i].Replace("jmp", "nop");
                }
            }
        }

        Console.WriteLine("End of NOP to JMP");

        //Change JMP to NOP and run program
        //Then change back and test next instruction
        for (int i = 0; i < 536; i++)
        {
            if (lines[i].Substring(0, 3) == "jmp")
            {
                lines[i] = lines[i].Replace("jmp", "nop");
                (programWork, accumulator) = ProgramIsWorking(lines);
                if (programWork)
                {
                    Console.WriteLine($"If you cange instruction on line {i} then the program will execute with a accumulator value of {accumulator}");
                    break;
                }
                else
                {
                    lines[i] = lines[i].Replace("nop", "jmp");
                }
            }
        }


        Console.WriteLine("End of JMP to NOP");

    }


    static (bool working, int accumulatorVal) ProgramIsWorking(string[] program)
    {
        //Variables
        int stopIndex = program.Length;
        int pointer = 0;
        int accumulator = 0;
        List<int> visitedLines = new List<int>();

        //Run program
        while (pointer != stopIndex)
        {
            if (visitedLines.Contains(pointer))
            {
                Console.WriteLine("The program is stuck in a loop");
                return (false, accumulator);
            }
            visitedLines.Add(pointer);
            (pointer, accumulator) = ExecuteInstruction(program[pointer], pointer, accumulator);
        }

        return (true, accumulator);
    }
    static void Main(string[] args)
    {
        Task2();
        //2093 to high
    }
}