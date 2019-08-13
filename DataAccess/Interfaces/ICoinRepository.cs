using System.Collections.Generic;
using WebAutomat.DataAccess.Entity;

namespace WebAutomat.DataAccess.Interfaces
{
    public interface ICoinRepository
    {
        IEnumerable<Coin> Coins { get; }

        IEnumerable<Coin> CoinsDesc { get; }

        Coin GetCoin(int coinId);

        void AddCoin(Coin coin);

        void EditCoin(Coin coin);

        Coin DeleteCoin(int coinId);
    }
}