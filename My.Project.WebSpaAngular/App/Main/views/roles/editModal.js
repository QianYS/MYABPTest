(function () {
    angular.module('app').controller('app.views.roles.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.role', 'Entity',
        function ($scope, $uibModalInstance, roleService, id) {
            var vm = this;

            vm.role = {};
            vm.permissions = [];

            vm.save = function () {
                var assignedPermissions = [];

                for (var i = 0; i < vm.permissions.length; i++) {
                    var permission = vm.permissions[i];
                    if (!permission.isAssigned) {
                        continue;
                    }

                    assignedPermissions.push(permission.name);
                }

                vm.role.permissions = assignedPermissions;
                roleService.update(vm.role)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            //function init() {
            //    roleService.getRoleForEdit({
            //        id: Entity.Id
            //    }).then(function(result) {
            //        console.log(result);
            //        vm.role = result.data.role;
            //        vm.permissionEditData = {
            //            permissions: result.data.permissions,
            //            grantedPermissionNames: result.data.grantedPermissionNames
            //        };
            //    });
            //}

            init();
        }
    ]);
})();