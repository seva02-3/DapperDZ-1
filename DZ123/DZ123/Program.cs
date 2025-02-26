using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Dapper;
using DZ123;
using Microsoft.Data.SqlClient;


class Program
{
    private static string connectionString = "Data Source=localhost;Initial Catalog=CarsDB;Integrated Security=True;TrustServerCertificate=True";
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        CarsService carsService = new CarsService();
        
        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Добавить машину");
            Console.WriteLine("2 - Обновить цену машины");
            Console.WriteLine("3 - Удалить машину");
            Console.WriteLine("4 - Вывести всех машин");
            Console.WriteLine("5 - Вывести список машин по бренду");
            Console.WriteLine("6 - Выйти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите бренд: ");
                    string brand = Console.ReadLine();

                    Console.Write("Введите модель: ");
                    string model = Console.ReadLine();

                    Console.Write("Введите год выпуска: ");
                    int year = int.Parse(Console.ReadLine());

                    Console.Write("Введите цену: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    carsService.AddCar(new Car { Brand = brand, Model = model, Year = year, Price = price });
                    break;

                case "2":
                    Console.Write("Введите ID машины: ");
                    int carUpdate = int.Parse(Console.ReadLine());

                    Console.Write("Введите новую цену: ");
                    decimal newPrice = decimal.Parse(Console.ReadLine());

                    carsService.UpdateCar(carUpdate, newPrice);
                    break;

                case "3":
                    Console.Write("Введите ID машины для удаления: ");
                    int carDelete = int.Parse(Console.ReadLine());

                    carsService.DeleteCar(carDelete);
                    break;

                case "4":
                    carsService.PrintCars();
                    break;

                case "5":
                    Console.Write("Введите бренд: ");
                    string brandf = Console.ReadLine();
                    
                    carsService.PrintCarsByBrand(brandf);
                    break;

                case "6":
                    Console.WriteLine("Выход");
                    return;
            }
        }
    }
}