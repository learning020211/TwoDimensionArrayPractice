namespace TwoDimensionArrayPractice.Tests;

public static class Extensions
{
    public static int[,] To2DIntArray(this string arrayItems)
    {
        var data = arrayItems.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray())
            .ToArray();

        var res = new int[data.Length, data.Max(line => line.Length)];
        for (var i = 0; i < data.Length; i++)
            for (var j = 0; j < data[i].Length; j++)
                res[i, j] = data[i][j];
        return res;
    }
}
