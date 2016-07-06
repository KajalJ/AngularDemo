var gems =[ {
    name: 'Dodecahedron',
    price: 2.95,
    description: 'Some gems have qualities beyond their lustre, beyond their shine.  Dodecahedron is one of those gems.',
    canPurchase: true,
    soldOut: false,
    images: [
        {
            full: 'dodecahedron.png',
            thumb: 'dodecahedron_thumb.png'
        },
        {
            full: 'dodecahedron2.jpg',
            thumb: 'dodecahedron2_thumb.jpg'
        }
    ],

    reviews:[
    {stars: 5,
        body: "I love this product",
        author: "Joe@Thomas.com"
    },{
        star:1,
        body:"This product isn't even real",
        author:"tim@hater.com"
    }]
} ,{
    name: 'Pentagonal',
    price: 5.95,
    description: 'I am a gem shaped as a pentagon',
    canPurchase: true,
    soldOut: false
}]

var module = angular.module('sparky', []);

  module.controller('StoreController', function ($scope) {

        this.products = gems;
        //alert("Welcome, Joe!");
  });

  module.controller('PanelController', function ($scope) {
      this.tab = 1;

      this.updateTab = function (newTab) {
          this.tab = newTab;
      }

      this.isSelected = function (currentTab) {
          return this.tab === currentTab;
      }
  });

  module.controller('ReviewController', function ($scope) {
      this.review = {};

      this.addReview = function (product) {
          product.reviews.push(this.review)
          this.review = {};
      }
  });