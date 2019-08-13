using WebAutomat.BusinessLogic.Interfaces;
using System.Web.Mvc;
using WebAutomat.Models;
using System.Collections.Generic;

namespace WebAutomat.Controllers
{
    public class DrinksController : Controller
    {
        private IDrinkService DrinkService;
        private ICoinService CoinService;

        public DrinksController(IDrinkService ds, ICoinService cs)
        {
            DrinkService = ds;
            CoinService = cs;
        }

        public ActionResult Index()
        {
            var drinks = DrinkService.GetAll();
            var coins = CoinService.GetAll();
            return View(new AutomatViewModel(coins, drinks, GetTotal()));
        }

        public FileContentResult GetImage(int Id) //Получение изображения напитка по ID
        {
            return DrinkService.GetDrinkImage(Id);
        }

        public ActionResult AddCoin(int CoinId) //Добавление монеты
        {
            int cost = CoinService.AddCoin(CoinId);
            ChangeTotal(cost);

            return RedirectToAction("Index");
        }

        public ActionResult GetDrink(int DrinkId) //Покупка напитка
        {
            int cost = DrinkService.BuyDrink(DrinkId);
            if (cost > 0)
            {
                ChangeTotal(-cost);
            }

            return RedirectToAction("Index");
        }

        public ActionResult GetChange() //Возврат сдачи
        {
            Dictionary<string, int> dict = CoinService.GetChange(GetTotal());
            int total = dict["$remain"];
            dict.Remove("$remain");
            SetTotal(total);
            var change = new ChangeViewModel();
            change.Status = total == 0 ? 1 : 0;
            change.Wallet = dict;

            TempData["message"] = change;

            return RedirectToAction("Index");
        }

        int GetTotal() //Получение веденной пользователем суммы из сессии
        {
            if (Session["Total"] != null)
                return (int)Session["Total"];
            else
                return 0;
        }

        void ChangeTotal(int diff) //Изменение веденной пользователем суммы на сумму diff
        {
            Session["Total"] = GetTotal() + diff;
        }

        void SetTotal(int total) //Изменение веденной пользователем суммы
        {
            Session["Total"] = total;
        }
    }
}