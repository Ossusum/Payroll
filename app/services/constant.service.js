(function () {
    'use strict';

    angular
        .module('app')
        .factory('constantService', constantService);

    function constantService() {
        var PaySchedules = [
            { value: 0, description: 'Weekly' },
            { value: 1, description: 'Bi-Weekly' },
            { value: 2, description: 'Monthly' },
            { value: 3, description: 'Annually' },
        ];
        var Titles = [
            { value: 0, description: 'Software Engineer' },
            { value: 1, description: 'Human Resources' },
            { value: 2, description: 'Operations' },
            { value: 3, description: 'Administrator' },
        ];

        var Relationships = [
            { value: 0, description: 'Child' },
            { value: 1, description: 'Spouse' }
        ];
        var service = {
            PaySchedules: PaySchedules,
            Titles: Titles,
            Relationships: Relationships,
            getTitleString: getTitleString,
            getPayScheduleString: getPayScheduleString,
            getRelationshipString: getRelationshipString
        };
        return service;

        ////////////
        function getTitleString(enumValue) {
            return Titles.filter(title => title.value == enumValue)[0].description;
        }
        function getPayScheduleString(enumValue) {
            return PaySchedules.filter(ps => ps.value == enumValue)[0].description;
        }
        function getRelationshipString(enumValue) {
            return Relationships.filter(relation => relation.value == enumValue)[0].description;
        }
    }
})();