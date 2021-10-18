using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.Data.Entity;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db = new ProductContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.ProductMasters.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductMaster p)
        {
            if (ModelState.IsValid == true)
            {
                db.ProductMasters.Add(p);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Data Inserted!!')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted!!')</script>";
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.ProductMasters.Where(model => model.ProductId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(ProductMaster p)
        {
            db.Entry(p).State = EntityState.Modified;
            int a = db.SaveChanges();
            if(a>0)
            {
                ViewBag.UpdateMessage = "<script>alert('Data Updated!!')</script>";
                ModelState.Clear();
            }
            else
            {
                ViewBag.UpdateMessage = "<script>alert('Data Updated!!')</script>";
            }
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            
            //db.Entry(p).State = EntityState.Deleted;
            ProductMaster p = db.ProductMasters.Find(id);
            db.ProductMasters.Remove(p);
            int a = db.SaveChanges();
            if (a>0)
            {
                ViewBag.DeleteMessage = "<script>alert('Data Deleted!!')</script>";
               
            }
            else
            {
                ViewBag.DeleteMessage = "<script>alert('Data Not Deleted!!')</script>";
            }
            return View();
        }
    }
}