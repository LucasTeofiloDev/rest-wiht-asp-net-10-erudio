using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace RestWithASPNET10.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) 
            : base(options) {}
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Book { get; set; }

        
    }
}
