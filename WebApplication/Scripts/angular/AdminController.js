var app = angular.module('appAdmin', []);

app.controller('adminCtrl', function ($scope, $http, $window) {
    
    $http.get("http://" + $window.location.host +"/Administrativo/Empresa/ObterSkin").then(function (response) {
        $scope.bodyCss = response.data;
    });
});