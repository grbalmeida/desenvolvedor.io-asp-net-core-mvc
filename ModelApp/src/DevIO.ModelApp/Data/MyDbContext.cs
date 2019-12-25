using Microsoft.EntityFrameworkCore;

namespace DevIO.ModelApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
