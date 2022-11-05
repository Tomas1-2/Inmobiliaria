using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;

    public class inmobiliariaContext : DbContext
    {
        public inmobiliariaContext (DbContextOptions<inmobiliariaContext> options)
            : base(options)
        {
        }

        public DbSet<Inmobiliaria.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<Inmobiliaria.Models.Casa>? Casa { get; set; }
    }
