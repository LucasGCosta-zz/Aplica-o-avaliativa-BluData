(function (angular) {
    angular.module(appName)
        .factory('empresasService', ['$resource', function ($resource) {
            var res = $resource(baseUri + 'empresa/:id', { id: '@id' }, {
                update: {
                    method: 'PUT'
                }
            });

            return res;
        }]);

})(angular);