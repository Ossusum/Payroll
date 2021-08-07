(function () {
    'use strict';

    angular
        .module('app')
        .controller('employeeController', employeeController);

    employeeController.$inject = ['$uibModal', '$stateParams', 'employeeService', '$state', 'constantService', '$rootScope'];

    function employeeController($uibModal, $stateParams, employeeService, $state, constantService, $rootScope) {
        var vm = this;

        vm.title = 'employeeController';
        vm.dependents = [];
        vm.cs = constantService;
        vm.isEdit = true;
        vm.openModal = openModal;
        vm.preview = preview;
        vm.save = save;
        vm.deleteEmployee = deleteEmployee;
        vm.deleteDependent = deleteDependent;

        init();

        function init() {
            employeeService.getEmployee($stateParams.employeeId).then(
                function (success) {
                    var employee = success.data;
                    employee.HireDate = new Date(Date.parse(employee.HireDate));
                    vm.employee = employee;
                },
                function (error) {
                    $rootScope.error = error.data.MessageDetail;
                }

            );
        }

        function deleteDependent(dependent){
            var dialogInst = $uibModal.open({
                templateUrl: 'app/verify/verifyModal.html',
                controller: 'verifyModalController',
                controllerAs: 'vm',
                bindToController: true,
                size: 'lg',
                windowClass: 'show',
                backdropClass: 'show',
                resolve: {
                    message: function () {
                        return 'You are about to delete a dependent. Are you sure you want to continue?';
                    }
                }
            });
            dialogInst.result.then(
                function () {
                    employeeService.deleteDependent(dependent.ID).then(
                        function (success) {
                            $state.reload();
                        },
                        function (error) {
                            $rootScope.error = error.data.MessageDetail
                        }
                    );
                }
            );
            
        }

        function save() {
            if (isValid()) {
                employeeService.updateEmployee(vm.employee).then(
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
                            if (!vm.employee.Dependents) {
                                vm.employee.Dependents = [];
                            }
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
                $uibModal.open({
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
            } else {
                $rootScope.error = vm.error;
            }
            
        }

        function deleteEmployee(){
            employeeService.deleteEmployee(vm.employee.ID).then(
                function (success) {
                    $state.go('employees');
                },
                function (error) {
                    $rootScope.error = error.data.MessageDetail;
                }
            );
        }
    }
})();
