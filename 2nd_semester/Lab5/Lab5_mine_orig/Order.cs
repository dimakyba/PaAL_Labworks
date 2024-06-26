using System.Xml.Serialization;

namespace Lab5
{
  [Serializable]
  public struct Order : IComparable<Order>
  {
    [XmlElement]
    public string SenderAccount { get; set; }
    [XmlElement]
    public string ReceiverAccount { get; set; }
    [XmlElement]
    public decimal SumInCents { get; set; }

    public Order(string senderAccount, string receiverAccount, decimal sumInCents)
    {
      SenderAccount = senderAccount;
      ReceiverAccount = receiverAccount;
      SumInCents = sumInCents;
    }

    public Order(string input)
    {
      string[] fields = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
      SenderAccount = fields[0];
      ReceiverAccount = fields[1];
      SumInCents = decimal.Parse(fields[2]);
    }

    public override string ToString()
    {
      return $"Sender: {SenderAccount}\nReceiver: {ReceiverAccount}\nSum of transaction: {CentsToHrn(SumInCents)}\n";
    }

    public int CompareTo(Order order)
    {
      return string.Compare(this.SenderAccount, order.SenderAccount, StringComparison.Ordinal);
    }
    public string CentsToHrn(decimal cents)
    {
      cents /= 100;
      var hrn = Math.Floor(cents);
      int kop = (int)(cents % 1 * 100);

      return $"{hrn} грн {kop} коп";
    }
  }
}
