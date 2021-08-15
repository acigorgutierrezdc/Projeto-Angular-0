using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlunoAPI.Model;

namespace AlunoAPI.Data
{
    public class AlunoAPIContext : DbContext
    {
        public AlunoAPIContext (DbContextOptions<AlunoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AlunoAPI.Model.Aluno> Aluno { get; set; }
    }
}
