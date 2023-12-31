﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_city_master
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_city_master(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveCityMaster(city_master city_master)
        {
            bool isSuccess = false;
            try
            {

                _DataContext.citymaster.Add(city_master);
                if(city_master.citycode>0)
                {
                    _DataContext.Entry(city_master).State = EntityState.Modified;
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
        public List<city_master> Getdata()
        {
            return _DataContext.citymaster.ToList();
        }

    }
}
