using System;
using System.IO;

namespace _6_FlowControl
{
  public class Program
  {
    public static string username { get; set; }
    public static string password { get; set; }
    static void Main(string[] args)
    {
    }

    /// <summary>
    /// This method gets a valid temperature between -40 asnd 135 inclusive 
    /// and returns the valid int. 
    /// </summary>
    /// <returns></returns>
    public static int GetValidTemperature()
    {
      //-40 - 135 valid inputs
      string input;
      bool flag = true;
      int validInput = -41;
      while (flag)
      {
        input = Console.ReadLine();
        //1st tell tryparse what data type to convert to.(int)
        //2nd give 2 parameters to tryparse
        //2nd a) the string we want to parse
        //2nd b) the variable to store the parsed string
        //3rd return true if parse was successful
        //3rd return false if parse was unsuccessful
        if (int.TryParse(input, out validInput))
        {
          //Parse was successful!
          if (validInput >= -40 && validInput <= 135)
          {
            flag = false;
          }
        }
      }
      return validInput;
    }

    /// <summary>
    /// This method has one int parameter
    /// It prints outdoor activity advice and temperature opinion to the console 
    /// based on 20 degree increments starting at -20 and ending at 135 
    /// n < -20, Console.Write("hella cold");
    /// -20 <= n < 0, Console.Write("pretty cold");
    ///  0 <= n < 20, Console.Write("cold");
    /// 20 <= n < 40, Console.Write("thawed out");
    /// 40 <= n < 60, Console.Write("feels like Autumn");
    /// 60 <= n < 80, Console.Write("perfect outdoor workout temperature");
    /// 80 <= n < 90, Console.Write("niiice");
    /// 90 <= n < 100, Console.Write("hella hot");
    /// 100 <= n < 135, Console.Write("hottest");
    /// </summary>
    /// <param name="temp"></param>
    public static void GiveActivityAdvice(int temp)
    {
      if (temp < -20)
      {
        Console.Write("hella cold");
      }
      else if (-20 <= temp && temp < 0)
      {
        Console.Write("pretty cold");
      }
      else if (0 <= temp && temp < 20)
      {
        Console.Write("cold");
      }
      else if (20 <= temp && temp < 40)
      {
        Console.Write("thawed out");
      }
      else if (40 <= temp && temp < 60)
      {
        Console.Write("feels like Autumn");
      }
      else if (60 <= temp && temp < 80)
      {
        Console.Write("perfect outdoor workout temperature");
      }
      else if (80 <= temp && temp < 90)
      {
        Console.Write("niiice");
      }
      else if (90 <= temp && temp < 100)
      {
        Console.Write("hella hot");
      }
      else if (100 <= temp && temp < 135)
      {
        Console.Write("hottest");
      }
    }

    /// <summary>
    /// This method gets a username and password from the user
    /// and stores that data in the global variables of the 
    /// names in the method.
    /// </summary>
    public static void Register()
    {
      Console.Write("Enter new Username: ");
      username = Console.ReadLine();
      Console.WriteLine("Username was saved.");
      Console.Write("Enter new Password: ");
      password = Console.ReadLine();
      Console.WriteLine("Password was saved.");
    }

    /// <summary>
    /// This method gets username and password from the user and
    /// compares them with the username and password names provided in Register().
    /// If the password and username match, the method returns true. 
    /// If they do not match, the user is reprompted for the username and password
    /// until the exact matches are inputted.
    /// </summary>
    /// <returns></returns>
    public static bool Login()
    {
      bool flag = true;
      while (flag)
      {

        string userInput = Console.ReadLine();
        string passInput = Console.ReadLine();
        if (userInput == username && passInput == password)
        {
          flag = false;
        }
      }
      return true;
    }

    /// <summary>
    /// This method has one int parameter.
    /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
    /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
    /// or > 78, Console.WriteLine($"{temp} is too hot!");
    /// For each temperature range, a different advice is given. 
    /// </summary>
    /// <param name="temp"></param>
    public static void GetTemperatureTernary(int temp)
    {
      if (temp <= 42)
      {
        Console.WriteLine($"{temp} is too cold!");
      }
      else if (temp > 78)
      {
        Console.WriteLine($"{temp} is too hot!");
      }
      else
        Console.WriteLine($"{temp} is an ok temperature");
    }
  }//EoP
}//EoN