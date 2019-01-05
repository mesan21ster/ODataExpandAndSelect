using System.Collections.Generic;
using System.Linq;

namespace ODataExpandAndSelect.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

    public class ProductList
    {
        public IQueryable<Product> getProducts()
        {
            List<Product> products = new List<Product>();

            Category c1 = new Category() { ID = 1, Name = "Category1", Products = products };
            Category c2 = new Category() { ID = 2, Name = "Category2", Products = products };
            Supplier s1 = new Supplier() { Key = "s1", Name = "Supplier1" };
            Supplier s2 = new Supplier() { Key = "s2", Name = "Supplier2" };

            Product p1 = new Product() { ID = 1, Category = c1, CategoryId = 1, Name = "product1", Price = 100.50M , Supplier = s1, SupplierId = "SupplierS1" };
            Product p2 = new Product() { ID = 2, Category = c2, CategoryId = 2, Name = "product2", Price = 200.50M , Supplier = s2, SupplierId = "SupplierS2" };

            products.Add(p1);
            products.Add(p2);
           
            return products.AsQueryable();
        }
    }
}