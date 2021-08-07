(function () {
    'use strict';

    angular
        .module('app')
        .factory('companyService', companyService);

    function companyService($http) {
        var service = {
            getCompanyDetails: getCompanyDetails,
            updateCompanyDetails: updateCompanyDetails,
            isValid: isValid
        };
        return service;

        ////////////

        function getCompanyDetails() {
            return $http.get('/api/Company');
        }

        function updateCompanyDetails(company) {
            return $http.post('/api/Company', company );
        }

        function isValid(company) {
            if (!company) {
                return { isValid: false, message: 'Empty Company' };
            } else {
                if (!company.CostPerEmployee) {
                    return { isValid: false, message: 'Empty Cost Per Employee' };
                }
                if (!company.CostPerDependent) {
                    return { isValid: false, message: 'Empty Cost Per Dependent' };
                }
                if (!company.PaySchedule) {
                    return { isValid: false, message: 'Empty Pay Schedule' };
                }
                if (!company.DefaultEmployeeSalary) {
                    return { isValid: false, message: 'Empty Employee Deduction' };
                } else {
                    if (company.DefaultEmployeeSalary < 0) {
                        return { isValid: false, message: 'Default Employee Salary can not be below zero.' };
                    }
                }
                if (!company.EmployeeDeduction) {
                    return { isValid: false, message: 'Empty Employee Deduction' };
                } else {
                    if (company.EmployeeDeduction < 0) {
                        return { isValid: false, message: 'Employee Deduction can not be below zero.' };
                    }
                }
                
                return { isValid: true, message: '' };
            }
        }
    }
})();