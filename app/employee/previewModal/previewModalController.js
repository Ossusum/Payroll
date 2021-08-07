(function () {
    'use strict';

    angular
        .module('app')
        .controller('previewModalController', previewModalController);

    previewModalController.$inject = ['$uibModalInstance', 'employee', '$rootScope', 'constantService', 'employeeService'];

    function previewModalController($uibModalInstance, employee, $rootScope, constantService, employeeService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'previewModalController';
        vm.grandtotal = 0;
        vm.employee = employee;
        vm.cs = constantService;
        vm.es = employeeService;
        vm.previewCost = employeeService.previewCosts(employee);
        vm.close = close;
        vm.isDeductable = isDeductable;

        activate();

        function activate() {
            vm.company = $rootScope.company;
            vm.grandtotal = calculate();
        }
        

        function close() {
            $uibModalInstance.close(employee);
        };

        function calculate() {
            return vm.previewCost.totalCost.value;
        }

        function isDeductable() {
            if (vm.employee.Dependents.length > 0) {
                return vm.employee.FirstName.includes("a") || vm.employee.Dependents.filter(dependent => dependent.FirstName.includes("a")).length > 0;
            }
            return vm.employee.FirstName.includes("a");

        }

    }
})();
