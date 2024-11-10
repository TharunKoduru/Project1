using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ex19.Models
{
    public class TouristPlaceContext:DbContext
    {
        public TouristPlaceContext()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TouristPlace>().ToTable("TouristPlace");
        }
        public DbSet<TouristPlace> tourists { get; set; }
    }
}