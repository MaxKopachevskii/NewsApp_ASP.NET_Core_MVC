using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_NewsApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string UserName { get; set; }
        public bool WasCheck { get; set; }
        public DateTime DateTime { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public Article()
        {
            WasCheck = false;
            DateTime = DateTime.Now;
        }
    }
}
