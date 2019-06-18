using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private class Tree
        {
            public string Item { get; set; }
            public int MyProperty { get; set; }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            Node<string> root = new Node<string>("root");
            {
                Node<string> node0 = root.AddChild("node0");
                {
                    Node<string> node1 = root.AddChild("node1");
                    Node<string> node2 = root.AddChild("node2");
                }
                Node<string> node3 = root.AddChild("node3");
                {
                    Node<string> node4 = root.AddChild("node4");
                }
                
            }
            
            return View();
        }
        
        [HttpGet]
        public async Task<JsonResult> GetList()
        {
            return Json(new { data:"hue" });
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}