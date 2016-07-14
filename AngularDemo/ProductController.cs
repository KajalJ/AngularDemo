using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularDemo
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            return new Product[] {
                new Product() {
                    Name = "Dodecahedron",
                    Price = 2.95m,
                    Description = "Some gems have qualities beyond their lustre, beyond their shine.  Dodecahedron is one of those gems.",
                    CanPurchase = true,
                    SoldOut = false,
                    Images = new Image[]
                    {
                        new Image
                        {
                            Full = "dodecahedron.png",
                            Thumb = "dodecahedron_thumb.png"
                        },
                        new Image
                        {
                            Full = "dodecahedron2.jpg",
                            Thumb = "dodecahedron2_thumb.jpg"
                        }
                    },
                    Reviews = new Review[]
                    {
                        new Review
                        {
                            Stars = 5,
                            Body = "I love this product",
                            Author = "joe@thomas.com"
                        },
                        new Review
                        {
                            Stars = 1,
                            Body = "This product isn't even real",
                            Author = "tim@hater.com"
                        }
                    }
                },
                new Product() {
                    Name = "Pentagonal",
                    Price = 5.95m,
                    Description = "I am a gem shaped as a pentagon",
                    CanPurchase = true,
                    SoldOut = false
                }
            };
        }
        
    }
}