using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // AllTest();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"Model:{car.CarName} - Brand:{car.BrandName} - Color:{car.ColorName} - DailyPrice:{car.DailyPrice}");
            }
        }

        private static void AllTest()
        {
            Console.WriteLine("------Brands------");

            var brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand {BrandId = 1, BrandName = "BMW"});
            brandManager.Add(new Brand {BrandId = 2, BrandName = "Mercedes"});
            brandManager.Add(new Brand {BrandId = 3, BrandName = "Volvo"});

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.BrandId} {brand.BrandName}");
            }

            Console.WriteLine("------Colors------");

            var colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color {ColorId = 1, ColorName = "Black"});
            colorManager.Add(new Color {ColorId = 2, ColorName = "Red"});
            colorManager.Add(new Color {ColorId = 3, ColorName = "White"});

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.ColorId} {color.ColorName}");
            }

            Console.WriteLine("------Cars------");

            var carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                CarId = 1, BrandId = 1, CarName = "iX3", ColorId = 1, DailyPrice = 400, ModelYear = 2021,
                Description = "Lorem ipsum dolor sit amet"
            });
            carManager.Add(new Car
            {
                CarId = 2, BrandId = 2, CarName = "A 200 AMG", ColorId = 2, DailyPrice = 600, ModelYear = 2021,
                Description = "Lorem ipsum dolor sit amet"
            });
            carManager.Add(new Car
            {
                CarId = 3, BrandId = 3, CarName = "Volvo XC90 Recharge", ColorId = 3, DailyPrice = 1100,
                ModelYear = 2021,
                Description = "Lorem ipsum dolor sit amet"
            });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(
                    $"Id: {car.CarId} CarName: {car.CarName} BrandId: {car.BrandId} ColorId: {car.ColorId} DailyPrice: {car.DailyPrice}");
            }
        }
    }
}