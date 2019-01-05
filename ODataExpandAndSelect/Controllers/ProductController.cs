using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using ODataExpandAndSelect.Models;

namespace ODataExpandAndSelect.Controllers
{
    public class ProductController : ODataController
    {
        [EnableQuery]
        public IQueryable<Product> Get()
        {
            CategoryList list = new CategoryList();
            var data = list.getProducts();
            return data;
        }
    }
}