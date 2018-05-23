(function () {
    angular.module('app').controller('app.views.roles.createOrEditModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.role', 'Entity',
        function ($scope, $uibModalInstance, roleService, Entity) { 
            var vm = this;
            vm.title=Entity.Id == null?"新增角色":"修改角色";
            vm.user = {
                isActive: true
            };

            vm.roles = [];

            var init = function () {
                roleService.getRoleForEdit({ Id : Entity.Id })
                    .then(function (result) {
                        vm.role = result.data.role;
                        vm.permissionEditData = {
                            permissions: result.data.permissions,
                            grantedPermissionNames: result.data.grantedPermissionNames
                        };
                    });
            }
            
            vm.save = function () {
                vm.saving = true;
                if(Entity.Id==null||Entity.Id=="")
                {

                }else
                {
                    roleService.createOrUpdateRole({
                        role: vm.role,
                        grantedPermissionNames: vm.permissionEditData.grantedPermissionNames
                    }).then(function () {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
                }
                
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            //getRoles();

            init();
        }
    ]);
})();