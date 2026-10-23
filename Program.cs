// See https://aka.ms/new-console-template for more information
using CarDisplayApp;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("---Створення автомобіля---");
Console.Write("Введіть марку: ");
string brand = Console.ReadLine();

Console.Write("Введіть модель: ");
string model = Console.ReadLine();

Console.Write("Введіть рік випуску: ");
int year = int.Parse(Console.ReadLine());

//Створюємо новий автомобіль
Car myCar = new Car(brand, model, year);
Console.WriteLine($"\nАвтомобіль {myCar.Brand} {myCar.Model} успішно створено!\n");

//Питаємо про наявність дисплея
Console.Write("Чи бажаєте встановити дисплей?: ");
string hasDisplay = Console.ReadLine().Trim().ToLower();

if (hasDisplay == "так" || hasDisplay == "yes" || hasDisplay == "т")
{
    //Створюємо дисплей та підключаємо через делегат
    CarDisplay dashboardDisplay = new CarDisplay();
    myCar.SetDisplayDelegate(dashboardDisplay.ShowMessage);
}
else
{
    Console.WriteLine("Автомобіль працює без дисплея.");
}

//Тестуємо рух
Console.WriteLine("\n---Тестування руху---");
myCar.Drive(30);
myCar.Drive(75);
myCar.Drive(110);