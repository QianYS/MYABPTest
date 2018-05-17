(function () {
    angular.module('app').controller('app.views.users.createOrEditModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.user', 'Entity',
        function ($scope, $uibModalInstance, userService, Entity) {            
            var vm = this;
            vm.title=Entity.Id == null?"新增用户":"修改用户";
            vm.user = {
                isActive: true
            };

            vm.roles = [];

            vm.getAssignedRoleCount = function () {
                return _.where(vm.roles, { isAssigned: true }).length;
            };

            var setAssignedRoles = function (user, roles) {
                for (var i = 0; i < roles.length; i++) {
                    var role = roles[i];
                    role.isAssigned = $.inArray(role.name, user.roles) >= 0;
                }
            }

            var init = function () {
                userService.getRoles()
                    .then(function (result) {
                        vm.roles = result.data.items;
                        if (Entity.Id != null)
                        {
                            userService.get({ id: Entity.Id })
                                .then(function (result) {
                                    console.log(result);
                                    vm.user = result.data;
                                    setAssignedRoles(vm.user, vm.roles);
                                });
                        }
                    });
            }
            
            vm.save = function () {
                vm.saving=true;
                var assingnedRoles = [];
                for (var i = 0; i < vm.roles.length; i++) {
                    var role = vm.roles[i];
                    if (!role.isAssigned) {
                        continue;
                    }
                    assingnedRoles.push(role.name);
                }
                vm.user.roleNames = assingnedRoles;
                if(vm.user.id != 0 && vm.user.id != null)
                {
                    userService.update(vm.user)
                        .then(function () {
                            abp.notify.info(App.localize('SavedSuccessfully'));
                            vm.saving=false;
                            $uibModalInstance.close();
                        });
                }
                else
                {
                    userService.create(vm.user)
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

            //getRoles();

            init();
        }
    ]);
})();