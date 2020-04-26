(function (angular) {
    angular.module(appName).controller('empresasController', empresasController);

    empresasController.$inject = ['$scope', 'empresasService'];

    function empresasController($scope, empresasService) {

        $scope.empresas = [];

        empresasService.query(function (empresas) {
            $scope.empresas = empresas;
        });

        $scope.save = function save(empresa) {
            empresasService.save(empresa)
                .$promise
                .then((result, b) => $scope.empresas.push(result));

            $scope.empresa = {};
        }

        $scope.allowEdit = function (empresa) {
            empresa.editing = true;
        }

        $scope.update = function (empresa) {
            empresa.$update();
            empresa.editing = false;
        }

        $scope.delete = function (empresa) {
            empresa.$remove();
            var index = $scope.empresas.indexOf(empresa);
            $scope.empresas.splice(index, 1);    
        }

        $scope.canSave = function (empresa) {
            return empresa.uf && empresa.cnpj && empresa.nomeFantasia;
        }
    }
})(angular);