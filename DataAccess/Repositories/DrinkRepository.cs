using System.Collections.Generic;
using System.Linq;
using WebAutomat.DataAccess.EF;
using WebAutomat.DataAccess.Entity;
using WebAutomat.DataAccess.Interfaces;

namespace WebAutomat.DataAccess.Repositories
{
    public class DrinkRepository: IDrinkRepository //Репозиторий для напитков
    {
        public IEnumerable<Drink> Drinks
        {
            get
            {
                using (var context = new AutomatContext())
                    return context.Drinks.ToList();
            }
        }

        public Drink GetDrink(int drinkId)
        {
            using (var context = new AutomatContext())
            {
                return context.Drinks.Find(drinkId);
            }
        }

        public void AddDrink(Drink drink)
        {
            using (var context = new AutomatContext())
            {
                context.Drinks.Add(drink);
                context.SaveChanges();
            }
        }

        public void EditDrink(Drink drink)
        {
            using (var context = new AutomatContext())
            {
                Drink dbEntry = context.Drinks.Find(drink.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = drink.Name;
                    dbEntry.Cost = drink.Cost;
                    dbEntry.Count = drink.Count;
                    dbEntry.ImageData = drink.ImageData;
                    dbEntry.ImageType = drink.ImageType;
                    context.SaveChanges();
                }
            }
        }

        public Drink DeleteDrink(int drinkId)
        {
            using (var context = new AutomatContext())
            {
                Drink dbEntry = context.Drinks.Find(drinkId);
                if (dbEntry != null)
                {
                    context.Drinks.Remove(dbEntry);
                    context.SaveChanges();
                }
                return dbEntry;
            }
        }
    }
}