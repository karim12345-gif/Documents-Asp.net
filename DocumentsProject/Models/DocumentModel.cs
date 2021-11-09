using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DocumentsProject.Models
{
    public class DocumentModel
    {
        [DisplayName("Item/Subject Name")]
        public string Subject { get; set; }

        [DisplayName("Document Type")]
        public string DocumentType { get; set; }

        [DisplayName("Document Date")]
        public string DocumentDate { get; set; }

        [DisplayName("Serial Name")]
        public int SerialNumber { get; set; }

        [DisplayName("Year")]
        public DateTime Year { get; set; }

        [DisplayName("Remark")]
        public string Remark { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        [DisplayName("Upload")]
        public string FilePath { get; set; }
        public HttpPostedFileBase File { get; set; }
    }




}