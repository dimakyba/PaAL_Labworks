namespace Lab4
{

  struct MyTime
  {
    public int hour, minute, second;

    public MyTime(int h, int m, int s)
    {
      hour = h;
      minute = m;
      second = s;
    }
    public MyTime(string time)
    {
      string[] parts = time.Split(':');
      hour = int.Parse(parts[0]);
      minute = int.Parse(parts[1]);
      second = int.Parse(parts[2]);
    }


    public override string ToString()
    {
      return $"{hour}:{minute:D2}:{second:D2}";
    }
  }
}
