(function () {
    angular.module('app').controller('app.views.users.editPermissionModel', [
        '$scope', '$uibModalInstance', 'abp.services.app.user', 'Entity',
        function ($scope, $uibModalInstance, userService, Entity) { 
            var vm = this;
            vm.title = "修改权限";
            vm.user = {
                isActive: true
            };

            vm.roles = [];

            var init = function () {
                userService.getPermissionForEdit({ Id : Entity.Id })
                    .then(function (result) {
                        vm.role = result.data.role;
                        vm.permissionEditData = {
                            permissions: result.data.permissions,
                            grantedPermissionNames: result.data.grantedPermissionNames
                        };
                    });
            }
            
            //vm.save = function () {
            //    vm.saving = true;
            //    if(Entity.Id == null || Entity.Id == "")
            //    {
            //        roleService.create({
            //            role: vm.role,
            //            grantedPermissionNames: vm.permissionEditData.grantedPermissionNames
            //        }).then(function () {
            //            abp.notify.success('SavedSuccessfully');
            //            $uibModalInstance.close();
            //        }).finally(function () {
            //            vm.saving = false;
            //        });
            //    }else
            //    {
            //        roleService.update({
            //            role: vm.role,
            //            grantedPermissionNames: vm.permissionEditData.grantedPermissionNames
            //        }).then(function () {
            //            abp.notify.success('SavedSuccessfully');
            //            $uibModalInstance.close();
            //        }).finally(function () {
            //            vm.saving = false;
            //        });
            //    }
                
            //};

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            //getRoles();

            init();
        }
    ]);
})();