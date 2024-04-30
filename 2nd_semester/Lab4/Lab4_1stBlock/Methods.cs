namespace Lab4
{
  public partial class Program
  {
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
      int startSec = ToSecSinceMidnight(start);
      int finishSec = ToSecSinceMidnight(finish);
      int currentSec = ToSecSinceMidnight(t);
      if (finishSec < startSec)
      {
        finishSec += 24 * 60 * 60;
      }

      return currentSec >= startSec && currentSec < finishSec;

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
}
