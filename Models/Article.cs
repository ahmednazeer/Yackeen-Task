using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yackeen.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishingDate { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}