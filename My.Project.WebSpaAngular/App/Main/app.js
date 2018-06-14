var appModule = appModule || {};
(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);
    appModule = app;
    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');
            $qProvider.errorOnUnhandledRejections(false);
            //用户管理
            if (abp.auth.hasPermission('Pages.Sys.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/sys/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in ProjectNavigationProvider
                    });
                //$urlRouterProvider.otherwise('/users');
            }
            //角色管理
            if (abp.auth.hasPermission('Pages.Sys.Roles')) {
                $stateProvider
                    .state('roles', {
                        url: '/roles',
                        templateUrl: '/App/Main/views/sys/roles/index.cshtml',
                        menu: 'Roles' //Matches to name of 'Tenants' menu in ProjectNavigationProvider
                    });
                //$urlRouterProvider.otherwise('/roles');
            }
            //租户管理
            if (abp.auth.hasPermission('Pages.Sys.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in ProjectNavigationProvider
                    });
                //$urlRouterProvider.otherwise('/tenants');
            }

            //地区管理
            if (abp.auth.hasPermission('Pages.Sys.Places')) {
                $stateProvider
                    .state('places', {
                        url: '/places',
                        templateUrl: '/App/Main/views/sys/places/index.cshtml',
                        menu: 'Places' //Matches to name of 'Tenants' menu in ProjectNavigationProvider
                    });
                //$urlRouterProvider.otherwise('/tenants');
            }






            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in ProjectNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in ProjectNavigationProvider
                });
        }
    ]);

})();