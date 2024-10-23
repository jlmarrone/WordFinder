namespace WordFinder;

public static class WordFinderExamples
{
    public static void WorkingExample()
    {
        try
        {
            var matrix = new List<string>
            {
                "chill",
                "coldw",
                "indoo",
                "windy",
                "dough"
            };

            var wordFinder = new WordFinder(matrix);
            var wordStream = new List<string> { "chill", "cold", "wind", "dough" };

            var foundWords = wordFinder.Find(wordStream);

            Console.WriteLine("Found Words:");
            foreach (var word in foundWords)
            {
                Console.WriteLine(word);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void NullMatrixExample()
    {
        try
        {
            var wordFinder = new WordFinder(null!);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // This will output an error message
        }    
    }
    
    public static void MatrixWithDifferentLengthsExample()
    {
        var matrixWithDifferentLengths = new List<string>
        {
            "chill",
            "cold",
            "windy",
            "dough",
            "extraLongString"
        };

        try
        {
            var wordFinder = new WordFinder(matrixWithDifferentLengths);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // This will output an error message
        }    
    }
}