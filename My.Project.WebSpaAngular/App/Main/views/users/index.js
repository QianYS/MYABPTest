(function () {
    angular.module('app').controller('app.views.users.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.user',
        function ($scope, $timeout, $uibModal, userService) {
            var vm = this;
            vm.loading = true;
            vm.users = [];
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
                var s = userService.getAll(vm.requestParams).then(function (result) {
                    vm.requestParams.totalCount = result.data.totalCount
                    vm.users = result.data.items;
                }).finally(function () {
                    vm.loading = false;
                });
            };
            
            //打开编辑窗口
            vm.createOrEditModal = function (entity) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/Main/views/users/createOrEditModal.cshtml',
                    controller: 'app.views.users.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        Entity: {
                            Id: entity == null ? null : entity.id
                        },
                    }
                });
                modalInstance.result.then(function (result) {
                    vm.getGridData();
                }, function () {
                    // 处理dismiss，必须保留这个function
                });
            }

            //删除
            vm.delete = function (user) {
                abp.message.confirm(
                    "Delete user '" + user.userName + "'?",
                    function (result) {
                        if (result) {
                            userService.delete({ id: user.id })
                                .then(function () {
                                    abp.notify.info("Deleted user: " + user.userName);
                                    vm.getGridData();
                                });
                        }
                    });
            }
            //刷新
            vm.refresh = function () {
                vm.getGridData();
            };

            vm.getGridData();

        }
    ]);
})();