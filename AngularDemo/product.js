var module = angular.module('store-products', []);

module.directive('productDetails', function () {
    return {
        restrict: 'E',
        templateUrl: 'product-details.html'
    };
})

module.directive('productPanels', function () {
    return {
        restrict: 'E',
        templateUrl: 'product-panels.html',
        controller: function () {
            this.tab = 1;

            this.updateTab = function (newTab) {
                this.tab = newTab;
            }

            this.isSelected = function (currentTab) {
                return this.tab === currentTab;
            }
        },
        controllerAs: 'panel'
    }
})
