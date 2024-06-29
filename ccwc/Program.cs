// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

var argsLength = args.Length;

var commandRegex = new Regex(@"^-(?<cmd>[clmw]{1})$");
var filenameRegex = new Regex(@"\w.\w{3}");

var argumentsDescription = @"CCWC command accepts atleast one argument from below. 
    1. -c -> Byte count
        -l -> Line count
        -w -> Word count 
        -m -> Character count 
    2. filename or path";

Command command;
string? filename = null;

if(argsLength == 1)
{
    Match m = commandRegex.Match(args[0]);
    if(m.Success)
        Enum.TryParse(m.Result("${cmd}"), out command);
    else if(filenameRegex.IsMatch(args[0]))
        filename = args[0];
    else
        throw new ArgumentException($"Arguments are invalid. \n {argumentsDescription}");
}
else if (argsLength == 2)
{
    Match m = commandRegex.Match(args[0]);
    if (m.Success && filenameRegex.IsMatch(args[1]))
    {
        Enum.TryParse(m.Result("${cmd}"), out command);
        filename = args[1];
    }
    else
        throw new ArgumentException($"Arguments are invalid. \n {argumentsDescription}");
}
else
{
    throw new ArgumentException($"Wrong no of arguments passed. \n {argumentsDescription}");
}


enum Command
{
    ByteCount = 'c',
    LineCount = 'l',
    WordCount = 'w',
    CharacterCount = 'm'
}