using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentsProject.Models;
using System.IO;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;


namespace DocumentsProject.Controllers
{
    public class HomeController : Controller
    {
 
        DocumentDataClassesDataContext db = new DocumentDataClassesDataContext();
        // this is where the search is going to be based  
        public ActionResult Index()
        {
            DocumentModel documentvalues = new DocumentModel();

            return View(documentvalues);
        }


        [HttpGet]
        public ActionResult SearchAct()
        {

            var document = db.Table1s.Include(e => e.CreatedBy);
            return View(document.ToList());
            
        }


        [HttpPost]
        public ActionResult SearchActs(string searching, string CreatedBY)
        {
            var document = db.Table1s.ToList().Where(p => p.Subject.StartsWith(searching) && p.CreatedBy.StartsWith(CreatedBY));
            return View(document);

        }

        [HttpPost]
        public ActionResult ContactForm(DocumentModel documentvalues)
        {
            try
            {
                string Imagename = Path.GetFileNameWithoutExtension(documentvalues.File.FileName);
                string ImageExtention = Path.GetExtension(documentvalues.File.FileName);
                string ImageNameToSave = Imagename + DateTime.UtcNow.ToString("yymmssff") + ImageExtention;
                string ImagePath = "~/MyFile/" + ImageNameToSave;
                string ImageFilePathToSave = Path.Combine(Server.MapPath("~/MyFile"), ImageNameToSave);
                documentvalues.File.SaveAs(ImageFilePathToSave);

            }
            catch ( Exception e)
            {
                ModelState.AddModelError("_FORM", e.Message);
                return View("Index");
            }

          

            // saving the inforamtion in the database 

            var db = new DocumentDataClassesDataContext();

            Table1 table = new Table1();


            table.CreatedBy = documentvalues.CreatedBy;
            table.DocumentType = documentvalues.DocumentType;
            table.Subject = documentvalues.Subject;
            table.Remark = documentvalues.Remark;
            table.Year = documentvalues.Year;
            table.SerialNumber = documentvalues.SerialNumber;
            table.DocumentDate = documentvalues.DocumentDate;


            db.Table1s.InsertOnSubmit(table);
            db.SubmitChanges();




            return View();

        }
    }
}