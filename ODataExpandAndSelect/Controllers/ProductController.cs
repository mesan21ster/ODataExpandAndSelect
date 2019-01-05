using System.Linq;
using Microsoft.AspNet.OData;
using ODataExpandAndSelect.Models;

namespace ODataExpandAndSelect.Controllers
{
    public class ProductController : ODataController
    {
        [EnableQuery]
        public IQueryable<Product> Get()
        {
            ProductList list = new ProductList();
            var data = list.getProducts();
            return data;
        }
    }
}