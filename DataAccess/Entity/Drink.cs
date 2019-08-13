using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAutomat.DataAccess.Entity
{
    public class Drink
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = "Стоимость")]
        [Required(ErrorMessage = "Пожалуйста, введите стоимость напитка")]
        [Range(0, int.MaxValue, ErrorMessage = "Пожалуйста, введите неотрицательное значение стоимости")]
        public int Cost { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название напитка")]
        public string Name { get; set; }

        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Пожалуйста, введите количество напитка")]
        [Range(0, int.MaxValue, ErrorMessage = "Пожалуйста, введите неотрицательное значение количества")]
        public int Count { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
    }
}