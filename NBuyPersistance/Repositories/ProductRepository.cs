using NBuyDomain.Repositories;
using NBuyPersistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyPersistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;

        }

        public void Save()
        {
            // Product Tablosuna kayıt atar.
            _db.ProductTables.AddEvent(null);

        }
    }
}
