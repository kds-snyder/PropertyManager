angular.module('app').service('leaseService', function ($http, $resource) {
    $resource('http://localhost:65527/api/leases');
});