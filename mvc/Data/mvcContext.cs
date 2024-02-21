using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data
{
    public class mvcContext : DbContext
    {
        public mvcContext (DbContextOptions<mvcContext> options)
            : base(options)
        {
        }

        public DbSet<mvc.Models.BookViewModel> BookViewModel { get; set; } = default!;
    }
}
