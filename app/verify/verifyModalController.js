(function () {
    'use strict';

    angular
        .module('app')
        .controller('verifyModalController', verifyModalController);

    verifyModalController.$inject = ['$uibModalInstance', 'message'];

    function verifyModalController($uibModalInstance, message) {
        /* jshint validthis:true */
        var vm = this;
        vm.message = message;

        vm.save = save;
        vm.cancel = cancel;

        function save() {
            $uibModalInstance.close();
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
    }
})();