﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FYP.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Accounts> userAccount { get; set; }
    }
}