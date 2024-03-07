using System;
using System.Text;

namespace Task4
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = UTF8Encoding.UTF8;
      Console.WriteLine("Labwork #7");
      Console.WriteLine("Task #4, Variant #13");
      Console.WriteLine("Упорядкувати стовпчики матриці за незростанням кількостей нулів у цих стовпчиках (тобто, зліва стовпчики, де нулів найбільше, потім ті де трохи менше, і так аж до правого краю, де ті стовпчики, в яких нулів найменше).\n");

      Console.Write("Введіть кількість рядків матриці: ");
      int rows = Convert.ToInt32(Console.ReadLine());
      Console.Write("Введіть кількість стовбчиків матриці: ");
      int cols = Convert.ToInt32(Console.ReadLine());

      int[,] matrix = null;

      Console.WriteLine("Виберіть як ви хочете ввести масив:");
      Console.WriteLine("1. Вручну");
      Console.WriteLine("2. Автоматично, псевдо-випадковими числами");
      sbyte choiceOfInput = Convert.ToSByte(Console.ReadLine());


      switch (choiceOfInput)
      {
        case 1:
          matrix = GenerateMatrixFromUserInput(rows, cols);
          break;
        case 2:
          matrix = GenerateRandomSquareMatrix(rows, cols);
          break;
        default:
          Console.WriteLine("Invalid choice.");
          break;
      }

      if (matrix != null)
      {
        PrintMatrix(matrix, rows, cols);
        matrix = SortColsOfMatrixDescendingZeros(matrix, rows, cols);
        PrintMatrix(matrix, rows, cols);
      }
    }


    static void PrintMatrix(int[,] matrix, int rows, int cols)
    {
      for (int i = 0; i < rows; i++)
      {
        Console.Write('(');
        for (int j = 0; j < cols; j++)
        {
          Console.Write($"{matrix[i, j],4} ");
        }
        Console.WriteLine(')');
      }
    }


    static int[,] GenerateRandomSquareMatrix(int rows, int cols)
    {
      int[,] matrix = new int[rows, cols];
      Random random = new Random();

      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < cols; j++)
        {
          matrix[i, j] = random.Next(0, 2);
        }
      }

      return matrix;
    }


    static int[,] GenerateMatrixFromUserInput(int rows, int cols)
    {
      int[,] matrix = new int[rows, cols];
      Random random = new Random();

      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < cols; j++)
        {
          Console.Write($"Введіть [{i + 1},{j + 1}]: ");

          matrix[i, j] = Convert.ToInt32(Console.ReadLine());
        }
      }

      return matrix;
    }

    static int[,] SortColsOfMatrixDescendingZeros(int[,] matrix, int rows, int cols)
    {
      Console.WriteLine("\nСортую стовпчики матриці за незростанням кількостей нулів у цих стовпчиках:");

      int[] zerosInCols = new int[cols];

      for (int j = 0; j < cols; j++)
      {
        int count = 0;
        for (int i = 0; i < rows; i++)
        {
          if (matrix[i, j] == 0)
          {
            count++;
          }
        }
        zerosInCols[j] = count;
      }

      int[] columnIndices = new int[cols];
      for (int i = 0; i < cols; i++)
      {
        columnIndices[i] = i;
      }

      // insertion sort method that sorts two arrays according to values of zerosInCols[]
      for (int i = 1; i < cols; i++)
      {
        int zeroCountTemp = zerosInCols[i];
        int columnIndexTemp = columnIndices[i];
        int j = i - 1;
        while (j >= 0 && zerosInCols[j] < zeroCountTemp)
        {
          zerosInCols[j + 1] = zerosInCols[j];
          columnIndices[j + 1] = columnIndices[j];
          j--;
        }
        zerosInCols[j + 1] = zeroCountTemp;
        columnIndices[j + 1] = columnIndexTemp;
      }

      int[,] sortedMatrix = new int[rows, cols];
      for (int i = 0; i < cols; i++)
      {
        int columnIndex = columnIndices[i];
        for (int j = 0; j < rows; j++)
        {
          sortedMatrix[j, i] = matrix[j, columnIndex];
        }
      }

      return sortedMatrix;
    }

  }
}
