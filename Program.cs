// Output values from 1 to 100, one number per line, inside the code block of an iteration statement.
// When the current value is divisible by 3, print the term Fizz next to the number.
// When the current value is divisible by 5, print the term Buzz next to the number.
// When the current value is divisible by both 3 and 5, print the term FizzBuzz next to the number.

/* -------- */

for (int i = 1; i < 100; i++)
{
  string output = $"{i.ToString()} • ";

  if (i % 3 == 0 && i % 5 == 0)
    output += " • FizzBuzz";
  else if (i % 5 == 0)
    output += " • Buzz";
  else if (i % 3 == 0)
    output += " • Fizz";
  
  Console.WriteLine(output);
}

/* -------- */

// 1
// 2
// 3 - Fizz
// 4
// 5 - Buzz
// 6 - Fizz
// 7
// 8
// 9 - Fizz
// 10 - Buzz
// 11
// 12 - Fizz
// 13
// 14
// 15 - FizzBuzz
// 16
// 17
// 18 - Fizz
// 19
// 20 - Buzz
// 21 - Fizz
// 22