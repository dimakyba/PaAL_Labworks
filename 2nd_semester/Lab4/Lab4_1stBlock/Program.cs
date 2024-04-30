using System;

namespace Lab4
{
  public partial class Program
  {
    static void Main(string[] args)
    {
      int choice;
      do
      {
        Console.WriteLine();
        Console.WriteLine("[0] <- exit");
        Console.WriteLine("[1] - demo mode");
        Console.WriteLine("[2] - check ToSecSinceMidnight");
        Console.WriteLine("[3] - check FromSecSinceMidnight");
        Console.WriteLine("[4] - check AddOneSecond");
        Console.WriteLine("[5] - check AddOneMinute");
        Console.WriteLine("[6] - check AddOneHour");
        Console.WriteLine("[7] - check AddSeconds");
        Console.WriteLine("[8] - check Difference");
        Console.WriteLine("[9] - check IsInRange");
        Console.WriteLine("[10] - check WhatLesson");


        choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
          DemoMode();
          break;
        }

        switch (choice)
        {
          case 2:
            Check_ToSecSinceMidnight();
            break;
          case 3:
            Check_FromSecSinceMidnight();
            break;
          case 4:
            Check_AddOneSecond();
            break;
          case 5:
            Check_AddOneMinute();
            break;
          case 6:
            Check_AddOneHour();
            break;
          case 7:
            Check_AddSeconds();
            break;
          case 8:
            Check_Difference();
            break;
          case 9:
            Check_IsInRange();
            break;
          case 10:
            Check_WhatLesson();
            break;

          case 0:
            Console.WriteLine("bye");
            break;
          default:
            Console.WriteLine("wrong input, try again");
            break;
        }
      } while (choice != 0);

    }
  }
}
