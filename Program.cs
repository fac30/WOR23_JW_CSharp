// => Setup
string result;
string symbol;

List<string> results = new List<string>();
List<string> symbols = new List<string>();

int games = results.Count;

// => Loop
// ==> Calculations
int flip = new Random().Next(0, 2);

result = (flip == 0) ? "Heads" : "Tails";
symbol = (flip == 0) ? "Ⓗ" : "Ⓣ";

results.Add(result);
symbols.Add(symbol);

games = results.Count;

// ==> Output
// ===> Typography
string game = games < 10 ? $"0{games}" : $"{games}";

// ===> This Game
Console.WriteLine($"  Coin Toss №{game}  ");
Console.WriteLine($"=================");
Console.WriteLine($"‖  {symbol}  |  {result}  ‖");
Console.WriteLine($"=================");

// ===> All Games
Console.WriteLine("All Results");
results.ForEach(result => Console.Write($"{result} "));
Console.WriteLine();
symbols.ForEach(symbol => Console.Write($"{symbol} "));
Console.WriteLine();