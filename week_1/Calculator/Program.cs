
//Type Inference (var)
//Parsing
//Casting (implicit, explicit)
//Scopes (namespace, class, method, block)
//Single Responsibility (part of SOLID)
//DRY (don't repeat yourself)
//Method (signature, parameter, argument)
//Primitive Types (int, bool, string, float, ...)
//Type Families (value, reference)
//Method Signature (access modifier, optionally non-access modifiers, return type, identifier, optionally parameters)
//Exception Handling


using System;

namespace Calculator
{
  class Program
  {
    static void Main(string[] args)
    {
      //input stuff
      int input1, input2;
      if(Input(out input1, out input2)){

      //compute stuff
      int result1 = Add(input1, input2);
      int result2 = Subtract(input1, input2);
      int result3 = Multiply(input1, input2);
      int result4 = Divide(input1, input2);
      //output stuff
      Print(result1,result2,result3,result4);
      }
    }

    //METHODS
    //Add Function
    static int Add(int input1, int input2){
      //compute stuff
      return (int)input1 + (int)input2;     //type inference: let the value dictate the variable type
    }
    //Subtract Function
    static int Subtract(int input1, int input2){
      //compute stuff
      return (int)input1 - (int)input2;     //type inference: let the value dictate the variable type
    }
    //Multiply Function
    static int Multiply(int input1, int input2){
      return (int)input1 * (int)input2;
    }
    //Divide Function
    static int Divide(int input1, int input2){
      return (int)input1 / (int)input2;
    }
    //Print Function
    static void Print(params int[] results){
      foreach(var currentResult in results){
        Console.WriteLine(currentResult);
      }
    }

    static bool CustomTryParse(string s, out int result){
      try{
        result = int.Parse(s);
        return true;
      }
      catch{
        result = 0;
        return false;
      }
    }

    static bool Input(out int i1, out int i2){
    //   try{
    //     var input1 = int.Parse(Console.ReadLine());
    //     var input2 = int.Parse(Console.ReadLine());

    //     return new int[] { input1, input2 };
    //   }
    //   catch(Exception ex){
    //     //throw ex; //points to the original error
    //     throw new Exception("Sorry for the inconvenience", ex); //creates a new error
    //   }
    //   finally{
    //     //always run
    //   }
      int input1, input2;

      if(int.TryParse(Console.ReadLine(), out input1) && int.TryParse(Console.ReadLine(), out input2)){
        i1 = input1;
        i2 = input2;
        return true;
      }
      else{
        i1 = i2 = 0;
        return false;
      }
    }
  }
}
