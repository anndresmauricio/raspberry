using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RaspberryAPIConnection.Models;

namespace RaspberryAPIConnection.Data
{
    public class RaspberryAPIConnectionContext : DbContext
    {
        public RaspberryAPIConnectionContext (DbContextOptions<RaspberryAPIConnectionContext> options)
            : base(options)
        {
        }

        public DbSet<RaspberryAPIConnection.Models.APIHumo>? APIHumo { get; set; }
    }
}
