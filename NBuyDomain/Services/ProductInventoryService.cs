using NBuyCore.Services;
using NBuyDomain.Entities;
using NBuyDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NBuyDomain.Services
{
    public class ProductInventoryService: IDomainService<Product>
    {
        // burada interface sayesinde persistance layer direk bir bağıölılık yoktur. zaten domain katmanı core dışınd a hiç bir katmandan referans almamalıdır.
        private IProductRepository _productRepository;

        public ProductInventoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void CheckProductInventory(Product product)
        {
            // ürünün envater olarak işlenip işlenmeyeceğinin kontrolünü yapar logic burada barınır.
        }
    }
}
