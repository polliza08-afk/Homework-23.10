using System;

namespace CarDisplayApp
{
    //Сигнатура делегата для виведення інформації
    public delegate void DisplayHandler(string message);

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        //Приватне поле для зберігання делегата дисплея
        private DisplayHandler _displayDelegate;
        public Car(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        //Метод для динамічного встановлення дисплея після створення автомобіля
        public void SetDisplayDelegate(DisplayHandler displayDelegate)
        {
            _displayDelegate = displayDelegate;
            _displayDelegate?.Invoke($"[Дисплей активовано] Авто: {Brand} {Model} ({Year})");
        }

        //Метод для симуляції поїздки та виведення даних на дисплей
        public void Drive(int speed)
        {
            string info = $"Поточна швидкість: {speed} км/год";

            if (_displayDelegate != null)
            {
                _displayDelegate.Invoke(info);
            }
            else
            {
                Console.WriteLine("(Дисплей відсутній. Інформація не виводиться)");
            }
        }
    }

    //Клас, що імітує роботу бортового дисплея
    public class CarDisplay
    {
        public void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"---Бортовий дисплей---");
            Console.WriteLine($"{message}");
            Console.WriteLine($"-------------------------");
            Console.ResetColor();
        }
    }
}