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


//========= PART 2 ===========

var counterGroup = 0;

var numbers = textReports
    .Split(Environment.NewLine)
    .Where(t => t != string.Empty)
    .Select(t => Convert.ToInt32(t))
    .ToList();

for (var i = 0; i < numbers.Count - 3; i++)
{
    var sumLeft = numbers[i] + numbers[i+1] + numbers[i+2];
    var sumRight = numbers[i+1] + numbers[i+2] + numbers[i+3];

    if (sumLeft < sumRight)
    {
        counterGroup++;
    }
}

Console.WriteLine(counterGroup);