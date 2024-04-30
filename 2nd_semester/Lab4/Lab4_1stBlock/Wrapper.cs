namespace Lab4
{
  public partial class Program
  {
    static MyTime EnterMyTime()
    {
      Console.Write("enter the MyTime structure in format like 00:00:00 : ");
      MyTime mt = new(Console.ReadLine());
      return mt;
    }

    static int EnterSeconds()
    {
      Console.Write("введіть к-сть секунд: ");
      return int.Parse(Console.ReadLine());
    }
    public static void Check_ToSecSinceMidnight()
    {
      var mt = EnterMyTime();
      Console.WriteLine($"З півночі по {mt} пройшло {ToSecSinceMidnight(mt)} секунд.");
    }

    public static void Check_FromSecSinceMidnight()
    {
      var seconds = EnterSeconds();
      Console.WriteLine($"Перевівши час з опівночі з {seconds} секунд у формат годинника, отримуємо {FromSecSinceMidnight(seconds)}");
      Console.WriteLine();
    }

    public static void Check_AddOneSecond()
    {
      var mt = EnterMyTime();
      Console.WriteLine($"Час після додавання однієї секунди: {AddOneSecond(mt)}");
    }

    public static void Check_AddOneMinute()
    {
      var mt = EnterMyTime();
      Console.WriteLine($"Час після додавання однієї хвилини: {AddOneSecond(mt)}");
    }

    public static void Check_AddOneHour()
    {
      var mt = EnterMyTime();
      Console.WriteLine($"Час після додавання однієї години: {AddOneHour(mt)}");
    }

    public static void Check_AddSeconds()
    {
      var mt = EnterMyTime();
      var seconds = EnterSeconds();
      Console.WriteLine($"Час до додавання {seconds} секунд: {mt}");
      Console.WriteLine($"Час після додавання {seconds} секунд: {AddSeconds(mt, seconds)}");

    }

    public static void Check_IsInRange()
    {
      var start = EnterMyTime();
      var finish = EnterMyTime();
      var check = EnterMyTime();
      bool isInRange = IsInRange(start, finish, check);
      if (isInRange)
      {
        Console.WriteLine($"{check} знаходиться у діапазоні між {start} та {finish}");
      }
      else
      {
        Console.WriteLine($"{check} не знаходиться у діапазоні між {start} та {finish}");
      }
    }

    public static void Check_Difference() {
      var mt1 = EnterMyTime();
      var mt2 = EnterMyTime();
      int difference = Difference(mt1, mt2);
      Console.WriteLine($"Різниця між {mt1} та {mt2} - {difference} секунд, або ж {FromSecSinceMidnight(Math.Abs(difference))}");
    }

    public static void Check_WhatLesson() {
      var mt = EnterMyTime();
      Console.WriteLine($"{mt} - {WhatLesson(mt)}");
    }

  }
}
