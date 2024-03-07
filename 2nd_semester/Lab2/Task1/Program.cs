using System;
using System.Text;

namespace Task1
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = UTF8Encoding.UTF8;
      Console.WriteLine("Labwork #7");
      Console.WriteLine("Task #1, Variant #15");
      Console.WriteLine("Знайти і вивести суму елементів, що знаходяться на головній діагоналі матриці, та суму елементів, що знаходяться на побічній діагоналі матриці; вважати, що матриця гарантовано квадратна.\n");

      Console.Write("Введіть розмір матриці (n x n): ");
      uint size = Convert.ToUInt32(Console.ReadLine());

      Console.WriteLine("Виберіть як ви хочете ввести масив:");
      Console.WriteLine("1. Вручну");
      Console.WriteLine("2. Автоматично, псевдо-випадковими числами");
      sbyte choiceOfInput = Convert.ToSByte(Console.ReadLine());

      int[,] matrix = null;

      switch (choiceOfInput)
      {
        case 1:
          matrix = GenerateMatrixFromUserInput(size);
          break;
        case 2:
          matrix = GenerateRandomSquareMatrix(size);
          break;
        default:
          Console.WriteLine("Invalid choice.");
          break;
      }

      if (matrix != null)
      {
        PrintSquareMatrix(matrix, size);
        Console.WriteLine($"Сума елементів головної діагоналі матриці: {GetSumOfMainMatrixDiagonal(matrix, size)}");
        Console.WriteLine($"Сума елементів побічної діагоналі матриці: {GetSumOfSecondaryMatrixDiagonal(matrix, size)}");
      }
    }


    static int[,] GenerateRandomSquareMatrix(uint size)
    {
      int[,] matrix = new int[size, size];
      Random random = new Random();

      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          matrix[i, j] = random.Next(-99, 100);
        }
      }

      return matrix;
    }

    static int[,] GenerateMatrixFromUserInput(uint size)
    {
      int[,] matrix = new int[size, size];
      Random random = new Random();

      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          Console.Write($"Введіть [{i + 1},{j + 1}]: ");

          matrix[i, j] = Convert.ToInt32(Console.ReadLine());
        }
      }

      return matrix;
    }

    static string GetSumOfMainMatrixDiagonal(int[,] matrix, uint size)
    {
      int sum = 0;
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < size; i++)
      {
        if (matrix[i, i] < 0)
        {
          sb.Append($"({matrix[i, i]})");
        }
        else
        {
          sb.Append($"{matrix[i, i]}");
        }

        sum += matrix[i, i];
        if (i < size - 1)
        {
          sb.Append(" + ");
        }

      }
      string result = sb.ToString() + $" = {sum}";
      return result;
    }


    static string GetSumOfSecondaryMatrixDiagonal(int[,] matrix, uint size)
    {
      int sum = 0;
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < size; i++)
      {
        if (matrix[i, size - 1 - i] < 0)
        {
          sb.Append($"({matrix[i, size - 1 - i]})");
        }
        else
        {
          sb.Append($"{matrix[i, size - 1 - i]}");
        }
        sum += matrix[i, size - 1 - i];
        if (i < size - 1)
        {
          sb.Append(" + ");
        }

      }
      string result = sb.ToString() + $" = {sum}";
      return result;
    }

    static void PrintSquareMatrix(int[,] matrix, uint size)
    {
      for (int i = 0; i < size; i++)
      {
        Console.Write('(');
        for (int j = 0; j < size; j++)
        {
          Console.Write($"{matrix[i, j],4} ");
        }
        Console.WriteLine(')');
      }
    }

  }
}
