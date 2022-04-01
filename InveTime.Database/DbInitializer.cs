using InveTime.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InveTime.Database
{
    public class DbInitializer
    {
        private readonly InveTimeDB _db;

        public DbInitializer(InveTimeDB db)
        {
            _db = db;
        }

        public void Initialize()
        {
            _db.Database.Migrate();
        }

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync();
        }
    }
}
