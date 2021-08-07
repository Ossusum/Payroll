(function () {
    'use strict';

    angular
        .module('app')
        .controller('companyController', companyController);

    companyController.$inject = ['$rootScope', 'constantService', 'companyService', '$state'];

    function companyController($rootScope, constantService, companyService, $state) {
        
        var vm = this;
        vm.save = save;
        vm.paySchedules = constantService.PaySchedules;
        

        activate();

        function activate() {
            companyService.getCompanyDetails().then(
                function (success) {
                    $rootScope.company = success.data;
                    vm.company = $rootScope.company;
                },
                function (error) {
                    $rootScope.error = error.data.MessageDetail;
                }
            );
            
        }
        function isValid() {
            var validation = companyService.isValid(vm.company);
            vm.error = validation.message;
            return validation.isValid;
        }
        function save() {
            if (isValid()) {
                companyService.updateCompanyDetails(vm.company).then(
                    function (success) {
                        $state.reload();
                    },
                    function (error) {
                        $rootScope.error = error.data.MessageDetail;
                    }
                );
            } else {
                $rootScope.error = vm.error;
            }
        }
    }
})();
