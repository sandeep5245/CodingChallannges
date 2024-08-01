// See https://aka.ms/new-console-template for more information
using DSACoding;

Console.WriteLine("Hello, World!");

// Console.WriteLine(Solution.MaximumUnits([[2,2],[1,3],[3,1]], 4));
// Console.WriteLine(Solution.MaximumUnits([[5,10],[2,5],[4,7],[3,9]], 10));

Console.WriteLine(String.Join('\n', ArrayTranspose.arrayTranspose([[1,2,3],[4,5,6]]).Select(x => String.Join(' ', x)).ToArray()));
//    ;
