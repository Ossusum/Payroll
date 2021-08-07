(function () {
    'use strict';

    angular
        .module('app')
        .controller('viewEmployeesController', viewEmployeesController);

    viewEmployeesController.$inject = ['employeeService', '$state', 'constantService', '$location', '$rootScope'];

    function viewEmployeesController(employeeService, $state, constantService, $location, $rootScope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'viewEmployeesController';
        vm.employees = [];
        vm.cs = constantService;
        vm.es = employeeService;

        vm.openEmployee = openEmployee;
        vm.addEmployee = addEmployee;
        activate();

        function activate() {
            vm.es.getEmployees().then(
                function (success) {
                    vm.employees = success.data;
                },
                function (error) {
                    $rootScope.error = error.data.MessageDetail;
                }
            );
        }

        function openEmployee(employee) {
            $location.path('/employee/'+ employee.ID);
        }

        function addEmployee() {
            $state.go('addEmployee');
        }
    }
})();
