using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_NewsApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Название категории")]
        public string Name { get; set; }
        public virtual IEnumerable<Article> Articles { get; set; }

        public Category()
        {
            Articles = new List<Article>();
        }
    }
}
