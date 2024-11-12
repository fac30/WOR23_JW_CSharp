//=> Methods

void SayHello()                       //?? Signature 
{                                     //?? Definition
  Console.WriteLine("Hello World!");  //??     |     
}                                     //??     |     

//?? This works 

/***/ SayHello();
/***/
/***/ void SayHello()
/***/ {
/***/   Console.WriteLine("Hello World!");
/***/ }

//?? Often defined at end of program 

/***/ int[] a = {1,2,3,4,5};
/***/ 
/***/ Console.WriteLine("Contents of Array:");
/***/ PrintArray();
/***/ 
/***/ void PrintArray()
/***/ {
/***/   foreach (int x in a)
/***/   {
/***/     Console.Write($"{x} ");
/***/   }
/***/   Console.WriteLine();
/***/ }

/* Best Practises
- Method names should be Pascal case and generally shouldn't start with digits.
- Names for parameters should describe what kind of information the parameter represents.*/

void ShowData(string a, int b, int c);
void DisplayDate(string month, int day, int year);