using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.IO;
using System.Web;

namespace FileUploading.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string type)  
        {
            

            if (files != null && files.ContentLength > 0)
            {
                
                Debug.WriteLine(type);
                if (type == "Document")
                {



                    

                    var fileName = Path.GetFileName(files.FileName);

                  

                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);

                    

                    files.SaveAs(path);
                }
                
                if (type == "Image")
                {



                   

                    var fileName = Path.GetFileName(files.FileName);

                    

                    var path = Path.Combine(Server.MapPath("~/App_Data/images"), fileName);

                   

                    files.SaveAs(path);
                }
                
                if (type == "Video")
                {



                    

                    var fileName = Path.GetFileName(files.FileName);

                    

                    var path = Path.Combine(Server.MapPath("~/App_Data/videos"), fileName);

                    

                    files.SaveAs(path);
                }





            }
            

            return RedirectToAction("Index");
        }
        
        
    }
}