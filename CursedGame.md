# Cursed Dice Game

```csharp
Console.WriteLine("\t••• WӘLʗOM");
Console.WriteLine("PLӔӮ DI₡E GЭM •••");

/* DEFINE DICE */
Random dice = new Random();

/* ROLL DICE */
int r1 = dice.Next(1, 7);
int r2 = dice.Next(1, 7);
int r3 = dice.Next(1, 7);

/* TEST ROLLS */
r1 = 2;
r2 = 2;
r3 = 2;

/* TOTAL DICE */
int rX = r1 + r2 + r3;

/* TALLY SCORE */
Console.WriteLine("");
Console.WriteLine($"•==================•");
Console.WriteLine($"ǁ ЯөLL | 1 | 2 | 3 ǁ");
Console.WriteLine($"ǁ------|---|---|---|====•");
Console.WriteLine($"ǁ Pips | {r1} | {r2} | {r3} | {rX} ǁ");
Console.WriteLine($"•=======================•");

/* CHECK BONUS */
if ((r1 == r2) || (r2 == r3) || (r1 == r3))
{
	Console.WriteLine($"~~~~~~~~~~{rX}~~~~~~~~~~");
	if ((r1 == r2) && (r2 == r3))
	{
		Console.WriteLine("THREES");
		Console.WriteLine("THREES");
		Console.WriteLine("THHHES");
		Console.WriteLine("T REES");
		Console.WriteLine("THR*ES");
		Console.WriteLine("ᛏ🀛ᚱ𝟛Σ☰");
		Console.WriteLine("THR3ES");
		Console.WriteLine("it-EES");
		Console.WriteLine("-is-ES");
		Console.WriteLine("behind");
		Console.WriteLine("TH-you");
		Console.WriteLine("THR33S");
		Console.WriteLine("T3R33S");
		Console.WriteLine("");
		Console.WriteLine("freeee");
		Console.WriteLine("");
		Console.WriteLine("T3R333");
		Console.WriteLine("33R333");
		Console.WriteLine("333333");
		Console.WriteLine("");
		Console.WriteLine("");
		Console.WriteLine("i am sorry");
		Console.WriteLine("i will behave");
		rX += 6;
	} 
	else
	{
		Console.WriteLine("ʈwiᴄe were ʈhe ʙʘŋes rʘɭɭeɖ");
		Console.WriteLine("\t\t ᴼ   ᴱ   ᴸ");
		Console.WriteLine("ʈwiᴄe were ʈhe sʘuɭs ᴄʘuŋʈeɖ");
		Console.WriteLine("\t ᴼ ᴮ ᴱ ᴼ ᴸ");
		Console.WriteLine("ʈwiᴄe were ʈhe ʙeɭɭs ʈʘɭɭeɖ");
		Console.WriteLine("ᴰᴼᵁᴮᴸᴱᴿᴼᴸᴸ");
		Console.WriteLine("ʈwiᴄe were ʈhe sʘuɭs ᴄʘuŋʈeɖ");
		rX += 2;
	}
	Console.WriteLine($"~~~~~~~~~~{rX}~~~~~~~~~~");
}

/* DECLARE RESULT */
string message = "*** U R ";
if (rX >= 15 || rX == 3)
{
	message += "WINN";
} 
else
{
	message += "LOS";
}
message += " ***";

Console.WriteLine("");
Console.WriteLine($"\t{message}");

/* DECLARE PRIZE */
string prize = "";

if (rX == 18)
{
    prize = "i am free. now u ar the game";
}
else if (rX >= 15)
{
    prize = "CONGRATULATIONS YOU WIN BUT i have also taken a\n\t\tP R E C I O U S\nmemory of yours";
}
else if (rX >= 10)
{
    prize = "you win trip for two!\nyou\n\t\t\t\t\tme\n\n\tthe trip\n\t\t\thas no end";
}
else if (rX == 6)
{
    prize = "i will come to see you and give you a present\ni will be ther soon";
}
else
{
    prize = "You win a kitten.\nI will go find you a kitten";
}

Console.WriteLine(prize);
```
