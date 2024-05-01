using System;
using System.Text;

namespace Lab5
{
  public partial class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = UTF8Encoding.UTF8;
      int choice;
      bool txtExists, xmlExists, jsonExists;

      do
      {
        int counter = 0;
        System.Console.WriteLine($"[{counter}] <- вихід");
        counter++;
        System.Console.WriteLine($"[{counter}] - записати структуру в txt файл");
        counter++;

        System.Console.WriteLine($"[{counter}] - серіалізувати структуру в XML");
        counter++;
        System.Console.WriteLine($"[{counter}] - серіалізувати структуру в JSON");
        counter++;

        if (File.Exists("Orders.txt"))
        {
          System.Console.WriteLine($"[{counter}] - прочитати структуру з txt файла");
          counter++;
          txtExists = true;
        }
        else
        {
          txtExists = false;
        }
        if (File.Exists("Orders.xml"))
        {
          System.Console.WriteLine($"[{counter}] - десеріалізувати структуру з XML");
          xmlExists = true;
          counter++;
        }
        else
        {
          xmlExists = false;
        }
        if (File.Exists("Orders.json"))
        {
          System.Console.WriteLine($"[{counter}] - десеріалізувати структуру з JSON");
          jsonExists = true;
          counter++;
        }
        else
        {
          jsonExists = false;
        }
        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
          case 1:
            WriteOrdersIntoTXT(EnterOrders(),"Orders.txt");
            break;
          case 2:
            SerializeOrdersIntoXML(EnterOrders(),"Orders.xml");
            break;
          case 3:
          SerializeOrdersIntoJson(EnterOrders(),"Orders.json");
            break;
          default:
            System.Console.WriteLine();
            break;
        }

        if (txtExists && !xmlExists && !jsonExists)
        {
          switch (choice)
          {
            case 4:
              ReadOrdersFromTXT("Orders.txt");
              break;
            default:
              System.Console.WriteLine();
              break;
          }
        }
        if (xmlExists && !txtExists && !jsonExists)
        {
          switch (choice)
          {
            case 4:
              DeserializeOrdersFromXml("Orders.xml");
              break;
            default:
              System.Console.WriteLine();
              break;
          }
        }
        if (jsonExists && !txtExists && !xmlExists)
        {
          switch (choice)
          {
            case 4:
              DeserializeOrdersFromJson("Orders.json");
              break;
            default:
              System.Console.WriteLine();
              break;
          }
        }
        if (txtExists && xmlExists && !jsonExists)
        {
          switch (choice)
          {
            case 4:
              ReadOrdersFromTXT("Orders.txt");
              break;

            case 5:
              DeserializeOrdersFromXml("Orders.xml");
              break;

            default:
              System.Console.WriteLine();
              break;

          }
        }
        if (txtExists && jsonExists && !xmlExists)
        {
          switch (choice)
          {
            case 4:
              ReadOrdersFromTXT("Orders.txt");
              break;
            case 5:
              DeserializeOrdersFromJson("Orders.json");
              break;

            default:
              System.Console.WriteLine();
              break;
          }
        }
        if (xmlExists && jsonExists && !txtExists)
        {
          switch (choice)
          {
            case 4:
              DeserializeOrdersFromXml("Orders.xml");
              break;
            case 5:
              DeserializeOrdersFromJson("Orders.json");
              break;
          }
        }
        if (txtExists && xmlExists && jsonExists)
        {
          switch (choice)
          {
            case 4:
              ReadOrdersFromTXT("Orders.txt");
              break;

            case 5:
              DeserializeOrdersFromXml("Orders.xml");
              break;
            case 6:
              DeserializeOrdersFromJson("Orders.json");
              break;
            default:
              System.Console.WriteLine();
              break;


          }
        }






      } while (choice != 0);
    }
  }

}
