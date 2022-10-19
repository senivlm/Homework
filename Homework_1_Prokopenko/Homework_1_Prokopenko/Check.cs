using System.Text;

namespace Homework_1_Prokopenko;

public class Check
{
    public static void Display(Buy buy)
    {
        Console.WriteLine(buy.ToString());
    }

    public override string ToString()
    {
        return "Що повинен повертати цей метод якщо в класі немає жодних \"елементів-даних\"?)\nІ навіщо взагалі цей клас потрібен?";
    }
}