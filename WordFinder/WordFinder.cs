
// ReSharper disable PossibleMultipleEnumeration
namespace WordFinder;

public class WordFinder
{
    private readonly char[,] _matrix;
    private readonly int _rows;
    private readonly int _cols;

    public WordFinder(IEnumerable<string> matrix)
    {
        ValidateMatrix(matrix);

        var matrixList = matrix.ToList();
        _rows = matrixList.Count;
        _cols = matrixList.FirstOrDefault()?.Length ?? 0;

        _matrix = new char[_rows, _cols];

        for (var i = 0; i < _rows; i++)
        {
            for (var j = 0; j < _cols; j++)
            {
                _matrix[i, j] = matrixList[i][j];
            }
        }
    }

    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        if (wordStream == null)
        {
            throw new ArgumentException("Word stream cannot be null.");
        }
        
        var wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var word in wordStream.Distinct(StringComparer.OrdinalIgnoreCase))
        {
            if (!SearchWordInMatrix(word)) continue;

            wordCount[word] = wordStream.Count(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));
        }

        return wordCount.OrderByDescending(w => w.Value).Take(10).Select(w => w.Key);
    }

    private bool SearchWordInMatrix(string word)
    {
        // Check horizontally (left to right)
        for (int i = 0; i < _rows; i++)
        {
            var rowString = GetRowString(i);
            if (rowString.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        // Check vertically (top to bottom)
        for (var j = 0; j < _cols; j++)
        {
            var colString = GetColString(j);

            if (colString.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private string GetRowString(int row)
    {
        var rowChars = new char[_cols];
        for (var i = 0; i < _cols; i++)
        {
            rowChars[i] = _matrix[row, i];
        }
        return new string(rowChars);
    }

    private string GetColString(int col)
    {
        var colChars = new char[_rows];
        for (var i = 0; i < _rows; i++)
        {
            colChars[i] = _matrix[i, col];
        }
        return new string(colChars);
    }

    private static void ValidateMatrix(IEnumerable<string> matrix)
    {
        if (matrix == null || !matrix.Any())
        {
            throw new ArgumentException("Matrix cannot be null or empty.");
        }

        var length = matrix.First().Length;
        
        if (matrix.Any(str => str.Length != length))
        {
            throw new ArgumentException("All strings in the matrix must have the same length.");
        }
    }
}