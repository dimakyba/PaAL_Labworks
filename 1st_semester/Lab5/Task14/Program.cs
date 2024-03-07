using System;
using System.Linq;
using System.Text;

namespace Lab5
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = UTF8Encoding.UTF8;
      int choice;
      do
      {
        Console.WriteLine("Labwork #5, Task #14");
        Console.WriteLine(
          "Замінити всі додатні числа на їхні квадрати і після цього знайти два максимальних значення.");
        Console.WriteLine(
          "1. Заповнити масив псевдовипадковими числами (попередньо ввести к-сть елементів масиву);");
        Console.WriteLine("2. Заповнити масив вручну (попередньо ввести к-сть елементів масиву)");
        Console.WriteLine("0. Вийти.");

        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
          case 1:
            Console.Write("[1] Введіть розмір масиву: ");
            int sizeOfRND = int.Parse(Console.ReadLine());
            int[] rndArr = GeneratePseudoRandomArray(sizeOfRND);
            DoTask14(choice, rndArr);
            break;
          case 2:
            Console.WriteLine(
              "[2] Виберіть, як ви хочете заповнити масив(1 - в один рядок (через пробіл), 2 - кожен символ в новій строці (через \\n)): ");
            int choiceForCase2 = int.Parse(Console.ReadLine());
            switch (choiceForCase2)
            {
              case 1:
                Console.WriteLine("Вибрано заповнення в один рядок.");
                Console.WriteLine("Введіть числа, які ввести в масив:");
                int[] oneLineArr = FillArrayInSingleLine();
                DoTask14(choice, oneLineArr);
                break;

              case 2:
                Console.WriteLine("[2] Введіть розмір масиву: ");
                int size = int.Parse(Console.ReadLine());
                Console.WriteLine("Вибрано заповнення по строкам.");
                Console.WriteLine("Введіть числа, які ввести в масив:");
                int[] sepLineArr = FillArraySeparately(size);
                DoTask14(choice, sepLineArr);
                break;
              default:
                Console.WriteLine("Ви ввели некоректне значення. Спробуйте будь ласка ще раз)");
                break;
            }

            break;
          case 0:
            Console.WriteLine("Виходжу.");
            break;
          default:
            Console.WriteLine("Ви ввели некоректне значення. Спробуйте будь ласка ще раз)");
            break;
        }
      } while (choice != 0);
    }

    static void DoTask14(int choice, int[] arr)
    {
      Console.WriteLine($"[{choice}] Друкую масив:");
      PrintArray(arr);
      Console.WriteLine();
      Console.WriteLine($"[{choice}] Тепер друкую масив, у якому всі додатні числа піднесені до квадрату");
      PrintArray(SquarePositiveNumbers(arr));
      Console.WriteLine();
      Console.WriteLine($"[{choice}] Тепер виведемо перший і другий максимум числа: {FindTwoMaximums(arr)}.");
    }

    static void PrintArray(int[] arr)
    {
      for (int i = 0; i < arr.Length; i++)
      {
        Console.Write($"{arr[i]} ");
      }

      Console.WriteLine();
    }


    static string FindTwoMaximums(int[] arr)
    {
      int max1 = int.MinValue;
      int max2 = int.MinValue;

      for (int i = 0; i < arr.Length; i++)
      {
        if (arr[i] > max1)
        {
          max2 = max1;
          max1 = arr[i];
        }
        else if (arr[i] > max2)
        {
          max2 = arr[i];
        }
      }


      return $"max1 = {max1}, max2 = {max2}";
    }

    static int[] GeneratePseudoRandomArray(int size)
    {
      Random random = new Random();
      int[] array = new int[size];

      for (int i = 0; i < size; i++)
      {
        array[i] = random.Next(-99, 100);
      }


      return array;
    }

    static int[] FillArrayInSingleLine()
    {
      return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    }

    static int[] FillArraySeparately(int size)
    {
      int[] array = new int[size];

      for (int i = 0; i < size; i++)
      {
        array[i] = int.Parse(Console.ReadLine());
      }

      return array;
    }

    static int[] SquarePositiveNumbers(int[] arr)
    {
      for (int i = 0; i < arr.Length; i++)
      {
        if (arr[i] > 0)
        {
          arr[i] = arr[i] * arr[i];
        }
      }

      return arr;
    }
  }
}
