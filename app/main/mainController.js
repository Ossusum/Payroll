(function () {
    'use strict';

    angular
        .module('app')
        .controller('mainController', mainController);

    mainController.$inject = ['$uibModal', '$rootScope', '$scope'];

    function mainController($uibModal, $rootScope , $scope) {
        var vm = this;

        vm.error = $rootScope.error;

        vm.showError = showError;

        $scope.$watch('$root.error', function () {
            vm.error = $rootScope.error;
            vm.showError();
        });
      
        function showError() {
            if (vm.error) {
                var dialogInst = $uibModal.open({
                    templateUrl: 'app/error/errorModal.html',
                    controller: 'errorModalController',
                    controllerAs: 'vm',
                    bindToController: true,
                    windowClass: 'show',
                    backdropClass: 'show',
                    size: 'lg',
                    resolve: {
                        error: function () {
                            return vm.error;
                        }
                    }
                });
                dialogInst.result.then(
                    function (newEmployee) {
                        $rootScope.error = null;
                    },
                    function () {
                        $rootScope.error = null;
                    }
                );
            }
        }


    }
})();
