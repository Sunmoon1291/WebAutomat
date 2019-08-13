using System.Collections.Generic;
using WebAutomat.DataAccess.Entity;

namespace WebAutomat.Models
{
    public class AutomatViewModel
    {
        public AutomatViewModel(IEnumerable<Coin> C, IEnumerable<Drink> D, int T)
        {
            Coins = C;
            Drinks = D;
            Total = T;
        }
        public IEnumerable<Coin> Coins
        { get; set; }

        public IEnumerable<Drink> Drinks
        { get; set; }

        public int Total
        { get; set; }
    }
}