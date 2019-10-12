using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yackeen.Models
{
    public class Comment
    {
        public int ID { get; set; }
        //public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public int ArticleID { get; set; }
        public string Username { get; set; }
        /*
        public virtual Article Article { get; set; }
        public virtual User User { set; get; }
        */

    }
}