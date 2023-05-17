using AlexToFood.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexToFood.Data
{
    public class AlexToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public AlexToFoodDbContext(DbContextOptions<AlexToFoodDbContext> options) : base(options)
        {
            
        }
    }
}
