using System.Linq;
class Program
{
    static void Task1()
    {
        string[] lines = System.IO.File.ReadAllLines("input.txt");
        List<(int row, int col)> seatList = new List<(int row, int col)>();

        foreach (string line in lines)
        {
            string strRow = line.Substring(0, 7);
            string strCol = line.Substring(7);

            int row = TranslateToInt(strRow);
            int col = TranslateToInt(strCol);
            seatList.Add((row, col));
        }

        int highestIdQuery =
        seatList.Select(seat => seat.row * 8 + seat.col).Max();

        Console.WriteLine("The highest seatID is " + highestIdQuery);

    }
    static void Task2()
    {
        string[] lines = System.IO.File.ReadAllLines("input.txt");
        List<(int row, int col)> seatList = new List<(int row, int col)>();

        foreach (string line in lines)
        {
            string strRow = line.Substring(0, 7);
            string strCol = line.Substring(7);

            int row = TranslateToInt(strRow);
            int col = TranslateToInt(strCol);
            seatList.Add((row, col));
        }

        IOrderedEnumerable<int> IdQuery =
        seatList.Select(seat => seat.row * 8 + seat.col).OrderBy(x => x);

        int prevId = 0; 
        foreach (int id in IdQuery){
            //Our seat is the gap 
            if (id - prevId == 2){
                Console.WriteLine("My seat has id " + (id - 1));
            }
            else{
                prevId = id;
            }
        }

    }

    static int TranslateToInt(string input)
    {
        //Reverse string order. Since String index start from left and binary num start from right
        char[] cArr = input.ToCharArray();
        Array.Reverse(cArr);
        string? reversedInput = new string(cArr);

        int num = 0;
        //Loop through string
        for (int i = 0; i < reversedInput.Length; i++)
        {
            //Check if bit is set
            if (reversedInput[i] == 'B' || reversedInput[i] == 'R')
            {
                num += (int)Math.Pow(2, i);
            }
        }
        return num;
    }

    static void Main(string[] args)
    {
        Task2();
    }
}