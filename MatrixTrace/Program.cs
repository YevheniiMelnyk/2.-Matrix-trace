using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        int _columns;
        int _rows;

        _rows = GetNumber("rows");

        _columns = GetNumber("columns");

        Matrix matrix = new(_rows, _columns);
        matrix.PrintMatrix();
        matrix.PrintSumOfMatrixTrace();
        Console.WriteLine();

        while (true)
        {        
            Console.WriteLine("Enter 1 if you want to print matrix again\nEnter 2 to print matrix trace\nEnter 3 to build a new matrix\nPress 'Esc' to stop the program:");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                break; 
            }
            else if (keyInfo.KeyChar == '1')
            {
                matrix.PrintMatrix();
                matrix.PrintSumOfMatrixTrace();
                Console.WriteLine();
            }
            else if (keyInfo.KeyChar == '2')
            {
                matrix.PrintMatrixTrace();
                Console.WriteLine();
            }
            else if (keyInfo.KeyChar == '3')
            {
                Console.WriteLine();

                _rows = GetNumber("rows");

                _columns = GetNumber("columns");

                matrix = new(_rows, _columns);
                matrix.PrintMatrix();
                matrix.PrintSumOfMatrixTrace();
                Console.WriteLine();
                continue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please try again.");
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }

    private static int GetNumber(string msg)
    {
        int output;
        Console.Write($"Enter number of {msg}: ");
        string rowsStr = Console.ReadLine();

        bool res = int.TryParse(rowsStr, out output);
        while (!res || output <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Invalid input, please enter correct number of {msg}: ");
            Console.ResetColor();
            rowsStr = Console.ReadLine();
            res = int.TryParse(rowsStr, out output);
        }
        return output;
    }
}