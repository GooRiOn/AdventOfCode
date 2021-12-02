var report =  File.ReadAllText(@"input2.txt");
var instructions = report
    .Split(Environment.NewLine)
    .Where(i => i.Length > 0)
    .Select(i =>
    {
        var parts = i.Split(" ");
        return (Position: parts.First(), Value: Convert.ToInt64(parts.Last()));
    })
    .ToList();

var depth = 0L;
var horizontal = 0L;

foreach (var instruction in instructions)
{
    _ = instruction.Position switch
    {
        "forward" => horizontal += instruction.Value,
        "down" => depth += instruction.Value,
        "up" => depth -= instruction.Value,
        _ => throw new InvalidOperationException()
    };
}

Console.WriteLine(depth);
Console.WriteLine(horizontal);
Console.WriteLine(depth * horizontal);


//===========PART TWO======================


depth = 0;
horizontal = 0;
var aim = 0L;

foreach (var instruction in instructions)
{
    _ = instruction switch
    {
        {Position: "forward"} i=> OnForward(i.Value),
        {Position: "down"} i => aim += instruction.Value,
        {Position: "up"} i => aim -= instruction.Value,
        _ => throw new InvalidOperationException()
    };
}

long OnForward(long value)
{
    horizontal += value;
    depth += aim * value;
    return 0;
}

Console.WriteLine(depth);
Console.WriteLine(horizontal);
Console.WriteLine(depth * horizontal);
