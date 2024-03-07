using System;
using System.Text;

namespace Task3
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = UTF8Encoding.UTF8;
      Console.WriteLine("Labwork #7");
      Console.WriteLine("Task #3, Variant #12");
      Console.WriteLine("Упорядкувати побічну діагональ матриці від мінімального ліворуч-унизу до максимального праворуч-угорі; вважати, що матриця гарантовано квадратна.\n");


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
        SortSecondaryDiagonalOfMatrix(matrix, size);
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


    static void SortSecondaryDiagonalOfMatrix(int[,] matrix, uint size)
    {
      int[] secondaryDiagonal = new int[size];

      for (int i = 0; i < size; i++)
      {
        secondaryDiagonal[i] = matrix[i, size - 1 - i];
      }

      // Array.Sort(secondaryDiagonal);
      PorublyovQuickSort(secondaryDiagonal, 0, (int)size - 1);
      Console.WriteLine("\nСортую побічну діагональ матриці знизу вверх:");

      for (int i = 0; i < size; i++)
      {
        matrix[i, size - 1 - i] = secondaryDiagonal[size - 1 - i];
      }
    }

    static int[] PorublyovQuickSort(int[] array, int leftIndex, int rightIndex)
    {
      int i = leftIndex;
      int j = rightIndex;
      int pivot = array[rightIndex];

      while (i <= j)
      {
        while (array[i] < pivot)
        {
          i++;
        }

        while (array[j] > pivot)
        {
          j--;
        }

        if (i <= j)
        {
          int temp = array[i];
          array[i] = array[j];
          array[j] = temp;
          i++;
          j--;
        }
      }

      if (leftIndex < j)
        PorublyovQuickSort(array, leftIndex, j);

      if (i < rightIndex)
        PorublyovQuickSort(array, i, rightIndex);

      return array;
    }

  }
}
