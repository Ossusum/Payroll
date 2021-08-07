(function () {
    'use strict';

    angular
        .module('app')
        .controller('addEmployeeController', addEmployeeController);

    addEmployeeController.$inject = ['$uibModal', '$log', 'employeeService', '$state', 'constantService', '$rootScope'];

    function addEmployeeController($uibModal, $log, employeeService, $state, constantService, $rootScope) {
        var vm = this;

        vm.title = 'employeeController';
        vm.dependents = [];
        vm.cs = constantService;

        vm.openModal = openModal;
        vm.preview = preview;
        vm.employee = {
            Wage: $rootScope.company.DefaultEmployeeSalary,
            Dependents: []
        };

        vm.deleteDependent = deleteDependent;
        vm.save = save;

        init();

        function save() {
            if (isValid()) {
                employeeService.addEmployee(vm.employee).then(
                    function (success) {
                        $state.go('employees');
                    },
                    function (error) {
                        $rootScope.error = error.data.MessageDetail;
                    }
                );
            } else {
                $rootScope.error = vm.error;
            }
        }

        function isValid() {
            var validation = employeeService.isValid(vm.employee);
            vm.error = validation.message;
            return validation.isValid;
        }

        function init() {
            
        }

        function deleteDependent(dependent) {
            vm.employee.Dependents.pop(dependent);
        }

        function openModal() {
            if (isValid()) {
                var dialogInst = $uibModal.open({
                    templateUrl: 'app/employee/dependentModal/dependentModal.html',
                    controller: 'dependentModalController',
                    controllerAs: 'vm',
                    bindToController: true,
                    size: 'lg',
                    windowClass: 'show',
                    backdropClass: 'show',
                    resolve: {
                        employee: function () {
                            return vm.employee;
                        }
                    }
                });
                dialogInst.result.then(
                    function (newEmployee) {
                        vm.employee = newEmployee;
                    }
                );
            } else {
                $rootScope.error = vm.error;
            }
            
        }

        function preview() {
            if (isValid()) {
                var dialogInst = $uibModal.open({
                    templateUrl: 'app/employee/previewModal/previewModal.html',
                    controller: 'previewModalController',
                    controllerAs: 'vm',
                    bindToController: true,
                    size: 'lg',
                    windowClass: 'show',
                    backdropClass: 'show',
                    resolve: {
                        employee: function () {
                            return vm.employee;
                        }
                    }
                });
                dialogInst.result.then(
                    function (newEmployee) {
                    }
                );
            } else {
                $rootScope.error = vm.error;
            }
        }

    }
})();
