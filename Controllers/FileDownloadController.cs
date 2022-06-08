using FileUploading.Models; // If we do not have this then it is

// List<Models.FileModel> files = new List<Models.FileModel>();

using System.Collections.Generic; // Helps with lists

using System.IO; // Required for reading and writing IO (Input / Output).
using System.Web.Mvc;

namespace FileUploading.Controllers
{
    public class FileDownloadController : Controller 
    {
        
        public ActionResult Index()
        {
            

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/uploads/"));

            

            List<FileModel> files = new List<FileModel>();
            

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName) 
        {
            

            string path = Server.MapPath("~/App_Data/uploads/") + fileName;

            

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            

            string path = Server.MapPath("~/App_Data/uploads/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}