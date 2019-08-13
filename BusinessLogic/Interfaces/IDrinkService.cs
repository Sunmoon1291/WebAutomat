using System.Collections.Generic;
using System.Web.Mvc;
using WebAutomat.DataAccess.Entity;

namespace WebAutomat.BusinessLogic.Interfaces
{
    public interface IDrinkService
    {
        IEnumerable<Drink> GetAll();
        string SaveDrink(Drink drink); //Сохранение изменений по напитку
        Drink DeleteDrink(int drinkId); //Удаление напитка
        void DecCount(int DringId); //Уменьшение кол-ва напитка на 1
        int GetCost(int DringId); //Получение стоимости напитка
        FileContentResult GetDrinkImage(int DringId); //Получение изображения напитка по ID
        int BuyDrink(int DringId); //Покупка напитка
        Drink GetDrink(int DringId); //Получение напитка по ID
    }
}
