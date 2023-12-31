﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using MMAGlobalBAL.Model;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;

namespace MMAGlobalBAL.ManageDB
{
    public class Manage_daily_expenses
    {

        /// <summary>
        /// This method will store the expensescategory master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the expensescategory master properties with values</param>
        /// <param name="_db">Database connectoin property for expensescategory master</param>
        /// <returns>return boolean values. true or false</returns>
        public bool Save(daily_expenses_Model model, DB_daily_expenses _db)
        {
            bool isSuccess = false;
            try
            {
                daily_expenses daily_expenses = new daily_expenses
                {
                    slno = model.slno,
                    project_name = model.project_name,
                    budget_amount = model.budget_amount,
                    date=model.date,
                    invoice_number=model.invoice_number,
                    expenses_category=model.expenses_category,
                    amount=model.amount,
                    created_date = model.created_date

                };
                isSuccess = _db.SaveDailyexpensesDB(daily_expenses);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<daily_expenses_Model> GetData(DB_daily_expenses _db, DB_expensescategory_master _dailyexpenses)
        {
            try
            {
                List<daily_expenses_Model> _Model = new List<daily_expenses_Model>();
                var restul = _db.Getdata();
                var _expenses = _dailyexpenses.Getdata();
                _Model = (from model in restul
                          join expenses_category in _expenses on model.expenses_category equals expenses_category.sino
                          select new daily_expenses_Model
                //restul.ForEach(model => _Model.Add(new daily_expenses_Model()
                {

                    slno = model.slno,
                    project_name = model.project_name,
                    budget_amount = model.budget_amount,
                    date = model.date,
                    invoice_number = model.invoice_number,
                    expenses_category = model.expenses_category,
                    amount = model.amount,
                    created_date = model.created_date,
                    name=expenses_category.name

                }).ToList();

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageexpensesmasterDB get method: " + ex.Message);
                return null;
            }

        }
    }
}
