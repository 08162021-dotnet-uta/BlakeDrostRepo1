using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
  internal class Human2
  {
    private string firstName = "Pat";
    private string lastName = "Smyth";
    private string eyeColor;
    private int age;
    private int _weight;
    public int Weight
    {
      get
      {
        return _weight;
      }
      set
      {
        if (value < 0 || value > 400)
        {
          _weight = 0;
        }
        else
        {
          _weight = value;
        }
      }
    }

    public Human2()
    {

    }

    public Human2(string fName, string lName, string eColor, int a)
    {
      firstName = fName;
      lastName = lName;
      eyeColor = eColor;
      age = a;
    }

    public Human2(string fName, string lName, string eColor)
    {
      firstName = fName;
      lastName = lName;
      eyeColor = eColor;
    }
    public Human2(string fName, string lName, int a)
    {
      firstName = fName;
      lastName = lName;
      age = a;
    }

    public string AboutMe2()
    {
      if (eyeColor == null && age == 0)
      {
        return $"My name is {firstName} {lastName}.";
      }
      if (eyeColor == null)
      {
        return $"My name is {firstName} {lastName}. My age is {age}.";
      }
      if (age == 0)
      {
        return $"My name is {firstName} {lastName}. My eye color is {eyeColor}.";
      }
      else
      {
        return $"My name is {firstName} {lastName}. My age is {age}. My eye color is {eyeColor}.";
      }
    }
    public string AboutMe()
    {
      return "My name is " + firstName + " " + lastName + ".";
    }
  }
}