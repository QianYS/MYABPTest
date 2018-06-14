(function () {
    angular.module('app').controller('app.views.sys.roles.index', [
        '$scope', '$uibModal', 'abp.services.app.role',
        function ($scope, $uibModal, roleService) {
            var vm = this;
            vm.loading = true;
            vm.roles = [];
            //页面数据显示条数
            var defaultPageSize = 20;
            //查询参数 & 分页组件参数
            vm.requestParams = {
                filter: '',
                skipCount: 0,
                maxResultCount: defaultPageSize,
                sorting: null,
                //页码点击跳转
                click: function (page) {
                    vm.requestParams.skipCount = (page - 1) * defaultPageSize;
                    vm.getGridData()
                }
            };

            vm.getGridData = function () {
                vm.loading = true;
                var s = roleService.getRoles(vm.requestParams).then(function(result) {
                    vm.roles = result.data.items;
                }).finally(function () {
                    vm.loading = false;
                });
            };

            vm.createOrEditModal = function (role) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/Main/views/sys/roles/createOrEditModal.cshtml',
                    controller: 'app.views.sys.roles.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        Entity: {
                            Id: role == null ? null : role.id
                        },
                    }
                });
                modalInstance.result.then(function (result) {
                    vm.getGridData();
                }, function () {
                    // 处理dismiss，必须保留这个function
                });
            };

            vm.delete = function (role) {
                abp.message.confirm(
                    "Delete role '" + role.name + "'?",
                    function (result) {
                        if (result) {
                            roleService.delete({ id: role.id })
                                .then(function () {
                                    abp.notify.info("Deleted role: " + role.name);
                                    vm.getGridData();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                vm.getGridData();
            };

            vm.getGridData();
        }
    ]);
})();