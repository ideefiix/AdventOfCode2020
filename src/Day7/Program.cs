using System.Linq;
class Program
{
    static void Task1(){
        //Read file
        string[] rules = System.IO.File.ReadAllLines("input.txt");

        //The rules can be thought of as connections in a graph
        Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();

        //Add the connections
        foreach (string rule in rules)
        {
            string[] parts = rule.Split("contain"); 
            string parentBag = parts[0].TrimEnd();
            string[] childrenBags = parts[1].Replace(".", "").Split(',');
            
            List<string> childrenList = new List<string>();

            foreach (string bag in childrenBags)
            {
                if (bag == " no other bags") break;

                string bagName = bag.Substring(3);
                if (!bagName.EndsWith('s')) bagName = bagName + "s";
                childrenList.Add(bagName);
            }

            adjList.Add(parentBag, childrenList);
        }
        //Count bags with connection to shiny gold
        int bagCount = 0;
        foreach (var bag in adjList.Keys)
        {
            if (BagContainGold(adjList, bag)) bagCount ++;
        }
        Console.WriteLine($"There are {bagCount} bags that can hold the shiny gold bag");

        /* foreach (var kvp in adjList){
            Console.WriteLine(kvp.Key);
            foreach (var child in kvp.Value){
                Console.WriteLine("\t" + child);
            }
        } */


    }

    static bool BagContainGold(Dictionary<string, List<string>> dict, string parentBag){
        // Iterate through your children and their children and so on...
        foreach (string childBag in dict[parentBag])
        {
            if (childBag == "shiny gold bag" || childBag == "shiny gold bags") return true;
            if (BagContainGold(dict, childBag)) return true;
        }

        return false;

    }
    static void Task2(){
        //Read file
        string[] rules = System.IO.File.ReadAllLines("input.txt");

        //The rules can be thought of as connections in a graph
        Dictionary<string, List<(int, string)>> adjList = new Dictionary<string, List<(int, string)>>();

        //Add the connections
        foreach (string rule in rules)
        {
            string[] parts = rule.Split("contain"); 
            string parentBag = parts[0].TrimEnd();
            string[] childrenBags = parts[1].Replace(".", "").Split(',');
            
            List<(int, string)> childrenList = new List<(int, string)>();

            foreach (string bag in childrenBags)
            {
                if (bag == " no other bags") break;

                string bagName = bag.Substring(3);
                int num = int.Parse(bag.Substring(1,1));

                if (!bagName.EndsWith('s')) bagName = bagName + "s";
                childrenList.Add((num, bagName));
            }

            adjList.Add(parentBag, childrenList);
        }
        //Count bags in shiny gold 
        int bagCount = CountChildren(adjList, "shiny gold bags");
        Console.WriteLine($"There are {bagCount} bags in shiny gold bags!");
        
        /* foreach (var kvp in adjList){
            Console.WriteLine(kvp.Key);
            foreach (var child in kvp.Value){
                Console.WriteLine("\t" + child);
            }
        } */
    }

    static int CountChildren(Dictionary<string, List<(int, string)>> dict, string bag)
    {
        int bagCount = 0;
        //Add the children and grandchildren and so on..
        foreach (var child in dict[bag]){
            bagCount += child.Item1;
            bagCount += child.Item1 * CountChildren(dict, child.Item2);
        }
        return bagCount;
    }
    static void Main(string[] args){
        Task2();
    }
}