using System;

struct MyTime
{
  public int hour, minute, second;

  public MyTime(int h, int m, int s)
  {
    hour = h;
    minute = m;
    second = s;
  }

  public override string ToString()
  {
    return $"{hour}:{minute:D2}:{second:D2}";
  }
}

class Program
{
  static void Main(string[] args)
  {
    System.Console.WriteLine("Перевірка методу ToSecSinceMidnight:");
    MyTime time1 = new MyTime(10, 30, 15);
    MyTime time2 = new MyTime(5, 45, 20);
    Console.WriteLine($"З півночі по {time1} пройшло {ToSecSinceMidnight(time1)} секунд.");
    Console.WriteLine($"З півночі по {time2} пройшло {ToSecSinceMidnight(time2)} секунд.");
    System.Console.WriteLine();

    System.Console.WriteLine("Перевірка методу FromSecSinceMidnight:");
    int totalSeconds = 30000; // 8:20:00
    MyTime fromSeconds = FromSecSinceMidnight(totalSeconds);
    Console.WriteLine($"Перевівши час з опівночі з {totalSeconds} секунд у формат годинника, отримуємо {fromSeconds}");
    System.Console.WriteLine();

    System.Console.WriteLine("Перевірка методу AddOneSecond:");
    MyTime time3 = new MyTime(23, 59, 59);
    System.Console.WriteLine($"Час до додавання однієї секунди: {time3}");
    System.Console.WriteLine($"Час після додавання однієї секунди: {AddOneSecond(time3)}");
    System.Console.WriteLine();

    System.Console.WriteLine("Перевірка методу AddOneMinute:");
    MyTime time4 = new MyTime(14, 59, 30);
    System.Console.WriteLine($"Час до додавання однієї хвилини: {time4}");
    System.Console.WriteLine($"Час після додавання однієї хвилини: {AddOneMinute(time4)}");
    System.Console.WriteLine();


    System.Console.WriteLine("Перевірка методу AddOneHour:");
    MyTime time5 = new MyTime(23, 55, 29);
    System.Console.WriteLine($"Час до додавання однієї години: {time5}");
    System.Console.WriteLine($"Час після додавання однієї години: {AddOneHour(time5)}");
    System.Console.WriteLine();

    System.Console.WriteLine("Перевірка методу AddSeconds:");
    MyTime time6 = new MyTime(5, 30, 45);
    int secondsToAdd = 150;
    System.Console.WriteLine($"Час до додавання {secondsToAdd} секунд: {time6}");
    System.Console.WriteLine($"Час після додавання {secondsToAdd} секунд: {AddSeconds(time6, secondsToAdd)}");
    System.Console.WriteLine();

    System.Console.WriteLine("Перевірка методу IsInRange:");
    MyTime startTime = new MyTime(14, 0, 0);
    MyTime finishTime = new MyTime(10, 0, 0);
    MyTime checkTime = new MyTime(2, 30, 0);
    bool isInRange = IsInRange(startTime, finishTime, checkTime);
    if (isInRange)
    {
      System.Console.WriteLine($"{checkTime} знаходиться у діапазоні між {startTime} та {finishTime}");
    }
    else
    {
      System.Console.WriteLine($"{checkTime} не знаходиться у діапазоні між {startTime} та {finishTime}");
    }
    System.Console.WriteLine();

    System.Console.WriteLine("Перевірка методу Difference");
    MyTime time7 = new MyTime(1, 31, 56);
    MyTime time8 = new MyTime(23, 14, 04);
    int difference = Difference(time7, time8);
    System.Console.WriteLine($"Різниця між {time7} та {time8} - {difference} секунд, або ж {FromSecSinceMidnight(Math.Abs(difference))}");
    System.Console.WriteLine();

    System.Console.WriteLine("Перевірка метода WhatLesson:");
    MyTime time9;
    time9 = new MyTime(07, 33, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(8, 45, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(9, 24, 5);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(10, 35, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(11, 05, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(12, 16, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(12, 53, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(14, 10, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(14, 33, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(15, 33, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(16, 03, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(16, 13, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");
    time9 = new MyTime(17, 43, 0);
    System.Console.WriteLine($"{time9} - {WhatLesson(time9)}");

  }

  static int ToSecSinceMidnight(MyTime t)
  {
    return t.hour * 3600 + t.minute * 60 + t.second;
  }

  static MyTime FromSecSinceMidnight(int t)
  {
    const int secPerDay = 60 * 60 * 24;
    t %= secPerDay;

    if (t < 0)
      t += secPerDay;
    int h = t / 3600;
    int m = t / 60 % 60;
    int s = t % 60;
    return new MyTime(h, m, s);
  }

  static MyTime AddOneSecond(MyTime t)
  {
    return AddSeconds(t, 1);
  }

  static MyTime AddOneMinute(MyTime t)
  {
    t.minute++;
    if (t.minute == 60)
    {
      t.minute = 0;
      t.hour++;
      if (t.hour == 24)
      {
        t.hour = 0;
      }
    }
    return t;
  }


  static MyTime AddOneHour(MyTime t)
  {
    t.hour++;
    if (t.hour == 24)
    {
      t.hour = 0;
    }
    return t;
  }


  static MyTime AddSeconds(MyTime t, int s)
  {
    int totalSeconds = t.hour * 3600 + t.minute * 60 + t.second;

    totalSeconds += s;

    int newHour = totalSeconds / 3600 % 24;
    int newMinute = totalSeconds % 3600 / 60;
    int newSecond = totalSeconds % 60;

    return new MyTime(newHour, newMinute, newSecond);
  }


  static int Difference(MyTime t1, MyTime t2)
  {
    int totalSeconds1 = t1.hour * 3600 + t1.minute * 60 + t1.second;
    int totalSeconds2 = t2.hour * 3600 + t2.minute * 60 + t2.second;

    int difference = totalSeconds1 - totalSeconds2;

    return difference;
  }


  static bool IsInRange(MyTime start, MyTime finish, MyTime t)
  {
    if (start.hour <= finish.hour)
    {
      if ((t.hour > start.hour && t.hour < finish.hour) ||
          (t.hour == start.hour && t.minute > start.minute) ||
          (t.hour == start.hour && t.minute == start.minute && t.second >= start.second) ||
          (t.hour == finish.hour && t.minute < finish.minute) ||
          (t.hour == finish.hour && t.minute == finish.minute && t.second < finish.second))
      {
        return true;
      }

    }
    else
    {
      if ((t.hour > start.hour || t.hour < finish.hour) ||
          (t.hour == finish.hour && t.minute < finish.minute) ||
          (t.hour == finish.hour && t.minute == finish.minute && t.second < finish.second) ||
          (t.hour == start.hour && t.minute > start.minute) ||
          (t.hour == start.hour && t.minute == start.minute && t.second >= start.second))
      {
        return true;
      }
    }
    return false;
  }

  static string WhatLesson(MyTime mt)
  {
    MyTime[] lessonsStart = {
        new MyTime(8, 0, 0),
        new MyTime(9, 40, 0),
        new MyTime(11, 20, 0),
        new MyTime(13, 0, 0),
        new MyTime(14, 40, 0),
        new MyTime(16, 10, 0)
    };

    MyTime[] lessonsEnd = {
        new MyTime(9, 20, 0),
        new MyTime(11, 0, 0),
        new MyTime(12, 40, 0),
        new MyTime(14, 20, 0),
        new MyTime(16, 0, 0),
        new MyTime(17, 30, 0)
    };

    if (Difference(mt, lessonsStart[0]) < 0)
    {
      return "пари ще не почались";
    }

    if (IsInRange(lessonsStart[0], lessonsEnd[0], mt))
    {
      return "1-а пара";
    }

    for (int i = 1; i < lessonsStart.Length; i++)
    {
      if (IsInRange(lessonsStart[i], lessonsEnd[i], mt))
      {
        return $"{i + 1}-а пара";
      }

      if (IsInRange(lessonsEnd[i - 1], lessonsStart[i], mt))
      {
        return $"перерва між {i}-ою та {i + 1}-ою парами";
      }
    }

    return "пари вже кінчилися";
  }

}
