using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data.SqlClient;

namespace AngularDemo
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            List<Product> products = new List<Product>();

            string connectionString = ConfigurationManager.ConnectionStrings["gems"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Product";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            

                            Product p = new Product();

                            int ID = reader.GetInt32(reader.GetOrdinal("ID"));



                            int position = reader.GetOrdinal("CanPurchase");
                            p.CanPurchase = reader.GetBoolean(position);

                            position = reader.GetOrdinal("Description");
                            p.Description = reader.GetString(position);

                            position = reader.GetOrdinal("Name");
                            p.Name = reader.GetString(position);

                            position = reader.GetOrdinal("Price");
                            p.Price = reader.GetDecimal(position);

                            position = reader.GetOrdinal("SoldOut");
                            p.SoldOut = reader.GetBoolean(position);

                            using (SqlCommand imagesCommand = connection.CreateCommand())
                            {
                                List<Image> images = new List<Image>();
                                imagesCommand.CommandText = string.Format("SELECT * FROM Image WHERE ProductID = {0}", ID);
                                using(SqlDataReader imageReader = imagesCommand.ExecuteReader())
                                {
                                    while (imageReader.Read())
                                    {
                                        Image i = new Image();
                                        i.Full = imageReader.GetString(imageReader.GetOrdinal("Full"));
                                        i.Thumb = imageReader.GetString(imageReader.GetOrdinal("Thumb"));
                                        images.Add(i);
                                    }
                                }
                                p.Images = images.ToArray();
                            }


                            using (SqlCommand reviewsCommand = connection.CreateCommand())
                            {
                                List<Review> reviews = new List<Review>();
                                reviewsCommand.CommandText = string.Format("SELECT * FROM Review WHERE ProductID = {0}", ID);
                                using (SqlDataReader reviewsReader = reviewsCommand.ExecuteReader())
                                {
                                    while (reviewsReader.Read())
                                    {
                                        Review r = new Review();
                                        r.Author = reviewsReader.GetString(reviewsReader.GetOrdinal("Author"));
                                        r.Body = reviewsReader.GetString(reviewsReader.GetOrdinal("Body"));
                                        r.Stars = reviewsReader.GetInt32(reviewsReader.GetOrdinal("Stars"));
                                        reviews.Add(r);
                                    }
                                }
                                p.Reviews = reviews.ToArray();
                            }

                            products.Add(p);
                        }
                    }
                }


                connection.Close();
            }

            return products;
            
        }
        
        [HttpPost]
        public void Review(ProductReview r)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["gems"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int? productId = null;

                connection.Open();
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT ID FROM Product WHERE Name = '{0}'", r.Name);

                    productId = command.ExecuteScalar() as int?;

                }

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(
                        "INSERT INTO Review(AUTHOR, Body, Stars, ProductID) VALUES('{0}', '{1}', {2}, {3})",
                        r.Author, r.Body, r.Stars, productId);

                    command.ExecuteNonQuery();
                }

                    connection.Close();
            }
            Console.WriteLine(r.Author);
        }

        public class ProductReview : Review
        {
            public string Name { get; set; }
        }
    }
}