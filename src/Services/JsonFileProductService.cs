using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
   public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        //Precondition: A modified version of GetProducts() that only pulls four pets to be featured on the homepage.
        //What the function does: Gets the list produced by getProducts, grabs four items, and returns them in a new list.
        //Postcondition: creates a list of pets that are limited to four and returns it to be displayed.
        public IEnumerable<ProductModel> GetFeaturedProducts()
        {
            var products = GetProducts().Take(4); //gets the list produced by GetProducts, and in the span of it, grabs four items and puts them in a new list.
            return products; //returns the list
        }

        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();

            if(products.First(x => x.Id == productId).Ratings == null)
            {
                products.First(x => x.Id == productId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = products.First(x => x.Id == productId).Ratings.ToList();
                ratings.Add(rating);
                products.First(x => x.Id == productId).Ratings = ratings.ToArray();
            }

            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }), 
                    products
                );
            }


        }

        /// <summary>
        /// Creates a new pet.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ProductModel CreateData(ProductModel data)
        {
            var newPet = new ProductModel();
        }

        //Updates pet data function
        public ProductModel UpdateData(ProductModel data)
        {
            //Get data records 
            var products = GetProducts();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }

            //Append data to new data
            productData.Id = data.Id;
            productData.Description = data.Description;
            productData.Location = data.Location;
            productData.Cost= data.Cost;
            productData.Age = data.Age;
            productData.Breed = data.Breed;
            productData.Name = data.Name;
            productData.Ratings = data.Ratings;
            productData.Image = data.Image;

            //Save
            SaveData(products);

            //Return product data
            return productData;
        }
        

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetProducts();

            // Get the selected data by compare with the given ProductID
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            // Creat new dataset after removing the selected data
            var newDataSet = GetProducts().Where(m => m.Id.Equals(id) == false);


            //Save the new Dataset to the database
            SaveData(newDataSet);


            //return the deleted data
            return data;
        }


        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }
    }
}