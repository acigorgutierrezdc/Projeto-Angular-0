using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YounderAPI.Model;

namespace YounderAPI.Data
{
    public class YounderAPIContext : DbContext
    {
        public YounderAPIContext (DbContextOptions<YounderAPIContext> options)
            : base(options)
        {
        }

        public DbSet<YounderAPI.Model.Clientes> Clientes { get; set; }
    }
}
