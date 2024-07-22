using MvcRehber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcRehber.Models.Context
{
    public class MvcRehberContext : DbContext
    {
        public MvcRehberContext() : base("Server=LAPTOP-EMDK24Q1;Database=MvcRehberDB;Trusted_Connection=true")                                                                                                  
        {

        }
        public DbSet<Kisi> Kisiler { get; set; }
        //burada oluşturduğumuz method ile dbset türünde (içinde person classı ile) persons adında bir table oluşturmuş oluyoruz.
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<TBLUserInfo> TBLUserInfoes { get; set; }

    }
}