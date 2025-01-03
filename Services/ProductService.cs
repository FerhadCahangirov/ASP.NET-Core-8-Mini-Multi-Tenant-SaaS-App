﻿using ASP.NET_Core_Multi_Tenant_SaaS_App.Context;
using ASP.NET_Core_Multi_Tenant_SaaS_App.Entities;
using ASP.NET_Core_Multi_Tenant_SaaS_App.Services.DTOs;

namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
             => _context = context;

        public Product CreateProduct(CreateProductRequest request)
        {
            var product = new Product();
            product.Name = request.Name;
            product.Description = request.Description;

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }
    }
}
