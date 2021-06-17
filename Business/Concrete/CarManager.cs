using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Add(Car car)
        {
            // Standart Versiyon
            // if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            // {
            //     _carDal.Add(car);
            //     Console.WriteLine($"Kayit Basarili");
            // }else
            // {
            // Console.WriteLine("Araba ismi minimum 2 karakterli olmali & Gunluk ucreti ise 0`dan buyuk olmalidir!");
            // }
            // Alternatif version
            if (car.CarName.Length < 2 && car.DailyPrice <= 0) return;
            _carDal.Add(car);
            Console.WriteLine($"{car.CarName} Isimli Arac: Kayit Basarili");
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public void Delete(Car car)
        {
            _carDal.Update(car);
        }
    }
}