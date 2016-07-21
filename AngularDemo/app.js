var module = angular.module('sparky', ['store-products']);

  module.controller('StoreController', ['$http', function($http){
      var store = this;
      store.products = [];

      $http.get('/api/product').success(function (data) {
          store.products = data;
      })
  }]);

  module.controller('ReviewController', ['$http', function($http, $scope) {
      this.review = {};

      this.addReview = function (product) {
          var data = this.review;
          data.name = product.name;

          $http.post('/api/product/review', data);

          product.reviews.push(this.review)
          this.review = {};
      }
  }]);
