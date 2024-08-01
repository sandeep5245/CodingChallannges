// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

#region File functionality delegates
var GetLineCount = (Stream stream) => {
    
    long lc = 0;
    stream.Position = 0;
    var reader = new StreamReader(stream);

    while(reader.ReadLine() != null)
    {
        lc++;
    }
    
    return lc;
};

var GetWordCount = (Stream stream) => {
    
    long wc = 0;
    stream.Position = 0;
    var reader = new StreamReader(stream);

    string? line;
    while((line = reader.ReadLine()) != null)
    {
        wc += line.Split(' ').Length;
    }    

    return wc;
};

var GetCharacterCount = (Stream stream) => {
    
    long cc = 0;
    stream.Position = 0;
    var reader = new StreamReader(stream);

    while(reader.Read() > -1)
    {
        cc++;
    }

    return cc;
};

var GetByteCount = (Stream stream) => {

    long bc = 0;
    stream.Position = 0;
    
    while (stream.ReadByte() > -1)
    {
        bc++;
    }

    return bc;
};
#endregion

var argsLength = args.Length;

var commandRegex = new Regex(@"-(?<cmd>[clmw]{1})");
var filenameRegex = new Regex(@"\w.\w{3}");

var argumentsDescription = @"CCWC command accepts atleast one argument from below. 
    1. -c -> Byte count
        -l -> Line count
        -w -> Word count 
        -m -> Character count 
    2. filename or path";

Command command = Command.Empty;
string filename = string.Empty;

if (argsLength < 1 || argsLength > 2)
    throw new ArgumentException($"Wrong no of arguments passed. \n {argumentsDescription}");

if (argsLength == 2)
{
    Match m = commandRegex.Match(args[0]);
    if (m.Success && filenameRegex.IsMatch(args[1]))
    {
        command = (Command)Enum.ToObject(typeof(Command), m.Result("${cmd}")[0]);
        filename = args[1];
    }
    else
        throw new ArgumentException($"Arguments are invalid. \n {argumentsDescription}");
}
else   //(argsLength == 1)
{
    Match m = commandRegex.Match(args[0]);
    if (m.Success)
    {
        command = (Command)Enum.ToObject(typeof(Command), m.Result("${cmd}")[0]);
        //Read the input from pipe and pass that as stream. Till then return that feature is not yet implemented
        Console.WriteLine("Reading input from pipe is in progress. Will be availabel shortly.");
        return;

        filename = Guid.NewGuid().ToString();
        using var sWriter = new StreamWriter(File.OpenWrite(filename));

    }        
    else if (filenameRegex.IsMatch(args[0]))
    {
        filename = args[0];
        command = Command.Default;
    }        
    else
        throw new ArgumentException($"Arguments are invalid. \n {argumentsDescription}");
}

var file = new FileInfo(filename);
if(!file.Exists)
{
    Console.WriteLine($"File {filename} doesn't exist.");
    return;
}

using(var stream = File.OpenRead(filename))
{
    switch(command)
    {
        case Command.ByteCount:
            Console.WriteLine($"{stream.Length} {filename}");
            //Console.WriteLine($"{GetByteCount(stream)} {filename}");
            break;
        case Command.LineCount:
            var lcount = GetLineCount(stream);
            Console.WriteLine($"{GetLineCount(stream)} {filename}");
            break;
        case Command.WordCount:
            Console.WriteLine($"{GetWordCount(stream)} {filename}");
            break;
        case Command.CharacterCount:
            Console.WriteLine($"{GetCharacterCount(stream)} {filename}");
            break;
        case Command.Default:
            Console.WriteLine($"{stream.Length} {GetLineCount(stream)} {GetWordCount(stream)} {filename}");
            break;
        case Command.Empty:
            break;
    }
}

enum Command
{
    ByteCount = 'c',
    LineCount = 'l',
    WordCount = 'w',
    CharacterCount = 'm',
    Default = 'd',
    Empty
}