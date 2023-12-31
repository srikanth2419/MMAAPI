﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;

namespace MMAGlobalDAL.Database.DB_Helper
{
   public class DB_user_master
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_user_master(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveUserMaster(user_master user_master)
        {
            bool isSuccess = false;
            try
            {
                _DataContext.user_master.Add(user_master);
                if (user_master.id > 0)
                {
                    _DataContext.Entry(user_master).State = EntityState.Modified;
                }
                _DataContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }
        public List<user_master> Getdata()
        {
            return _DataContext.user_master.ToList();
        }

    }
}
