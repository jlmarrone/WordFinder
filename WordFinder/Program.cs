Console.WriteLine("Word Finder Example");

var matrix = new List<string>
{
    "abcdc",
    "fgwio",
    "chill",
    "pqnsd",
    "uvdxy"
};

var wordFinder = new WordFinder.WordFinder(matrix);

var wordStream = new List<string>
{
    "chill",
    "cold",
    "wind",
    "snow"
};

var foundWords = wordFinder.Find(wordStream).ToList();

foundWords.ForEach(Console.WriteLine);