using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Setting up the JsonFileProductService class.
    /// </summary>
   public class JsonFileProductService
    {
        /// <summary>
        /// Constructor, which initializes the WebHostEnvironment using the passed-in value.
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// A get method for the WebHostEnvironment.
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// A getter for the string form of the Json file name.
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// <summary>
        /// A method to return all products/pets.
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Show pets with given status.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetProductsWithStatus(string status)
        {
          
            var products = GetProducts().Where(p => p.Status == status);
            return products;

        }

        /// <summary>
        /// Add rating method
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        public bool AddRating(string productId, int rating)
        {
            // If the ProductID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            var products = GetProducts();

            // Look up the product, if it does not exist, return
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, then create the array
            if (data.Ratings == null)
            {
                data.Ratings = new int[] { };
            }

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(products);

            return true;
        }

        /// <summary>
        /// Creates a new pet using default values.
        /// After create, the user can update to set the values.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ProductModel CreateData()
        {
            // Create a new pet ProductModel.
            var newPet = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Name = "Enter Name",
                Description = "Enter Description",
                Location = "Enter Location",
                Age = "Enter Age",
                Breed = "Enter Breed",
                Cost = "Enter Cost",
                Image = "",
                //status of the newly created pets are always available
                Status="available"
            };

            // Get the current set, and append the new record to it.
            var dataSet = GetProducts();
            dataSet = dataSet.Append(newPet);

            SaveData(dataSet);

            return newPet;
        }

        //Updates pet data function
        public ProductModel UpdateData(ProductModel data)
        {
            //Get data records 
            var products = GetProducts();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));

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
        /// <summary>
        /// Gets the product with the id in question, changes the status, and saves the dataset.
        /// </summary>
        /// <param name="id"></param>

        public void updateStatus(string id)
        {
            //Take in product id
            var dataSet = GetProducts();

            // Get the selected data by compare with the given ProductID
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            // Creat new dataset after removing the selected data
            data.Status = "adopted";

            //Save the new Dataset to the database
            SaveData(dataSet);
        }
    }
}