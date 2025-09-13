using Microsoft.EntityFrameworkCore;

namespace Rakas_BookStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Retrieve connectionString
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //This class passes the option to the base class
        }
    }
}
