using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Category_Model
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List of Categories
            List<ProductCategory> productCategories = new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    CategoryID = 1,
                    CategoryName = "Mobile Phone"
                },
                new ProductCategory()
                {
                    CategoryID = 2,
                    CategoryName = "Clothing"
                }
            };
            // List of Models
            List<ProductModel> productModels = new List<ProductModel>()
            {
                new ProductModel()
                {
                    ModelId = 1,
                    ModelName = "Spark 10"
                },
                new ProductModel()
                {
                    ModelId = 2,
                    ModelName = "Shirt s-42"
                }
            };
            // List of Products
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Tecno",
                    CategoryId = 1,
                    ModelId = 1
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Shirt",
                    CategoryId = 2,
                    ModelId = 2
                }
            };
            // --------------------- Join Three List using LINQ --------------------
            var allProductDetails = from product in products
                                    join categories in productCategories
                                    on product.CategoryId equals categories.CategoryID
                                    join models in productModels
                                    on product.ModelId equals models.ModelId
                                    select new
                                    {
                                        Id = product.ProductId,
                                        Name= product.ProductName,
                                        Category = categories.CategoryName,
                                        Model = models.ModelName
                                    };
            foreach(var product in allProductDetails)
            {
                Console.WriteLine($"Product ID: {product.Id} Name: {product.Name}, " +
                    $"Category: {product.Category}, Model: {product.Model}");
            }

            Console.ReadKey();
        }
    }
}
