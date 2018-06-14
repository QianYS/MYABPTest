(function () {
    angular.module('app').controller('app.views.sys.places.createOrEditModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.place', 'Entity',
        function ($scope, $uibModalInstance, placeService, Entity) { 
            var vm = this;
            vm.title = Entity.Code == null ? "新增省级地区" : (Entity.IsChangedOrCreate ? "修改地区" : "新增下辖地区");
            vm.place = {
                
            };

            var init = function () {
                placeService.getForCreateChildOrEdit({ Code: Entity.Code, CreateChildOrEdit: Entity.IsChangedOrCreate})
                    .then(function(result){
                        console.log(result);
                        vm.place=result.data;
                    })
            }
            
            vm.save = function () {
                vm.saving=true;
                if(vm.place.id != 0 && vm.place.id != null)
                {
                    placeService.update(vm.place)
                        .then(function () {
                            abp.notify.info(App.localize('SavedSuccessfully'));
                            vm.saving=false;
                            $uibModalInstance.close();
                        });
                }
                else
                {
                    placeService.create(vm.place)
                        .then(function () {
                            abp.notify.info(App.localize('SavedSuccessfully'));
                            vm.saving=false;
                            $uibModalInstance.close();
                        });
                }
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };



            init();
        }
    ]);
})();