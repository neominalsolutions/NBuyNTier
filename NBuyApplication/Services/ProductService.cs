using NBuyApplication.Dtos;
using NBuyCore.Services;
using NBuyDomain.Entities;
using NBuyDomain.Repositories;
using NBuyDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyApplication.Services
{
    public class ProductService: IApplicationService<Product>
    {
        private readonly ProductInventoryService _productInventoryService;
        private readonly IProductRepository _productRepository;
        private readonly IEmailSender _emailSender;

        public ProductService(ProductInventoryService productInventoryService, IProductRepository productRepository, IEmailSender emailSender)
        {
            _productInventoryService = productInventoryService;
            _productRepository = productRepository;
            _emailSender = emailSender;
        }
       

        public void CreateCommand(ProductCreateDto model)
        {
            // dto entity mappledi.
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
                IsDeleted = false
            };

            // Ürünün envanter olarak sistem geirip giremeyeceğini kontrol eden domain servisi tetikledi.
            _productInventoryService.CheckProductInventory(product); // domain katmanından referans aldı
            // ürün envantere girebilirse database kaydetmesini tetikledi
            _productRepository.Save(); // persisgtance katmanından referans aldı
            // ilgili birime mail atma methodunu tetikledi.
            _emailSender.SendEmail(); // Infra katmanına referans aldı

            // yani kısaca bir ürün oluşturma işlemine ait servislerin koordinasyonu birbileri ile sıra halinde çalışacağı bir iş yaptı.
            // görfüğümüz üzere herhangi bir logic işlemi barındırmıyor.
            // validayon loglama gibi sadece uyguşlama katmanını ilgilendiren logicler olabilir. ama bussiness logic bu katmanda yer almamalıdır.
        }
    }
}
