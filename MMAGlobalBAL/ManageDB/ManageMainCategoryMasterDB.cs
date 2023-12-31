﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using MMAGlobalBAL.Model;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;
using MMAGlobalDAL;


namespace MMAGlobalBAL.ManageDB
{
    public class ManageMainCategoryMasterDB
    {
        /// <summary>
        /// This method will store the main category master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the main category master properties with values</param>
        /// <param name="_db">Database connectoin property for main category master</param>
        /// <returns>return boolean values. true or false</returns>
        /// 
        public bool Save(maincategorymaster_Model model, DB_maincategorymaster _db)
        {
            bool isSuccess = false;
            try
            {
                main_categorymasterdb maincategory_master = new main_categorymasterdb
                {
                    sino = model.sino,
                    categoryname = model.categoryname,
                    flag = model.flag

                };
                isSuccess = _db.SaveMainCategoryMaster(maincategory_master);

            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
            }
            return isSuccess;
        }
      
        public List<maincategorymaster_Model> GetData(DB_maincategorymaster _db)
        {
            try
            {
                List<maincategorymaster_Model> _Model = new List<maincategorymaster_Model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new maincategorymaster_Model()
                {
                    sino = model.sino,
                    categoryname = model.categoryname,
                    flag = model.flag
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageMaincategorymaster save method: " + ex.Message);
                return null;
            }

        }

    }
}
