using Microsoft.EntityFrameworkCore;

namespace Authorization.Domain
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected RepositoryContext()
        {
        }
    }
}