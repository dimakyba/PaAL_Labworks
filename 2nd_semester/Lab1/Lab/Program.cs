using System;
using System.Linq;

namespace Lab
{

  class Program
  {
    static void Main(string[] args)
    {
      bool isValidInput = false;

      while (!isValidInput)
      {
        Console.WriteLine("Please enter 3 integers:");
        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        if (input.Length == 3)
        {
          if (!IsSorted(input))
          {
            InsertionSort(input);
          }
          PrintAllPermutations(input);
          isValidInput = true;
        }
        else
        {
          Console.WriteLine("There aren't 3 integers, please try again");
        }

      }
    }
    static bool IsSorted(int[] arr)
    {
      for (int i = 0; i < arr.Length - 1; i++)
      {
        if (arr[i] > arr[i + 1])
        {
          return false;
        }
      }

      return true;
    }

    static int[] InsertionSort(int[] arr)
    {
      int length = arr.Length;
      for (int i = 1; i < length; i++)
      {
        int key = arr[i];
        int j = i - 1;
        while (j >= 0 && arr[j] > key)
        {
          arr[j + 1] = arr[j];
          j--;
        }
        arr[j + 1] = key;
      }
      return arr;
    }
    static void PrintAllPermutations(int[] array)
    {
      int n = array.Length;
      long size = Factorial(n);
      int[][] outerArray = new int[size][];


      int count = 0;
      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < n; j++)
        {
          for (int k = 0; k < n; k++)
          {
            if (i != j && i != k && j != k)
            {
              outerArray[count] = new int[] { array[i], array[j], array[k] };
              count++;
            }
          }
        }
      }
      int[][] filteredArray = GetDistinctRowsOfMatrix(outerArray);
      int permutations = filteredArray.Length;
      int uniqueNumbers = array.Distinct().ToArray().Length;
      Console.WriteLine($"There are {permutations} unique permutations with {uniqueNumbers} unique numbers:");
      PrintMatrix(filteredArray);
    }

    static void PrintMatrix(int[][] arr)
    {
      foreach (var innerArr in arr)
      {
        Console.Write("( ");
        foreach (var element in innerArr)
        {

          Console.Write(element + " ");
        }
        Console.Write(")");
        Console.WriteLine();
      }
    }

    static int[][] GetDistinctRowsOfMatrix(int[][] arr)
    {

      List<int[]> distinctArrays = new List<int[]>();

      foreach (var innerArray in arr)
      {
        bool isDuplicate = false;
        foreach (var distinctArray in distinctArrays)
        {
          if (ArraysAreEqual(innerArray, distinctArray))
          {
            isDuplicate = true;
            break;
          }
        }
        if (!isDuplicate)
        {
          distinctArrays.Add(innerArray);
        }
      }

      return distinctArrays.ToArray();
    }

    static bool ArraysAreEqual(int[] arr1, int[] arr2)
    {
      if (arr1.Length != arr2.Length)
        return false;

      for (int i = 0; i < arr1.Length; i++)
      {
        if (arr1[i] != arr2[i])
          return false;
      }

      return true;
    }

    static long Factorial(int n)
    {
      if (n < 0)
      {
        return -1;
      }

      long result = 1;
      for (int i = 2; i <= n; i++)
      {
        result *= i;
      }
      return result;
    }
  }

}
