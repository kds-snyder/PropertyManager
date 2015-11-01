angular.module('app').factory('Tenant', function ($resource, apiUrl) {
    $resource(apiUrl + 'tenants/:id');
});