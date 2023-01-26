using Microsoft.EntityFrameworkCore;

namespace CONTATOCHAT_API.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {

        }
    }
}
