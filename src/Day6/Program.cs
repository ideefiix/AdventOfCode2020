using System.Linq;
class program{
    static void Task1(){
        //Read file
        string[] groupAnswers = System.IO.File.ReadAllText("input.txt").Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

        //Place all input on same line
        for (int i = 0; i < groupAnswers.Length; i++)
        {
            groupAnswers[i] = groupAnswers[i].Replace("\r\n", "");
        }

        int yesAnswers = 0;
        // Count answers
        foreach (string answer in groupAnswers)
        {
            var unique = new HashSet<char>(answer);
            foreach (char c in unique){
                yesAnswers ++;
            }
        }

        Console.WriteLine("The amount of yes answers from all groups are " + yesAnswers);
    }
    static void Task2(){
        //Read file
        string[] groupAnswers = System.IO.File.ReadAllText("input.txt").Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

        //Find all common yes answers in all groups
        int yesAnswers = 0;
        foreach (string groupAnswer in groupAnswers)
        {
            string[] personAnswers = groupAnswer.Split("\r\n");
            IEnumerable<char> commonAnswers = from c in personAnswers[0] select c;
            //var commonAnswers = new HashSet<char>(personAnswers[0]);

            foreach(string answer in personAnswers)
            {
                var answerSet = new HashSet<char>(answer);
                commonAnswers = commonAnswers.Intersect(answerSet);
            }

            yesAnswers += commonAnswers.Count();
        }


        Console.WriteLine("The amount of common yes answers from all groups are " + yesAnswers);
    }

    static void Main(string[] args){
        Task2();
    }
}