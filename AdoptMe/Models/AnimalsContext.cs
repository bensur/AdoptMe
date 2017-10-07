using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdoptMe.Models
{
    public class AnimalsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AnimalsContext() : base("name=AnimalsContext")
        {
        }

        public System.Data.Entity.DbSet<AdoptMe.Models.AnimalModel> Animals { get; set; }
        public System.Data.Entity.DbSet<AdoptMe.Models.AdoptionAgencyModel> AdoptionAgencies { get; set; }
    }
}
