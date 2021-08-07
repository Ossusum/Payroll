(function () {
    'use strict';

    angular.module('app', [
        // Angular modules 
        'ngMaterial',
        'ngAnimate',
        // Custom modules 
        // 3rd Party Modules
        'ui.bootstrap',
        'ui.router'
    ]);

    angular.module('app')
        .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/home');
            var home = {
                name: 'home',
                url: '/home',
                templateUrl: 'app/home/home.html',
                controller: 'homeController',
                controllerAs: 'vm'
            }
            var employees = {
                name: 'employees',
                url: '/employees',
                templateUrl: 'app/employee/viewEmployees.html',
                controller: 'viewEmployeesController',
                controllerAs: 'vm'
            }
            var employee = {
                name: 'employee',
                url: '/employee/{employeeId}',
                params: {
                    employee: null
                },
                templateUrl: 'app/employee/employee.html',
                controller: 'employeeController',
                controllerAs: 'vm'
            }
            var addEmployee = {
                name: 'addEmployee',
                url: '/addEmployee',
                templateUrl: 'app/employee/employee.html',
                controller: 'addEmployeeController',
                controllerAs: 'vm'
            }
            var company = {
                name: 'company',
                url: '/company',
                templateUrl: 'app/company/company.html',
                controller: 'companyController',
                controllerAs: 'vm'
            }

            $stateProvider.state(home);
            $stateProvider.state(employee);
            $stateProvider.state(addEmployee);
            $stateProvider.state(employees);
            $stateProvider.state(company);
            
        }]);


    angular.module('app')
        .run(function ($rootScope, companyService) {
            companyService.getCompanyDetails().then(
                function (success) {
                    $rootScope.company = success.data;
                },
                function (error) {
                    $rootScope.error = error.data.MessageDetail;
                }
            );
            
        });
})();