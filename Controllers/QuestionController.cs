using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using StackExchangeApiViewer.Models;

namespace StackExchangeApiViewer.Controllers
{
   

   
    public class QuestionController : Controller
    {
        private RootObject _rootObject = new RootObject ();

        private RootObject RootObject
        {
            get
            {
                return _rootObject; 
            }

           
        }
        
        public ActionResult Index()
        {
            RootObject.GetLatestQuestions();
            var questions = RootObject.Items.Take(50).ToList();
            return View(questions);
        }

        public ActionResult Details (int id)
        {
            RootObject.GetLatestQuestions();
            var questions = RootObject.Items.Where(i => i.question_id == id).FirstOrDefault();
            return View(questions);
        }
    }
}