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
    public class ManageRolemaster
    {
        public bool Save(role_master_Model model, DB_role_master _db)
        {
            bool isSuccess = false;
            try
            {
                role_master db = new role_master
                {
                    roleid = model.roleid,
                    rolename = model.rolename,
                    flag = model.flag
                };
                isSuccess = _db.SaveRolemasterDB(db);
                // Task.Run(()=> _db.SaveTrainingDB(_traningdb));
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageRolemaster save method: " + ex.Message);
                return isSuccess;
            }

        }
    }
}
