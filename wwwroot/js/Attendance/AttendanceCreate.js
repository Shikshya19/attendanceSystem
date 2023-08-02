angular.module('AttendanceForm', [])
    .controller('AttendanceController', ['$scope', function ($scope) {
        $scope.init = function ()
        {
            alert("Hello I am here");
        }
        console.log("Hello");
        $scope.firstName = "John";
        $scope.lastName = "Doe";
        $scope.init();

        $scope.onClickSubmitBtn = function () {
            alert("Btn is working")
        }
    }]);