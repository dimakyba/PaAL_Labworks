namespace Lab4
{
  public partial class Program
  {
    public static void DemoMode()
    {
      Console.WriteLine("Перевірка методу ToSecSinceMidnight:");
      MyTime time1 = new MyTime(10, 30, 15);
      MyTime time2 = new MyTime(5, 45, 20);
      Console.WriteLine($"З півночі по {time1} пройшло {ToSecSinceMidnight(time1)} секунд.");
      Console.WriteLine($"З півночі по {time2} пройшло {ToSecSinceMidnight(time2)} секунд.");
      Console.WriteLine();

      Console.WriteLine("Перевірка методу FromSecSinceMidnight:");
      int totalSeconds = 30000; // 8:20:00
      MyTime fromSeconds = FromSecSinceMidnight(totalSeconds);
      Console.WriteLine($"Перевівши час з опівночі з {totalSeconds} секунд у формат годинника, отримуємо {fromSeconds}");
      Console.WriteLine();

      Console.WriteLine("Перевірка методу AddOneSecond:");
      MyTime time3 = new MyTime(23, 59, 59);
      Console.WriteLine($"Час до додавання однієї секунди: {time3}");
      Console.WriteLine($"Час після додавання однієї секунди: {AddOneSecond(time3)}");
      Console.WriteLine();

      Console.WriteLine("Перевірка методу AddOneMinute:");
      MyTime time4 = new MyTime(14, 59, 30);
      Console.WriteLine($"Час до додавання однієї хвилини: {time4}");
      Console.WriteLine($"Час після додавання однієї хвилини: {AddOneMinute(time4)}");
      Console.WriteLine();


      Console.WriteLine("Перевірка методу AddOneHour:");
      MyTime time5 = new MyTime(23, 55, 29);
      Console.WriteLine($"Час до додавання однієї години: {time5}");
      Console.WriteLine($"Час після додавання однієї години: {AddOneHour(time5)}");
      Console.WriteLine();

      Console.WriteLine("Перевірка методу AddSeconds:");
      MyTime time6 = new MyTime(5, 30, 45);
      int secondsToAdd = 150;
      Console.WriteLine($"Час до додавання {secondsToAdd} секунд: {time6}");
      Console.WriteLine($"Час після додавання {secondsToAdd} секунд: {AddSeconds(time6, secondsToAdd)}");
      Console.WriteLine();

      Console.WriteLine("Перевірка методу IsInRange:");
      MyTime startTime = new MyTime(14, 0, 0);
      MyTime finishTime = new MyTime(10, 0, 0);
      MyTime checkTime = new MyTime(2, 30, 0);
      bool isInRange = IsInRange(startTime, finishTime, checkTime);
      if (isInRange)
      {
        Console.WriteLine($"{checkTime} знаходиться у діапазоні між {startTime} та {finishTime}");
      }
      else
      {
        Console.WriteLine($"{checkTime} не знаходиться у діапазоні між {startTime} та {finishTime}");
      }
      Console.WriteLine();

      Console.WriteLine("Перевірка методу Difference");
      MyTime time7 = new MyTime(1, 31, 56);
      MyTime time8 = new MyTime(23, 14, 04);
      int difference = Difference(time7, time8);
      Console.WriteLine($"Різниця між {time7} та {time8} - {difference} секунд, або ж {FromSecSinceMidnight(Math.Abs(difference))}");
      Console.WriteLine();

      Console.WriteLine("Перевірка метода WhatLesson:");
      MyTime time9;
      time9 = new MyTime(07, 33, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(8, 45, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(9, 24, 5);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(10, 35, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(11, 05, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(12, 16, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(12, 53, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(14, 10, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(14, 33, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(15, 33, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(16, 03, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(16, 13, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");
      time9 = new MyTime(17, 43, 0);
      Console.WriteLine($"{time9} - {WhatLesson(time9)}");

    }


  }
}
