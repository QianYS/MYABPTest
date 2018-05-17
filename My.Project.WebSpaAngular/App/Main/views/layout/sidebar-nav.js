(function () {
    var controllerId = 'app.views.layout.sidebarNav';
    angular.module('app').controller(controllerId, [
        '$scope', '$rootScope', '$state', 'appSession', '$timeout',
        function ($scope ,$rootScope, $state, appSession, $timeout) {
            var vm = this;
            vm.activeMenu = function (menuItem) {
                var isActive = false;
                if (menuItem.name === vm.currentMenuName) {
                    isActive = true;
                } else if (menuItem.items.length) {
                    for (var i = 0; i < menuItem.items.length; i++) {
                        if (vm.activeMenu(menuItem.items[i])) {
                            isActive = true;
                        }
                    }
                }
                menuItem.isActive = isActive;
                return isActive;
            }

            //修正页面高度
            vm.fixLayout = function (delay) {
                delay = delay || 100;
                $timeout(function () {
                    if ($.AdminLTE.layout) {
                        $.AdminLTE.layout.fix();
                    }
                }, delay);
            }

            vm.menu = abp.nav.menus.MainMenu;
            vm.currentMenuName = $state.current.menu;
            vm.activeMenu(vm.menu);

            vm.fixLayout();//计算页面大小

            $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
                vm.currentMenuName = toState.menu;
                vm.activeMenu(vm.menu);
                vm.fixLayout();//计算页面大小
            });
        }
    ]);
})();