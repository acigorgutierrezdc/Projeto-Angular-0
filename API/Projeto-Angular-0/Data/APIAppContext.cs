using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIApp.Model;

namespace APIApp.Data
{
    public class APIAppContext : DbContext
    {
        public APIAppContext (DbContextOptions<APIAppContext> options)
            : base(options)
        {
        }

        public DbSet<APIApp.Model.APIAppModel> APIApp { get; set; }
    }
}
