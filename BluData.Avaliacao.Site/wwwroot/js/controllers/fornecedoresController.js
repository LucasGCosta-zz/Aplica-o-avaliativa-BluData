(function (angular) {
    angular.module(appName).controller('fornecedoresController', fornecedoresController);

    fornecedoresController.$inject = ['$scope', '$http', '$filter', 'fornecedoresService', 'empresasService'];

    function fornecedoresController($scope, $http, $filter, fornecedoresService, empresasService) {

        $scope.fornecedores = [];

        $scope.telefones = [];

        function fixDates(fornecedor) {
            fornecedor.dataNascimento = $filter("date")(fornecedor.dataNascimento, 'dd/MM/yyyy');
            fornecedor.dataCadastro = $filter("date")(fornecedor.dataCadastro, 'dd/MM/yyyy');
        }

        empresasService.query(function (empresas) {
            $scope.empresas = empresas;

            fornecedoresService.query(function (fornecedores) {
                fornecedores.forEach(function ($this) {
                    $this.empresa = $scope.empresas.find(x => x.id == $this.empresaId);
                    fixDates($this);
                });
                $scope.fornecedores = fornecedores;
            });
        })

        $scope.save = function save(fornecedor) {
            fornecedor.empresaId = fornecedor.empresa.id;
            fornecedor.empresa = null;

            fornecedoresService.save(fornecedor)
                .$promise
                .then((result) => {
                    fixDates(result);
                    $scope.fornecedores.push(result);
                    $scope.fornecedor.empresa = $scope.empresas.find(x => x.id == $scope.fornecedor.empresaId);
                    $scope.fornecedor = null;
                }, (headers) => alert(headers.data.Message));

        }

        $scope.new = function () {
            $scope.fornecedor = {};
        }

        $scope.edit = function (fornecedor) {
            $http.get(baseUri + 'fornecedor/' + fornecedor.id + '/telefones')
                .then((result) => {;
                    fornecedor.telefones = result.data.telefones;
                    $scope.fornecedor = fornecedor;
                });
        }
        $scope.delete = function (fornecedor) {
            fornecedor.$remove();
            var index = $scope.fornecedores.indexOf(fornecedor);
            $scope.fornecedores.splice(index, 1);
        }

        $scope.addTelefone = function (telefone) {
            if (!$scope.fornecedor.telefones)
                $scope.fornecedor.telefones = [];

            $scope.fornecedor.telefones.push(telefone);
            $scope.fornecedor.telefone = null;
        }

        $scope.removeTelefone = function (telefone) {

            $http.delete(baseUri + 'telefone/' + telefone.id);

            var index = $scope.fornecedor.telefones.indexOf(telefone);
            $scope.fornecedor.telefones.splice(index, 1);
        }
    }
})(angular);