(function () {
    angular.module('app').controller('app.views.sys.users.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.user',
        function ($scope, $timeout, $uibModal, userService) {
            var vm = this;
            vm.loading = true;
            vm.users = [];

            //页面数据显示条数
            var defaultPageSize = 20;

            // 分页组件参数
            vm.option = {
                curr: 1, //当前页数
                //all: 20, //总页数
                size: defaultPageSize, //每页显示最大条数
                //count: 3, //最多显示的页数，默认为10
                //点击页数的回调函数，参数page为点击的页数
                click: function (page) {
                    vm.requestParams.skipCount = (page - 1) * defaultPageSize;
                    vm.option.curr = page;
                    vm.getGridData()
                    //这里可以写跳转到某个页面等...
                }
            }
            
            //查询参数 & 分页组件参数
            vm.requestParams = {
                filter: '',
                skipCount: 0,
                maxResultCount: defaultPageSize,
                sorting: null,
            };
            
            vm.getGridData = function () {
                vm.loading = true;
                var s = userService.getAll(vm.requestParams).then(function (result) {
                    vm.option.all = result.data.totalCount;
                    vm.option.count = result.data.totalCount % defaultPageSize > 0 ? (parseInt((result.data.totalCount / defaultPageSize) + 1) > 8 ? 8 : parseInt((result.data.totalCount / defaultPageSize) + 1) > 8) : (parseInt(result.data.totalCount / defaultPageSize) > 8 ? 8 : parseInt(result.data.totalCount / defaultPageSize));
                    vm.users = result.data.items;
                }).finally(function () {
                    vm.loading = false;
                });
            };
            
            //打开编辑窗口 新增或修改
            vm.createOrEditModal = function (entity) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/Main/views/sys/users/createOrEditModal.cshtml',
                    controller: 'app.views.sys.users.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        Entity: {
                            Id: entity === null ? null : entity.id
                        },
                    }
                });
                modalInstance.result.then(function (result) {
                    vm.getGridData();
                }, function () {
                    // 处理dismiss，必须保留这个function
                });
            }

            //打开编辑窗口 设置权限
            vm.editPermission = function (id) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/Main/views/sys/users/editPermissionModel.cshtml',
                    controller: 'app.views.sys.users.editPermissionModel as vm',
                    backdrop: 'static',
                    resolve: {
                        Entity: {
                            Id: id
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