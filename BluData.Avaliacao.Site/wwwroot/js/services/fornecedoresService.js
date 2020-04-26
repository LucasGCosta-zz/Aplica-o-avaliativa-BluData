(function (angular) {
    angular.module(appName)
        .factory('fornecedoresService', ['$resource', function ($resource) {
            var res = $resource(baseUri + 'fornecedor/:id', { id: '@id' }, {
                update: {
                    method: 'PUT'
                },
                getTelefones: {
                    method: 'GET',
                    url: baseUri + 'fornecedor/:id/telefones'
                }
            });

            return res;
        }]);

})(angular);