using WordFinder.Common.Constants;

namespace WordFinder;

internal static class Program
{
    static void Main(string[] args)
    {
        var exit = false;

        while (!exit)
        {
            ShowMenu();
            var choice = Console.ReadLine();
            exit = HandleUserChoice(choice!);
        }
    }

    private static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Option One: Working Example");
        Console.WriteLine("2. Option Two: Example with Null Matrix");
        Console.WriteLine("3. Option Three: Example with Matrix that has different lengths");
        Console.WriteLine("4. Exit");
        Console.Write("Please select an option: ");
    }

    static bool HandleUserChoice(string choice)
    {
        switch (choice)
        {
            case WordFinderConstants.MenuOptions.OptionOne:
                WordFinderExamples.WorkingExample();
                break;
            case WordFinderConstants.MenuOptions.OptionTwo:
                WordFinderExamples.NullMatrixExample();
                break;
            case WordFinderConstants.MenuOptions.OptionThree:
                WordFinderExamples.MatrixWithDifferentLengthsExample();
                break;
            case WordFinderConstants.MenuOptions.OptionExit:
                Console.WriteLine("Exiting the application...");
                return true;
            default:
                Console.WriteLine("Invalid option, please try again.");
                break;
        }
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
        return false;
    }
}