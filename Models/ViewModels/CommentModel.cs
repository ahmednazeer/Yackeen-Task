using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yackeen.Models.ViewModels
{
    public class CommentModel
    {
        public DateTime PublishedAt { get; set; }
        public string CommentOwner { get; set; }
        public string CommentBody { get; set; }
    }
}