(function () {
    angular.module('app').controller('app.views.sys.roles.index', [
        '$scope', '$uibModal', 'abp.services.app.role',
        function ($scope, $uibModal, roleService) {
            var vm = this;
            vm.loading = true;
            vm.roles = [];

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
                var s = roleService.getRoles(vm.requestParams).then(function(result) {
                    vm.option.all = result.data.totalCount;
                    vm.option.count = result.data.totalCount % defaultPageSize > 0 ? (parseInt((result.data.totalCount / defaultPageSize) + 1) > 8 ? 8 : parseInt((result.data.totalCount / defaultPageSize) + 1) > 8) : (parseInt(result.data.totalCount / defaultPageSize) > 8 ? 8 : parseInt(result.data.totalCount / defaultPageSize));
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
                            Id: role === null ? null : role.id
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