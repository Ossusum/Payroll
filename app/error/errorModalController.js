(function () {
    'use strict';

    angular
        .module('app')
        .controller('errorModalController', errorModalController);

    errorModalController.$inject = ['$uibModalInstance', 'error', '$rootScope'];

    function errorModalController($uibModalInstance, error, $rootScope) {
        /* jshint validthis:true */
        var vm = this;
        vm.error = error;
        vm.confirm = confirm;

        function confirm() {
            $rootScope.error = null;
            $uibModalInstance.dismiss('confirmed');
        }
    }
})();
