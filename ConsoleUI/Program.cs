using System;
using System.Reflection.Metadata.Ecma335;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
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
            // GetCarDetails();
            // UserTest();
            // ColorTest();
            // CustomerTest();

            var rentalManager = new RentalManager(new EfRentalDal());
            var rental = new Rental
            {
                CarId = 3,
                RentDate = new DateTime(2021, 08, 08)
            };
            var result = rentalManager.Add(rental);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            var colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 4, ColorName = "Gray" });
            // colorManager.Update(new Color{ColorId = 4, ColorName = "DarkGray"});
            // colorManager.Delete(new Color{ColorId = 4});
        }

        private static void UserTest()
        {
            var userManager = new UserManager(new EfUserDal());
            var user = new User
            {
                UserId = 1,
                FirstName = "Kadir",
                LastName = "Kiras",
                Email = "123@outlook.com",
                Password = "123pwd"
            };
            userManager.Add(user);
            // userManager.Update(new User { UserId = 1, FirstName = "Kadirr" });
            // userManager.Delete(new User { UserId = 1 });
        }

        private static void CustomerTest()
        {
            var customerManager = new CustomerManager(new EfCustomerDal());

            var customer = new Customer
            {
                CustomerId = 1,
                UserId = 1,
                CompanyName = "Kiralama Şirketi"
            };

            customerManager.Add(customer);
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"{car.CarName} / {car.BrandName}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AllTest()
        {
            Console.WriteLine("------Brands------");

            var brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 1, BrandName = "BMW" });
            brandManager.Add(new Brand { BrandId = 2, BrandName = "Mercedes" });
            brandManager.Add(new Brand { BrandId = 3, BrandName = "Volvo" });
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine($"{brand.BrandId} {brand.BrandName}");
            }

            Console.WriteLine("------Colors------");

            var colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 1, ColorName = "Black" });
            colorManager.Add(new Color { ColorId = 2, ColorName = "Red" });
            colorManager.Add(new Color { ColorId = 3, ColorName = "White" });

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

            // foreach (var car in carManager.GetAll())
            // {
            //     Console.WriteLine(
            //         $"Id: {car.CarId} CarName: {car.CarName} BrandId: {car.BrandId} ColorId: {car.ColorId} DailyPrice: {car.DailyPrice}");
            // }
        }
    }
}