using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace assessment.Context
{
    public class InfnetDbContext : DbContext
    {
        public InfnetDbContext(DbContextOptions<InfnetDbContext> options) : base(options)
        {
        
        }
        public DbSet<Funcionario>Funcionario{get;set;}
        public DbSet<Departamento>Departamento{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .HasOne(p => p.Departamento)
                .WithMany(b => b.Funcionarios)
                .HasForeignKey(p => p.DepartamentoId)
                .IsRequired(false);
        }
    }
   

}