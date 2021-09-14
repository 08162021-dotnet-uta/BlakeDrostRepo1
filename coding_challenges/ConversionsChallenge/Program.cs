using System;

namespace ConversionsChallenge
{
  class Program
  {
    static void Main(string[] args)
    {
      //Casting:  tables showing implicit and explicit cast from numeric data types to other numeric data types
      //          can be viewed at the following webpage.
      //          https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions
      //Implicit
      int iData = 5;
      float fData = iData;
      Console.WriteLine("Implicitly cast an integer to a float.");
      Console.WriteLine($"Integer value: {iData}. Float value = integer value: {fData}.");
      //Explicit
      float floatData = 4.4f;
      int integerData = (int)floatData;
      Console.WriteLine("Explicitly cast a float to an integer.");
      Console.WriteLine($"Float value: {floatData}. Integer value = (int)float value: {integerData}.");

      //Conversion: built in methods for numeric data types
      string someData = "1999";
      int dateData = Convert.ToInt32(someData);
      System.Console.WriteLine("Converting to integer using Convert.ToInt32()");
      System.Console.WriteLine($"Input data: \"{someData}\". Integer value = Convert.ToInt32({someData}): {dateData}.");

      //Parse: tries to convert a string to a certain data type, returns false if unsuccessful.
      //Pros: useful for when the programmer has little access or control over incomming data.
      string input1 = "Dog";
      string input2 = "42.42";
      float parsedInput1;
      System.Console.WriteLine($"Try to parse input1(\"{input1}\") to a float.");
      if (float.TryParse(input1, out parsedInput1))
      {
        System.Console.WriteLine("Successful TryParse!");
      }
      else
      {
        System.Console.WriteLine("Unsuccessful TryParse!");
        System.Console.WriteLine($"Could not convert \"{input1}\" to a float.");
      }
      float parsedInput2;
      System.Console.WriteLine($"Try to parse input2(\"{input2}\") to a float.");
      if (float.TryParse(input2, out parsedInput2))
      {
        System.Console.WriteLine("Successful TryParse!");
        System.Console.WriteLine($"input2 (\"{input2}\"). input2 as a float ({parsedInput2})");
      }
      else
      {
        System.Console.WriteLine("Unsuccessful TryParse!");
      }



    }
  }
}
