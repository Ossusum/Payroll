(function () {
    'use strict';

    angular
        .module('app')
        .controller('dependentModalController', dependentModalController);

    dependentModalController.$inject = ['$uibModalInstance','employee'];

    function dependentModalController($uibModalInstance, employee) {
        /* jshint validthis:true */
        var vm = this;
        vm.dependent = {
            Relationship: 0
        };
        vm.options = [
            {
                name: 'Child',
                value: 0
            },
            {
                name: 'Spouse',
                value: 1
            }
        ];

        vm.save = save;
        vm.cancel = cancel;

        function save() {
            employee.Dependents.push(vm.dependent)
            $uibModalInstance.close(employee);
        }

        

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
    }
})();
