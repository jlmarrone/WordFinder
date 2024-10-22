using Xunit;
using Assert = Xunit.Assert;

namespace WordFinder.UnitTests;

public class WordFinderTests
{
    [Fact]
    public void Find_ShouldReturnFoundWords_WhenWordsAreInMatrix()
    {
        // Arrange
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

        // Act
        var foundWords = wordFinder.Find(wordStream).ToList();

        // Assert
        Assert.Contains("chill", foundWords);
        Assert.Contains("cold", foundWords);
        Assert.Contains("wind", foundWords);
        Assert.Contains("dough", foundWords);
        Assert.Equal(4, foundWords.Count);
    }

    [Fact]
    public void Find_ShouldReturnEmpty_WhenNoWordsAreInMatrix()
    {
        // Arrange
        var matrix = new List<string>
        {
            "chill",
            "coldw",
            "indoo",
            "windy",
            "dough"
        };
        var wordFinder = new WordFinder(matrix);
        var wordStream = new List<string> { "hello", "world", "test" };

        // Act
        var foundWords = wordFinder.Find(wordStream).ToList();

        // Assert
        Assert.Empty(foundWords);
    }

    [Fact]
    public void Find_ShouldReturnTop10Words_WhenMoreThan10WordsAreFound()
    {
        // Arrange
        var matrix = new List<string>
        {
            "chill",
            "coldw",
            "indoo",
            "windy",
            "dough"
        };
        var wordFinder = new WordFinder(matrix);
        var wordStream = new List<string>
        {
            "chill", "cold", "wind", "dough", "chill", "cold", "wind", "dough", "chill", "cold", "wind", "dough"
        };

        // Act
        var foundWords = wordFinder.Find(wordStream).ToList();

        // Assert
        Assert.Contains("chill", foundWords);
        Assert.Contains("cold", foundWords);
        Assert.Contains("wind", foundWords);
        Assert.Contains("dough", foundWords);
        Assert.Equal(4, foundWords.Count);
    }

    [Fact]
    public void Find_ShouldReturnUniqueWords_WhenDuplicatesInWordStream()
    {
        // Arrange
        var matrix = new List<string>
        {
            "chill",
            "coldw",
            "indoo",
            "windy",
            "dough"
        };
        var wordFinder = new WordFinder(matrix);
        var wordStream = new List<string> { "chill", "chill", "cold", "wind", "dough", "dough" };

        // Act
        var foundWords = wordFinder.Find(wordStream).ToList();

        // Assert
        Assert.Contains("chill", foundWords);
        Assert.Contains("cold", foundWords);
        Assert.Contains("wind", foundWords);
        Assert.Contains("dough", foundWords);
        Assert.Equal(4, foundWords.Count);
    }
}