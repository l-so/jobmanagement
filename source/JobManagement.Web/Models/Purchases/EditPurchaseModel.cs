using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Models.Purchases
{
    public class EditPurchaseModel
    {
        public IEnumerable<SelectListItem> DDLPurchaseDocumentTypeList { get; private set; }
        public IEnumerable<SelectListItem> DDLCategoryList { get; private set; }
        public IEnumerable<SelectListItem> DDLPaiedByList { get; private set; }

        public void loadModelData() 
        {
            List < SelectListItem > p = new List<SelectListItem>();
            p.Add(new SelectListItem() { Text = "FATTURA", Value = "FATTTURA" });
            this.DDLPurchaseDocumentTypeList = p;
            List<SelectListItem> c = new List<SelectListItem>();
            c.Add(new SelectListItem() { Text = "Spese di trasferta", Value = "TRAVELEXPENSE" });
            this.DDLCategoryList = c;
            List<SelectListItem> pb = new List<SelectListItem>();
            pb.Add(new SelectListItem() { Text = "1000 - ZZ Soft", Value = "1000" });
            pb.Add(new SelectListItem() { Text = "1001 - ZZ Soft carta credito", Value = "1001" });
            pb.Add(new SelectListItem() { Text = "1002 - ZZ Soft cassa", Value = "1002" });
            pb.Add(new SelectListItem() { Text = "1100 - Stefano Carri", Value = "1100" });
            pb.Add(new SelectListItem() { Text = "1001 - Maurizio Battisti", Value = "1101" });
            pb.Add(new SelectListItem() { Text = "1002 - Lorenzo Soncini", Value = "1102" });
            this.DDLPaiedByList = pb;
        }
    }
}