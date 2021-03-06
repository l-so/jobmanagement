﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Job.WebMvc.Models.TravelExpense
{
    public class TravelExpenseEditModel
    {
        public int TEFilterYear { get; set;}
        public int TEFilterMonth { get; set; }
        public int TEFilterPeopleId { get; set; }
        public EFDataModel.TravelExpenses TravelExpense { get; private set;}
        public EFDataModel.TravelExpenseList TravelExpenseList { get; private set;}
        public List<EFDataModel.TravelExpensesLines> TravelExpenseLine { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLCategoryList { get; private set; }
        public EFDataModel.TravelExpenseLineCategories CarLineCategory { get; private set;}
        public List<EFDataModel.WorksJournal> Works { get; private set; }
        internal void LoadData(string id)
        {
            this.TravelExpense = DataAccessLayer.DBTravelExpense.getOne(id);
            this.TravelExpenseList = DataAccessLayer.DBTravelExpense.getOneFromList(id);
            this.TravelExpenseLine = DataAccessLayer.DBTravelExpense.getLines(id);
            this.DDLCategoryList = DataAccessLayer.DBTravelExpense.getLineCategory();
            this.CarLineCategory = DataAccessLayer.DBTravelExpense.getCarLineCategory();
            if (this.TravelExpenseList.BeginDate.HasValue)
            {
                this.Works = DataAccessLayer.DBTravelExpense.getPeopleWork(this.TravelExpenseList.PeopleId.Value, this.TravelExpenseList.BeginDate.Value, this.TravelExpenseList.EndDate.Value);
            }
        }
    }
}