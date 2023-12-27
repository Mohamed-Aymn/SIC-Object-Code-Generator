using Common.PassOne;

namespace Common.Utils;

public static class ReadWrite
{
    public static string ReadProgramCode()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Enter a multi-line string (Press Enter twice to finish):");
        Console.ResetColor();

        string input = "";
        string line;

        while ((line = Console.ReadLine()!) != "")
        {
            // Environment.NewLine == "\n"
            input += line + Environment.NewLine;
        }

        return input;
    }

    public static void FormattedTableWrite(PassOneTable passOneTable, LinkedList<string> objectCodeList)
    {
        // notes
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(new string('*', 47));
        Console.Write("- Every thing that you have imported in colored in ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Yellow");
        Console.Write("\n");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("- Every thing that the program created is colored in ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Cyan");
        Console.Write("\n");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(new string('*', 47));
        Console.Write("\n");
        Console.Write("\n");
        Console.WriteLine("Result:");

        // Table Header
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("{0,-20}", "Location Coutner");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("{0,-20} {1,-20} {2,-20}", "Label", "Instruction", "Reference");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("{0,-20}", "Object Code");
        Console.Write("\n");
        Console.ResetColor();
        Console.WriteLine(new string('-', 95));

        // Print table rows
        int currentRow = 0;
        bool isFirstRow = true;
        foreach (var row in passOneTable.Table)
        {
            // Location Counter
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0,-20}", row.LocationCounter);

            // Label, instruction and reference
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0,-20} {1,-20} {2,-20}", row.Label, row.Instruction, row.Reference);

            // Object Code
            if (isFirstRow)
            {
                Console.Write("\n");
                isFirstRow = false;
                continue;
            }
            string objectCode = "";
            try
            {
                objectCode = objectCodeList.ElementAt(currentRow);
            }
            catch
            {
                Console.Write("\n");
                Console.WriteLine(new string('-', 95));
                break;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0,-20}", objectCodeList.ElementAt(currentRow));

            Console.Write("\n");
            currentRow++;
        }
        Console.ResetColor();
        Console.Write("\n");
    }

    public static void FormattedHteWrite(string H, LinkedList<string> T, string E)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("HTE");
        Console.Write("\n");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(H);
        foreach (var line in T)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine(E);
        Console.ResetColor();
    }
}
