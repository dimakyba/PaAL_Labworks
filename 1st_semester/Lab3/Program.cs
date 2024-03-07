using System;
using System.Text;

namespace Program
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = UTF8Encoding.UTF8;
      System.Console.WriteLine("Введіть значення n: ");
      int n = Int32.Parse(Console.ReadLine());
      System.Console.WriteLine($"Виводжу прості числа вигляду q^2 + 1 від 2 до {n}:");
      PrintAllQPow2PrimeNumbers(n);
      System.Console.WriteLine();
      System.Console.WriteLine($"Виводжу прості числа Фібоначчі від 2 до {n}:");
      PrintAllFibonacciPrimeNumbers(n);
    }

    static bool IsPrime(int n)
    {
      if (n <= 1)
      {
        return false;
      }
      if (n <= 3)
      {
        return true;
      }
      if (n % 2 == 0 || n % 3 == 0)
      {
        return false;
      }
      int i = 5;
      while (i * i < n)
      {
        if (n % i == 0 || n % (i + 2) == 0)
        {
          return false;
        }
        i += 6;
      }

      return true;
    }

    static void PrintAllQPow2PrimeNumbers(int n)
    {
      for (int i = 2; i <= n; i++)
      {
        if (Math.Sqrt(i - 1) % 1 == 0 && IsPrime(i))
        {
          System.Console.Write($"{i} ");
        }
      }
    }

    static void PrintAllFibonacciPrimeNumbers(int n)
    {
      int num1 = 1;
      int num2 = 1;
      int temp;
      while (num2 <= n)
      {
        if (IsPrime(num2))
        {
          System.Console.Write($"{num2} ");
        }
        temp = num1;
        num1 = num2;
        num2 = num1 + temp;
      }
    }
  }
}
