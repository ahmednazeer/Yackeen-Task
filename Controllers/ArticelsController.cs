using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yackeen.Models;
using Yackeen.Models.ViewModels;

namespace Yackeen.Controllers
{
    [HandleError]
    [Authorize]
    public class ArticelsController : Controller
    {
        private ApplicationDbContext context;
        private int selectedCat_ID;
        public ArticelsController()
        {
            context = new ApplicationDbContext();
        }    
        // GET: Articels
        public ActionResult Index()
        {
            ViewBag.CategoryID = new SelectList(context.Categories, "ID", "Name");

            if (selectedCat_ID != 0)
            {
                var articles = context.Articles.Where(ar => ar.CategoryID == selectedCat_ID).ToList();
                return View(articles);

            }
            else
            {
                var articles = context.Articles.ToList();
                return View(articles);

            }
            //var cats = context.Categories.ToList();
            /*
             * ViewBag.CategoryID = new SelectList(context.Categories, "ID", "Name");
            return View();
            */
        }

        [HttpPost]
        public ActionResult SearchType(FormCollection form)
        {
            int.TryParse(form["CategoryID"].ToString(), out selectedCat_ID);
            return RedirectToAction("index");
            
        }

        public ActionResult GetArticles()
        {
            if (selectedCat_ID != 0)
            {
                var articles = context.Articles.Where(ar => ar.CategoryID == selectedCat_ID).ToList();
                return PartialView(articles);

            }
            else
            {
                var articles = context.Articles.ToList();
                return PartialView(articles);

            }

            //return PartialView(articles);
        }
        [Authorize(Roles ="admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(context.Categories, "ID", "Name");
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Article model)
        {
            model.PublishingDate = DateTime.Now;
            context.Articles.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Session["id"] = id;
            //if (id == null)
                id = int.Parse(Session["id"].ToString());//= id;
            var article= context.Articles.SingleOrDefault(ar => ar.ID == id);
            if(article!=null)
                return View(article);
            else {
                return HttpNotFound();
            }
        }

        public ActionResult GetComments()
        {

            var id = int.Parse(Session["id"].ToString());
            var comments = context.Comments.Where(com=>com.ArticleID==id).ToList();
            var Comments_Models = new List<CommentModel>();
            foreach (var comment in comments)
            {
                var model = new CommentModel
                {
                    CommentBody = comment.Body,
                    CommentOwner = comment.Username,
                    PublishedAt = comment.CommentDate
                };
                Comments_Models.Add(model);
        }
            return PartialView(Comments_Models);
        }

        public ActionResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddComment(CommentModel model)
        {
            var ArticleId = int.Parse(Session["id"].ToString());
            var userId = User.Identity.GetUserId();

            var user = context.Users.SingleOrDefault(u => u.Id == userId);
            string username = "";
            if (user != null)
            {
                username = user.Email.Split('@')[0];

            }
            
            Comment comment = new Comment {
                ArticleID = ArticleId,
                Username = username,
                Body = model.CommentBody,
                CommentDate = DateTime.Now
            };

            context.Comments.Add(comment);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
