

using System.Text.RegularExpressions;

var lines = File.ReadAllLines("input.txt");

var leftList = new List<int>();
var rightList = new List<int>();
const string pattern = @"(\d+)\s+(\d+)";
foreach (var line in lines)
{
    var match = Regex.Match(line, pattern);
    leftList.Add(int.Parse(match.Groups[1].Value));
    rightList.Add(int.Parse(match.Groups[2].Value));
}

leftList = leftList.Order().ToList();
rightList = rightList.Order().ToList();

var distances = new List<int>();
for (var i = 0; i < lines.Length; ++i)
{
    distances.Add(Math.Abs(leftList[i] - rightList[i]));
}

Console.WriteLine($"Part 1: {distances.Sum()}");

var similarities = new List<int>();
for (var i = 0; i < leftList.Count; ++i)
{
    similarities.Add(leftList[i] * rightList.Count(x => x == leftList[i]));
}

Console.WriteLine($"Part 2: {similarities.Sum()}");