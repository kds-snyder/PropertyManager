angular.module('app').service('propertyService', function ($resource) {
    return $resource('http://localhost:64499/api/properties');
});