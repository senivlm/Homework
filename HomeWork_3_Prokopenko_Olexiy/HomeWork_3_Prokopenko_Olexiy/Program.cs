using HomeWork_3_Prokopenko_Olexiy;
using HomeWork_3_Prokopenko_Olexiy.Enums;

var storage = new Storage(new List<Product>
{
   new Meat("Pork", 100, 1000, MeetCategories.TopGrade, MeetKinds.Pork),
   new Dairy_products("Milk", 30, 2000, 7),
   new Meat("Chicken", 80, 700, MeetCategories.FirstGrade, MeetKinds.Chicken)
});
storage.ChangePrice(10);
storage.PrintAllProduct();