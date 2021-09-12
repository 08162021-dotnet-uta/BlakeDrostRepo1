using System;

namespace _9_ClassesChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Human h1 = new Human();
      Human h2 = new Human("Tony", "Stark");
      Console.WriteLine(h1.AboutMe());
      Console.WriteLine(h2.AboutMe());
      Human2 h3 = new Human2("Bill", "Beaux", "Green");
      Human2 h4 = new Human2("Toby", "Keith", 44);
      Human2 h5 = new Human2("Curious", "George", "Brown", 12);
      Console.WriteLine(h3.AboutMe2());
      Console.WriteLine(h4.AboutMe2());
      Console.WriteLine(h5.AboutMe2());
      Human2 h6 = new Human2();
      h6.Weight = -1;
      Console.WriteLine(h6.Weight);
    }
  }
}
