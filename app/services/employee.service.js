(function () {
    'use strict';

    angular
        .module('app')
        .factory('employeeService', employeeService);

    function employeeService($http, $rootScope, constantService, $filter) {
        var service = {
            getEmployees: getEmployees,
            addEmployee: addEmployee,
            getEmployee: getEmployee,
            deleteEmployee: deleteEmployee,
            deleteDependent: deleteDependent,
            updateEmployee: updateEmployee,
            isValid: isValid,
            previewCosts: previewCosts,
            isDeductable: isDeductable,
            findYearlyWageMultiplier: findYearlyWageMultiplier
        };
        return service;

        ////////////

        function getEmployees() {
            return $http.get('/api/Employee');
        }

        function getEmployee(id) {
            return $http.get('/api/Employee/'+ id);
        }

        function addEmployee(employee) {
            return $http.put('/api/Employee', employee);
        }

        function deleteEmployee(id) {
            return $http.post('/api/Employee/delete', id);
        }
        function deleteDependent (id) {
            return $http.post('/api/Employee/DeleteDependent', id);
        }

        function updateEmployee(employee) {
            return $http.post('/api/Employee', employee);
        }

        function isValid(employee) {
            if (!employee) {
                return { isValid:false, message:'Empty Employee'};
            } else {
                if (!employee.FirstName) {
                    return { isValid: false, message: 'Empty First Name' };
                }
                if (!employee.LastName) {
                    return { isValid: false, message: 'Empty First Name' };
                }
                if (!employee.HireDate) {
                    return { isValid: false, message: 'Empty First Name' };
                }
                if (!employee.Wage) {
                    return { isValid: false, message: 'Empty Wage' };
                } else {
                    if (employee.Wage < 0) {
                        return { isValid: false, message: 'Wage can not be below.' };
                    }
                }
                return { isValid: true, message: '' };
            }
        }

        function previewCosts(employee) {
            var companyDeduction = {
                value: $rootScope.company.EmployeeDeduction / 100,
                description: ($rootScope.company.EmployeeDeduction) + '%'
            };
            var totalCost = {
                value: (employee.Dependents == null ? $rootScope.company.CostPerEmployee : ($rootScope.company.CostPerEmployee + ($rootScope.company.CostPerDependent * employee.Dependents.length))),
                description: (employee.Dependents == null ? '$' + $rootScope.company.CostPerEmployee : '$' + $rootScope.company.CostPerEmployee + ' + ' + '( $' + $rootScope.company.CostPerDependent + '*' + employee.Dependents.length + ')')
            };
            var benefitsDeduction = {
                value: totalCost.value * companyDeduction.value,
                description: $filter('currency')(totalCost.value) + ' x ' + companyDeduction.description
            };
            var deductedWage = {
                value: employee.Wage * findYearlyWageMultiplier() - benefitsDeduction.value,
                description: $filter('currency')(employee.Wage) + ' - ' + $filter('currency')(benefitsDeduction.value)
            };
            var netWage = {
                value: (isDeductable(employee) ? (deductedWage.value + (benefitsDeduction.value * 0.1)): deductedWage.value ),
                description: '$' + (isDeductable(employee) ? (deductedWage.value + (benefitsDeduction.value * 0.1)): deductedWage.value )
            };

            var previewCost = {
                companyDeduction: companyDeduction,
                totalCost: totalCost,
                benefitsDeduction: benefitsDeduction,
                deductedWage: deductedWage,
                netWage: netWage
            };

            return previewCost;
        }

        function findYearlyWageMultiplier() {
            switch ($rootScope.company.PaySchedule) {
                case constantService.PaySchedules[0].value:
                    return 52;
                    break;
                case constantService.PaySchedules[1].value:
                    return 26;
                    break;
                case constantService.PaySchedules[2].value:
                    return 12;
                    break;
                case constantService.PaySchedules[3].value:
                    return 1;
                    break;
                default:
                    return 26;
                    break;
            }
        }

        function isDeductable(employee) {
            if (employee.Dependents) {
                if (employee.Dependents.length > 0) {
                    return employee.FirstName.includes("a") ||  employee.Dependents.filter(dependent => dependent.FirstName.includes("a")).length > 0;
                }
            }
            
            return employee.FirstName.includes("a");

        }
    }
}) ();