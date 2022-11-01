using System.Threading.Channels;
using Homework_1_Prokopenko;
// Вітаю. Все доступно.

var allProducts = new List<Product>
{
    new("Orange", 20, 300),
    new("Cucumber", 50, 500)
};
var buy = new Buy();
buy.Products.Add(allProducts[0], 3);
buy.Products.Add(allProducts[1], 2);
Check.Display(buy);
Check check = new Check();
// явний виклик методу переведення в стрічку можна не писати.
Console.WriteLine(check.ToString());
