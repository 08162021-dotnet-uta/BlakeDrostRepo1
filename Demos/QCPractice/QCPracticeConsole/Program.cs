using System;
using System.Collections.Generic;

namespace QCPracticeConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      string input = "";                //incomplete word
      input = Console.ReadLine();
      int lengthOfInput = input.Length; //grabbing the amount of characters the incomplete word has

      List<string> solutions = new List<string>();//the words that contain the prefix

      List<string> solutionQuery = new List<string>();//a list of all possible corrections (correct or incorrect)
      string possibleSolutions = "";  //the current word beind added
      bool flag = true;
      while (flag)
      {
        possibleSolutions = Console.ReadLine();
        if (possibleSolutions.Length == 0)
        {
          break;
        }
        else
        {
          solutionQuery.Add(possibleSolutions);
        }
      }

      for (int i = 0; i < solutionQuery.Count; i++)
      {
        //check each char of input to each char of the current solutionQuery
        bool flag1 = true;
        for (int j = 0; j < lengthOfInput; j++)
        {
          if (input[j] == solutionQuery[i][j])
          {
            continue;
          }
          else
          {
            flag1 = false;
          }
        }
        if (flag1 == true)
        {
          solutions.Add(solutionQuery[i]);
        }
      }

      //order the solutions alphabetically
      solutions.Sort();
      //dog\n       dog\n
      //donut\n     donut\n
      //dough\n     dough
      for (int k = 0; k < solutions.Count; k++)
      {
        if (k == solutions.Count - 1)
        {
          Console.Write(solutions[k]);
        }
        else
        {
          Console.WriteLine(solutions[k]);
        }
      }
    }
  }
}
