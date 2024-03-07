using System;
using System.Text;

namespace Task2
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = UTF8Encoding.UTF8;
      Console.WriteLine("Labwork #7");
      Console.WriteLine("Task #2, Variant #13");
      Console.WriteLine("Якщо хоча б один з максимальних елементів матриці лежить на головній діагоналі, то перенести його (елемент) на побічну діагональ симетрично відносно вертикалі; якщо таких елементів кілька, то перенести їх усі; вважати, що матриця гарантовано квадратна.\n");


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
        MoveMaxElementsToSecondaryDiagonal(matrix, size);
        PrintSquareMatrix(matrix, size);
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


    static void MoveMaxElementsToSecondaryDiagonal(int[,] matrix, uint size)
    {

      int maxMainDiagonal = matrix[0, 0];
      for (int i = 1; i < size; i++)
      {
        if (matrix[i, i] > maxMainDiagonal)
        {
          maxMainDiagonal = matrix[i, i];
        }
      }
      Console.WriteLine($"Максимальний елемент: {maxMainDiagonal}");
      Console.WriteLine("Симетрично переставляємо максимальні елементи з головної діагоналі на побічну:");
      for (int i = 0; i < size; i++)
      {
        if (matrix[i, i] == maxMainDiagonal)
        {
          int temp = matrix[i, size - 1 - i];
          matrix[i, size - 1 - i] = maxMainDiagonal;
          matrix[i, i] = temp;
        }
      }
    }
  }
}
