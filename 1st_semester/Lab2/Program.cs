using System;

class Program
{
  static void doBlockOne()
  {
    System.Console.WriteLine("Дана послідовність з n цілих чисел. Знайти суму елементів з непарними номерами з цієї послідовності.");
    System.Console.Write("Введіть значення n: ");
    int n = Convert.ToInt32(Console.ReadLine());
    int sum = 0;

    for (int i = 1; i <= n; i++)
    {
      int k = Convert.ToInt32(Console.ReadLine());
      if (i % 2 == 1)
      {
        sum += k;
      }
    }

    System.Console.WriteLine(sum);
  }


  static void doBlockTwo()
  {
    System.Console.WriteLine("Дана послідовність цілих чисел, за якою слідує 0. Знайти номер мінімального елементу в цій послідовності.");

    int min = int.MaxValue;
    int minIndex = 0;
    int currentIndex = 1;
    int i = Convert.ToInt32(Console.ReadLine());

    while (i != 0)
    {
      if (i < min)
      {
        min = i;
        minIndex = currentIndex;
      }

      currentIndex++;
      i = Convert.ToInt32(Console.ReadLine());
    }

    System.Console.WriteLine("Номер мінімального елемента: " + minIndex);
  }



  static void doBlockThree()
  {
    System.Console.WriteLine("S = sin(x + cos(2x + sin(3x + cos(4x + sin(5x + cos(6x +...)...) (до sin(nx) чи cos(nx) включно, sin(nx) чи cos(nx) залежить від парності n);");
    System.Console.Write("Введіть n: ");
    int n = Convert.ToInt32(Console.ReadLine());
    System.Console.Write("Введіть x: ");
    int x = Convert.ToInt32(Console.ReadLine());
    double solution;

    if (n % 2 == 0)
    {
      solution = Math.Cos(n * x);
    }
    else
    {
      solution = Math.Sin(n * x);
    }
    n--;
    while (n > 0)
    {
      if (n % 2 == 0)
      {
        solution = Math.Cos(n * x + solution);
      }
      else
      {
        solution = Math.Sin(n * x + solution);
      }
      n--;
    }
    solution = Math.Sin(solution);
    System.Console.WriteLine(solution);
  }

  static void Main(string[] args)
  {
    int choice;
    do
    {
      Console.WriteLine("Для виконання блоку 1 (варіант 5) введіть 1");
      Console.WriteLine("Для виконання блоку 2 (варіант 25 введіть 2");
      Console.WriteLine("Для виконання блоку 3 (варіант 62 введіть 3");
      Console.WriteLine("Для виходу з програми введіть 0");
      choice = int.Parse(Console.ReadLine());
      switch (choice)
      {
        case 1:
          Console.WriteLine("Виконую блок 1");
          doBlockOne();
          break;
        case 2:
          Console.WriteLine("Виконую блок 2");
          doBlockTwo();
          break;
        case 3:
          Console.WriteLine("Виконую блок 3");
          doBlockThree();
          break;
        case 0:
          Console.WriteLine("Зараз завершимо, тільки натисніть будь ласка ще раз Enter");
          Console.ReadLine();
          break;
        default:
          Console.WriteLine("Команда ``{0}'' не розпізнана. Зробіь, будь ласка, вибір із 1, 2, 3, 0.", choice);
          break;
      }
    } while (choice != 0);
  }
}
