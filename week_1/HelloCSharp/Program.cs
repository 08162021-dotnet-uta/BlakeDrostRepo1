using System;

namespace HelloCSharp
{
    class Program
    {
      //Build a simple calculator using 5 methods: Add, Multiply, Subtract, Divide, Print
        static void Main(string[] args)
        {
            //User Prompt
            Console.WriteLine("Welcome to the best calculator!");
            Console.WriteLine("Instructions: Enter two numbers with an operator between them.");
            Console.WriteLine("Example: 6 / 3");
            //Read in the User's Input
            String userInput = Console.ReadLine();
            //Error checking for invalid inputs would go here.
            String[] inputParts = userInput.Split(' ');
            int a = Convert.ToInt32(inputParts[0]);     //  a: stores the first number
            String op = inputParts[1];                  //  op: stores the operator
            int b = Convert.ToInt32(inputParts[2]);     //  b: stores the second number

            //Assume the user will input like the example
            if(op.Equals("+")){                         //  + operator is used
              Console.WriteLine(Print(Add(a,b)));
            }else if(op.Equals("-")){                   //  - operator is used
              Console.WriteLine(Print(Subtract(a,b)));
            }else if(op.Equals("*")){                   //  * operator is used
              Console.WriteLine(Print(Multiply(a,b)));
            }else if(op.Equals("/")){                   //  / operator is used
              if(b==0){                                 //  incase the user wants to divide by zero
                Console.WriteLine("Cannot Divide by Zero.");
                System.Environment.Exit(0);
              }
              Console.WriteLine(Print(Divide(a,b)));
            }else{                                      //  the operator is not one of the four operators implemented
              Console.WriteLine("Not a valid operator.");
            }
        }

        //Adds two numbers
        public static int Add(int a, int b){
          return a+b;
        }
        //Subtracts the first parameter by a value of parameter b
        public static int Subtract(int a, int b){
          return a-b;
        }
        //Multiplies two numbers
        public static int Multiply(int a, int b){
          return a*b;
        }
        //Divides the first parameter by a value of parameter b
        public static double Divide(int a, int b){
          double aFloat = (double)a;
          double bFloat = (double)b;
          return aFloat/bFloat;
        }
        //Writes a number to the console
        public static String Print(int answer){
          return "The answer is: " + answer;
        }
        public static String Print(double answer){
          return "The answer is: " + answer;
        }
    }
}
