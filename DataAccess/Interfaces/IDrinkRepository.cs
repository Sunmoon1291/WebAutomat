using System.Collections.Generic;
using WebAutomat.DataAccess.Entity;

namespace WebAutomat.DataAccess.Interfaces
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> Drinks { get; }

        Drink GetDrink(int drinkId);

        void AddDrink(Drink drink);

        void EditDrink(Drink drink);

        Drink DeleteDrink(int drinkId);
    }
}
