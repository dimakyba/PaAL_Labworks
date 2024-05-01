using System.Text;
using System.Text.Json;
using System.Xml.Serialization;


namespace Lab5
{
  public partial class Program
  {
    static List<Order> EnterOrders()
    {
      List<Order> orders = [];
      System.Console.Write("Введіть кількість структур, які ви хочете ввести: ");

      int n = int.Parse(Console.ReadLine());

      System.Console.WriteLine("Приклад правильного введення структури: account1 account2 1231231");
      System.Console.WriteLine("Введіть структури:");
      for (int i = 0; i < n; i++)
      {
        System.Console.Write($"{i + 1}) ");
        orders.Add(new(Console.ReadLine()));

      }

      // should i return sorted list?
      orders.Sort();
      return orders;
    }

    static void WriteOrdersIntoTXT(List<Order> orders, string filename)
    {

      using (StreamWriter sw = new(filename))
      {
        foreach (var order in orders)
        {
          sw.WriteLine($"{order.SenderAccount} {order.ReceiverAccount} {order.SumInCents}");
        }
      }
      System.Console.WriteLine("Done!");
    }

    static void ReadOrdersFromTXT(string filename)
    {
      List<Order> orders = [];
      try
      {
        StreamReader reader = new(filename);
        string? line;
        while ((line = reader.ReadLine()) != null)
          orders.Add(new(line));
      }
      catch (IOException e) { Console.WriteLine($"idk -> {e.Message}"); }
      System.Console.WriteLine("Структури, прочитані з TXT:");
      foreach (var order in orders)
      {
        System.Console.WriteLine(order);
      }
    }

    static void SerializeOrdersIntoXML(List<Order> orders, string filename)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));
      using (TextWriter writer = new StreamWriter(filename))
      {
        serializer.Serialize(writer, orders);
      }
      System.Console.WriteLine("Done!");
    }


    static void DeserializeOrdersFromXml(string filename)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Order[]));
      using (FileStream fileStream = new FileStream(filename, FileMode.Open))
      {
        var deserializedOrders = (Order[])serializer.Deserialize(fileStream);

        System.Console.WriteLine("Десереалізовані з XML структури:");
        foreach (var order in deserializedOrders)
        {
          System.Console.WriteLine(order);
        }
      }
    }


    static void SerializeOrdersIntoJson(List<Order> orders, string filename)
    {
      JsonSerializerOptions options = new JsonSerializerOptions
      {
        WriteIndented = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
      };

      File.WriteAllText("Orders.json", JsonSerializer.Serialize(orders, options), Encoding.UTF8);
      System.Console.WriteLine("Done!");
    }

    static void DeserializeOrdersFromJson(string filename)
    {
      var deserializedOrders = JsonSerializer.Deserialize<Order[]>(File.ReadAllText(filename));

      System.Console.WriteLine("Десереалізовані з JSON структури:");
      foreach (var order in deserializedOrders)
      {
        System.Console.WriteLine(order);
      }
    }



  }
}
