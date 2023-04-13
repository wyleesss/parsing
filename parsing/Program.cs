using System.Text;

internal static class Program
{
    static string FromFloatDecimalToBinary(float number)
    {
        char[] ForReverse;

        string StrNumber = number.ToString();

        string StrWholePart = String.Empty;
        string StrFractionPart = String.Empty;

        string Result = String.Empty;

        if (StrNumber.IndexOf(',') == -1)
            StrWholePart = StrNumber;
        
        else
        {
            StrWholePart = StrNumber.Substring(0, StrNumber.IndexOf(','));
            StrFractionPart = String.Concat("0,", StrNumber.Substring(StrNumber.IndexOf(',') + 1));
        }

        int WholePart = int.Parse(StrWholePart);
        float FractionPart = float.Parse(StrFractionPart);

        while (WholePart > 0) 
        {
            Result += (WholePart % 2).ToString();
            WholePart /= 2;
        }

        ForReverse = Result.ToCharArray();
        Array.Reverse(ForReverse);
        Result = new string(ForReverse) + ",";

        while (FractionPart != 0) 
        {
            FractionPart *= 2;

            if ((int)FractionPart == 1) 
            {
                Result += "1";
                FractionPart -= 1;
            }

            else
                Result += "0";
        }

        return Result;
    }

    static void Main()
    {
        Console.OutputEncoding= Encoding.UTF8;

        string input;
        float number;
        ConsoleKeyInfo keyInput = new ConsoleKeyInfo();

        do
        {
            Console.Clear();
            Console.Write("введіть число\n-> ");

            input = new string(Console.ReadLine());

            if (!float.TryParse(input, out number))
            {
                Console.WriteLine("\n(!) невірний формат числа");
                Console.Write("\n\n\nESC - вихід\n");
                keyInput = Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\nрезультат\n=> {FromFloatDecimalToBinary(number)}");
                Console.Write("\n\nESC - вихід");
                keyInput = Console.ReadKey();
            }
        } 
        while (keyInput.Key != ConsoleKey.Escape);
    }
}
