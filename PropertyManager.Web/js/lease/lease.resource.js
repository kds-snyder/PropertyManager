angular.module('app').factory('Lease', function ($resource, apiUrl) {
    $resource(apiUrl + 'leases/:id');
});