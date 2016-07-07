var module = angular.module('sparky', ['store-products']);

  module.controller('StoreController', ['$http', function($http){
      var store = this;
      store.products = [];

      $http.get('/products.json').success(function (data) {
          store.products = data;
      })
  }]);

  module.controller('ReviewController', function ($scope) {
      this.review = {};

      this.addReview = function (product) {
          product.reviews.push(this.review)
          this.review = {};
      }
  });
