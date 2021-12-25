class Program
{
    static void Task1()
    {
        string input = System.IO.File.ReadAllText("input.txt");
        string[] passports = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

        int validPassports = 0;
        //Check each passport
        foreach (string pass in passports)
        {
            string passCopy = pass.Replace("\n", " ");

            List<string> fields = new List<string>();

            foreach (string field in passCopy.Split(" "))
            {
                string keyWord = field.Split(":")[0];
                fields.Add(keyWord);
            }
            //Check all required fields
            if (fields.Contains("byr") && fields.Contains("iyr") && fields.Contains("eyr") && fields.Contains("hgt") && fields.Contains("hcl")
            && fields.Contains("ecl") && fields.Contains("pid"))
            {
                validPassports++;
            }
        }
        Console.WriteLine($"There are a total of {validPassports}!");
    }

    static void Task2()
    {
        string input = System.IO.File.ReadAllText("input.txt");
        string[] passports = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

        int validPassports = 0;

        //Check each passport
        foreach (string pass in passports)
        {
            string passCopy = pass.Replace("\n", " ").Replace("\r", "");
            int valid_required_fields = 0;
            List<(string, string)> fields = new List<(string, string)>();

            foreach (string field in passCopy.Split(" "))
            {
                string keyWord = field.Split(":")[0];
                string keyVal = field.Split(":")[1];
                fields.Add((keyWord, keyVal));
            }
            //Check all required fields
            foreach ((string word, string val) in fields)
            {
                if (FieldIsValid(word, val))
                {
                    valid_required_fields ++;
                }
            }
            Console.WriteLine(valid_required_fields);
            // Pass is valid
            if (valid_required_fields == 7) validPassports++;

        }
        //109 was the right answer
        Console.WriteLine($"There are a total of {validPassports} valid passports!");
    }

    static bool FieldIsValid(string word, string val)
    {
        switch (word)
        {
            case "byr":
                int byrVal = int.Parse(val);
                if (1919 < byrVal && byrVal < 2003) return true;
                return false;
            case "iyr":
                int iyrVal = int.Parse(val);
                if (2009 < iyrVal && iyrVal < 2021) return true;
                return false;
            case "eyr":
                int eyrVal = int.Parse(val);
                if (2019 < eyrVal && eyrVal < 2031) return true;
                return false;
            case "hgt":
                try
                {
                    int hgtVal = int.Parse(val.Substring(0, val.Length - 2));
                    string measure = val.Substring(val.Length - 2);
                    if (measure == "in")
                {
                    if (hgtVal > 58 && hgtVal < 77) return true;
                    return false;
                }
                else if (measure == "cm")
                {
                    if (hgtVal > 149 && hgtVal < 194) return true;
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid measurement");
                    return false;
                }
                }
                catch (Exception e)
                {
                    return false;
                }
            case "hcl":
                if (val.Length != 7) return false;
                if (val[0] != '#') return false;

                foreach (char c in val.Substring(1))
                {
                    if (Char.IsDigit(c) || c == 'a' || c == 'b' || c == 'c' || c == 'd' || c == 'e' || c == 'f') continue;
                    else return false;
                }
                return true;
            case "ecl":
                if (val == "amb" || val == "blu" || val == "brn" || val == "gry" || val == "grn" || val == "hzl" || val == "oth") return true;
                return false;
            case "pid":
                try
                {
                    int number = int.Parse(val);
                    if (val.Length == 9) return true;
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            case "cid":
                return false;
            default:
                return false;
        }
    }

    static void Main(string[] args)
    {
        Task2();
    }
}