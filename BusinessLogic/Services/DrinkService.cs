using System.Collections.Generic;
using System.Web.Mvc;
using WebAutomat.BusinessLogic.Interfaces;
using WebAutomat.DataAccess.Entity;
using WebAutomat.DataAccess.Interfaces;

namespace WebAutomat.BusinessLogic.Services
{
    public class DrinkService: IDrinkService
    {
        IDrinkRepository Repos;

        public DrinkService(IDrinkRepository r)
        {
            Repos = r;
        }

        public IEnumerable<Drink> GetAll()
        {
            return Repos.Drinks;
        }

        public string SaveDrink(Drink drink) //Сохранение изменений по напитку
        {
            if (drink.ID == 0) //Если ID = 0, то напиток добавляется, иначе редактируется
            {
                Repos.AddDrink(drink);
                return string.Format("Добавлен напиток \"{0}\"", drink.Name.Trim());
            }
            else
            {
                Repos.EditDrink(drink);
                return string.Format("Изменения в напитке \"{0}\" были сохранены", drink.Name.Trim());
            }
        }

        public Drink DeleteDrink(int drinkId) //Удаление напитка
        {
            return Repos.DeleteDrink(drinkId);
        }

        public void DecCount(int DringId) //Уменьшение кол-ва напитка на 1
        {
            Drink drink = Repos.GetDrink(DringId);
            if (drink != null)
            {
                drink.Count -= 1;
                Repos.EditDrink(drink);
            }
        }

        public int GetCost(int DringId) //Получение стоимости напитка
        {
            Drink drink = Repos.GetDrink(DringId);
            if (drink != null)
            {
                return drink.Cost;
            }
            else
                return -1;
        }

        public FileContentResult GetDrinkImage(int DringId) //Получение изображения напитка по ID
        {
            Drink drink = Repos.GetDrink(DringId);

            if ((drink != null) && (drink.ImageData != null))
            {
                return new FileContentResult(drink.ImageData, drink.ImageType);
            }
            else
            {
                return null;
            }
        }

        public int BuyDrink(int DringId) //Получение напитка
        {
            Drink drink = Repos.GetDrink(DringId);
            if (drink != null)
            {
                if (drink.Count > 0)
                {
                    drink.Count -= 1;
                    Repos.EditDrink(drink);
                }
                return drink.Cost;
            }
            else
                return -1;
        }

        public Drink GetDrink(int DringId) //Получение напитка по ID
        {
            return Repos.GetDrink(DringId);
        }
    }
}