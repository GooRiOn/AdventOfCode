var textReports =  File.ReadAllText(@"input.txt");
var counter = 0;

textReports
    .Split(Environment.NewLine)
    .Where(t => t != string.Empty)
    .Select(t => Convert.ToInt32(t))
    .Aggregate((val1, val2) =>
    {
        if (val1 < val2)
        {
            counter++;
        }

        return val2;
    });

Console.WriteLine(counter);