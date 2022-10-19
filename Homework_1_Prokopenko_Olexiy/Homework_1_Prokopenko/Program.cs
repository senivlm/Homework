using System.Threading.Channels;
using Homework_1_Prokopenko;

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
Console.WriteLine(check.ToString());