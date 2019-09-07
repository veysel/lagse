using Lagse.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lagse.Data.Context
{
    public class LagseContext : DbContext
    {
        public LagseContext(DbContextOptions<LagseContext> options) : base(options)
        {
        }

        public DbSet<Article> Article { get; set; }
    }
}
