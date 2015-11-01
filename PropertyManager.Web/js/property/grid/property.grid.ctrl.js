angular.module('app').controller('PropertyGridController', function ($scope, propertyService) {



    $scope.properties = propertyService.query();
    
});