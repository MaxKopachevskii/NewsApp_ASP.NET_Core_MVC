using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_NewsApp.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Путь к изображению")]
        public string Img { get; set; }

        [Display(Name = "Краткое описание статьи")]
        public string ShortDesc { get; set; }

        [Display(Name = "Основной контент статьи")]
        [DataType(DataType.MultilineText)]
        public string LongDesc { get; set; }

        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Display(Name = "Было проверено менеджером")]
        public bool WasCheck { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Номер категории")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Article()
        {
            WasCheck = false;
            DateTime = DateTime.Now;
        }
    }
}
