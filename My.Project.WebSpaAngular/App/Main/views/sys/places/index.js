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
            //查询参数 & 分页组件参数
            vm.requestParams = {
                filter: '',
                skipCount: 0,
                maxResultCount: defaultPageSize,
                sorting: null,
                deep: 1,
                isParentOrSon: true,
                //页码点击跳转
                click: function (page) {
                    vm.requestParams.skipCount = (page - 1) * defaultPageSize;
                    vm.getGridData()
                }
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
                    vm.requestParams.totalCount = result.data.totalCount
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
                            Code: place == null ? null : place.code,
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
                vm.requestParams.code = "";
                vm.requestParams.deep = 1;
                vm.requestParams.isParentOrSon = true;
                vm.getGridData();
            };

            vm.getSearch = function () {
                vm.requestParams.code = "";
                vm.requestParams.deep = null;
                vm.getGridData();
            }

            vm.getGridData();

        }
    ]);
})();