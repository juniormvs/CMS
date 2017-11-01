var buscaApp = angular.module('buscaApp', []);

buscaApp.controller('buscaController', function ($scope, BuscaService, $interval) {

    $scope.listaImoveis;
    $scope.buscaImoveisLoaded = true;
    
    this.buscarImoveis = function () {
        BuscaService.buscar().then(function successCallback(dados) {
            console.log('dados', dados);
            $scope.listaImoveis = null;
            $scope.listaImoveis = dados;
            $scope.buscaImoveisLoaded = false;
        }, function errorCallback(error) {
            $scope.buscaImoveisLoaded = false;
            console.log('error', error);
        });
    };

    this.buscarImoveis();

});

buscaApp.factory('BuscaService', function ($http, $q, $location) {

    //var url = 'http://localhost:55534/Busca/BuscaAssincrono?Id=&CidadeUrl=&Endereco=&BairroUrl=jardim-sao-gabriel&TipoImovelId=&TipoContratoId=&Valor=Valor+a+partir+de+R%2450000%2C+at%C3%A9+R%24300000';
    var url = 'http://localhost:55534/Busca/BuscaAssincrono';

    return {
        buscar: function () {
            var deferred = $q.defer();

            $http.get(url).then(function successCallback(response) {
                deferred.resolve(response.data);
            }, function errorCallback(error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }
    }

});