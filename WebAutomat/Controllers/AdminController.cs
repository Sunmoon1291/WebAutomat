using System.Web;
using System.Web.Mvc;
using WebAutomat.BusinessLogic.Interfaces;
using WebAutomat.DataAccess.Entity;
using WebAutomat.Infrastructure;
using WebAutomat.Models;

namespace WebAutomat.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IDrinkService DrinkService;
        private ICoinService CoinService;

        public AdminController(IDrinkService ds, ICoinService cs)
        {
            DrinkService = ds;
            CoinService = cs;
        }

        [Admin] //Фильтр в котором происходит аутентификация
        [AllowAnonymous]
        public ActionResult Index()
        {
            var drinks = DrinkService.GetAll();
            var coins = CoinService.GetAll();
            return View(new AutomatViewModel(coins, drinks, 0));
        }

        public ViewResult Edit(int Id) //Загрузка информации о напитке для редактирования
        {
            return View(DrinkService.GetDrink(Id));
        }

        [HttpPost]
        public ActionResult Edit(Drink drink, HttpPostedFileBase image = null) //Сохранение изменнеий по напитку
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    drink.ImageType = image.ContentType;
                    drink.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(drink.ImageData, 0, image.ContentLength);
                }
                TempData["message"] = DrinkService.SaveDrink(drink);
                return RedirectToAction("Index");
            }
            else
            {
                return View(drink);
            }
        }

        public ViewResult Create() //Создание напитка
        {
            return View("Edit", new Drink());
        }

        [HttpPost]
        public ActionResult Delete(int ID) //Удаление напитка
        {
            Drink deletedDrink = DrinkService.DeleteDrink(ID);
            if (deletedDrink != null)
            {
                TempData["message"] = string.Format("Напиток \"{0}\" был удален",
                    deletedDrink.Name.Trim());
            }
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int Id) //Получение изображения напитка по ID
        {
            return DrinkService.GetDrinkImage(Id);
        }

        public ActionResult EditCoin(int CoinId, int CoinCount, bool CoinBlock) //Сохранение изменений по монетам
        {
            CoinService.EditCoin(CoinId, CoinCount, CoinBlock);
            return RedirectToAction("Index");
        }
    }
}