angular.module('app').service('tenantService', function ($resource) {
    $resource('http://localhost:65527/api/tenants');
});