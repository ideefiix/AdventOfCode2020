
class Program
{
    static void Task1(){
        string input = System.IO.File.ReadAllText("input.txt");
        string[] passports = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

        int validPassports = 0;
        //Check each passport
        foreach (string pass in passports){
            string passCopy = pass.Replace("\n", " ");

            List<string> fields = new List<string>();

            foreach (string field in passCopy.Split(" ")){
                string keyWord = field.Split(":")[0];
                fields.Add(keyWord);
            }
            //Check all required fields
            if (fields.Contains("byr") && fields.Contains("iyr") && fields.Contains("eyr") && fields.Contains("hgt") && fields.Contains("hcl") 
            && fields.Contains("ecl") && fields.Contains("pid")){
                validPassports ++;
            }
        }
        Console.WriteLine($"There are a total of {validPassports}!");
    }

    static void Task2(){
        
    }

    static void Main(string[] args){
        Task1();
    }
}