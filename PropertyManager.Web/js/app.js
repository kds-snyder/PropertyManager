﻿angular.module('app', ['ui.router', 'ngResource']).config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/dashboard');

    $stateProvider
        .state('dashboard', { url: '/dashboard', templateUrl: '/templates/dashboard/dashboard.html' })

        // /property
        .state('property', { abstract: true, url: '/property', template: '<ui-view />' })
            .state('property.grid', { url: '/grid', templateUrl: '/templates/property/grid.html', controller: 'PropertyGridController' })
            .state('property.detail', { url: '/detail/:id', templateUrl: '/templates/property/detail.html', controller: 'PropertyDetailController' })

        .state('tenant', { abstract: true, url: '/tenant', template: '<ui-view />' })
            .state('tenant.grid', { url: '/grid', templateUrl: '/templates/tenant/grid.html', controller: 'TenantGridController' })
            .state('tenant.detail', { url: '/detail/:id', templateUrl: '/templates/tenant/detail.html', controller: 'TenantDetailController' })

        .state('lease', { abstract: true, url: '/lease', template: '<ui-view />' })
            .state('lease.grid', { url: '/lease', templateUrl: '/templates/lease/grid.html', controller: 'LeaseGridController' })
            .state('lease.detail', { url: '/detail', templateUrl: '/templates/lease/detail.html', controller: 'LeaseDetailController' });
});

angular.module('app').value('apiUrl', 'http://localhost:5000/api/');