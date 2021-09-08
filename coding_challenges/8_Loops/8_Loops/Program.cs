using System;
using System.Collections.Generic;

namespace _8_LoopsChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      /* Your code here */

    }

    /// <summary>
    /// Return the number of elements in the List<int> that are odd.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int UseFor(List<int> x)
    {
      int counter = 0;
      for (int value = 0; value < x.Count; value++)//ex arraylist = {1,2,3,4,5,6,7,8,9,10} => to access the first index => arrlist[0] = 1, arrlist[4] = 5
      {
        if (x[value] % 2 != 0)
        {
          counter++;
        }
      }
      return counter;
    }

    /// <summary>
    /// This method counts the even entries from the provided List<object> 
    /// and returns the total number found.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int UseForEach(List<object> x)
    {
      int counter = 0;
      foreach (var value in x)
      {
        //if conditionals credit goes to Austin Towler
        if (value is sbyte)
        {
          if ((sbyte)value % 2 == 0)
          {
            counter++;
          }
        }
        if (value is byte)
        {
          if ((byte)value % 2 == 0)
          {
            counter++;
          }
        }
        if (value is short)
        {
          if ((short)value % 2 == 0)
          {
            counter++;
          }
        }
        if (value is ushort)
        {
          if ((ushort)value % 2 == 0)
          {
            counter++;
          }
        }
        if (value is int)
        {
          if ((int)value % 2 == 0)
          {
            counter++;
          }
        }
        if (value is uint)
        {
          if ((uint)value % 2 == 0)
          {
            counter++;
          }
        }
        if (value is long)
        {
          if ((long)value % 2 == 0)
          {
            counter++;
          }
        }
        if (value is ulong)
        {
          if ((ulong)value % 2 == 0)
          {
            counter++;
          }
        }
      }
      return counter;
    }

    /// <summary>
    /// This method counts the multiples of 4 from the provided List<int>. 
    /// Exit the loop when the integer 1234 is found.
    /// Return the total number of multiples of 4.
    /// </summary>
    /// <param name="x"></param>
    public static int UseWhile(List<int> x)
    {
      int counter = 0;
      bool flag = true;
      int index = 0;
      while (flag)
      {
        if (x[index] == 1234 || index == x.Count)
        {
          break;
        }
        if (x[index] % 4 == 0)
        {
          counter++;
        }
        index++;
      }
      return counter;
    }

    /// <summary>
    /// This method will evaluate the Int Array provided and return how many of its 
    /// values are multiples of 3 and 4.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int UseForThreeFour(int[] x)
    {
      int counter = 0;
      for (int index = 0; index < x.Length; index++)
      {
        if (x[index] % 3 == 0 && x[index] % 4 == 0)
        {
          counter++;
        }
      }
      return counter;
    }

    /// <summary>
    /// This method takes an array of List<string>'s. 
    /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
    /// </summary>
    /// <param name="stringListArray"></param>
    /// <returns></returns>
    public static string LoopdyLoop(List<string>[] stringListArray)
    {
      string stuff = "";
      foreach (var curArray in stringListArray)
      {
        foreach (var curString in curArray)
        {
          stuff += curString + " ";
        }
      }
      return stuff;
    }
  }
}