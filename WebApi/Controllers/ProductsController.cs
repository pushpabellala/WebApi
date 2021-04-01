using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        static List<Product> _productList = null;
        void Initialize()
        {
            _productList = new List<Product>()
           {
               new Product() { Id=1, Name="Book" ,Description="it is easy to read" ,QualityStock=23,Supplier="outsider"},

               new Product() { Id=2, Name="Pen" ,Description="it is easy to write" ,QualityStock=56,Supplier="outsiderperson"},
           };

        }
        public ProductsController()
        {
            if (_productList == null)
            {
                Initialize();
            }
        }

       
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _productList);
        }

        
        public HttpResponseMessage Get(int id)
        {
            Product product = _productList.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");
            else
                return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        // POST: api/Products
        public HttpResponseMessage Post(Product product)
        {
            if (product != null)
            {
                _productList.Add(product);
            }
            return Request.CreateResponse(HttpStatusCode.Created,"successfully created");
        }

        // PUT: api/Students/5
        public HttpResponseMessage Put(int id, Product objStudent)
        {
            Product product = _productList.Where(x => x.Id == id).FirstOrDefault();
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");

            }
            else
            {
                if (product != null)
                {
                    foreach (Product temp in _productList)
                    {
                        if (temp.Id == id)
                        {
                            temp.Name = objStudent.Name;
                            temp.Description = objStudent.Description;
                            temp.QualityStock = objStudent.QualityStock;
                            temp.Supplier = objStudent.Supplier;
                        }
                    }


                }
                return Request.CreateResponse(HttpStatusCode.OK, "Modified");

            }
        }

        // DELETE: api/Students/5
        public HttpResponseMessage Delete(int id)
        {
            Product product = _productList.Where(x => x.Id == id).FirstOrDefault();
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");

            }
            else
            {
                if (product != null)
                {
                    _productList.Remove(product);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Deleteed");
            }

        }

    }
}
