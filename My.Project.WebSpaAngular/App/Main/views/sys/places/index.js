(function () {
    angular.module('app').controller('app.views.sys.places.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.place',
        function ($scope, $timeout, $uibModal, placeService) {
            console.log($uibModal);
            var vm = this;
            vm.loading = true;
            vm.places = [];

            //页面数据显示条数
            var defaultPageSize = 20;

            // 分页组件参数
            vm.option = {
                curr: 1, //当前页数
                //all: 20, //总页数
                size: defaultPageSize, //每页显示最大条数
                //count: 3, //最多显示的页数，默认为10
                //点击页数的回调函数，参数page为点击的页数
                click: function(page) {
                    vm.requestParams.skipCount = (page - 1) * defaultPageSize;
                    vm.option.curr = page;
                    vm.getGridData()
                    //这里可以写跳转到某个页面等...
                }
            }

            //查询参数
            vm.requestParams = {
                filter: '',
                skipCount: 0,
                maxResultCount: defaultPageSize,
                sorting: null,
                deep: 1,
                isParentOrSon: true,
            };

            vm.getParentList = function (entity) {
                vm.requestParams.filter =" ";
                vm.requestParams.code = entity.parentCode;
                vm.requestParams.deep = entity.deep - 1;
                vm.requestParams.isParentOrSon = false;
                vm.getGridData();
            }

            vm.getChildList = function(entity){
                vm.requestParams.filter =" ";
                vm.requestParams.code = entity.code;
                vm.requestParams.deep = entity.deep + 1;
                vm.requestParams.isParentOrSon = true;
                vm.getGridData();
            }
            
            vm.getGridData = function () {
                vm.loading = true;
                var s = placeService.getIndexList(vm.requestParams).then(function (result) {
                    vm.option.all = result.data.totalCount;
                    vm.option.count = result.data.totalCount % defaultPageSize > 0 ? parseInt((result.data.totalCount / defaultPageSize) + 1): parseInt(result.data.totalCount / defaultPageSize) ;
                    vm.places = result.data.items;
                }).finally(function () {
                    vm.loading = false;
                });
            };
            
            //打开编辑窗口 新增或修改
            vm.createOrEditModal = function (place,isChangedOrCreate) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/Main/views/sys/places/createOrEditModal.cshtml',
                    controller: 'app.views.sys.places.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        Entity: {
                            Code: place === null ? null : place.code,
                            IsChangedOrCreate: isChangedOrCreate
                        },
                    }
                });
                modalInstance.result.then(function (result) {
                    vm.getGridData();
                }, function () {
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
                //vm.requestParams.code = "";
                //vm.requestParams.deep = 1;
                //vm.requestParams.isParentOrSon = true;
                vm.getGridData();
            };

            vm.getSearch = function () {
                vm.requestParams.code = "";
                vm.requestParams.deep = null;
                vm.requestParams.skipCount = 0;
                vm.getGridData();
            }

            vm.getGridData();

        }
    ]);
})();