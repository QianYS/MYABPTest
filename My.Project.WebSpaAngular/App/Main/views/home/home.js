(function () {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', '$q',
        function ($scope, $q) {
            var vm = this;
            vm.initializing = true;//初始化中

            //初始化数据
            vm.init = function () {
                $q.all([

                ]).then(function () {

                }).finally(function () {
                    vm.initializing = false;
                });
            }
            vm.init();


        }
    ]);
})();