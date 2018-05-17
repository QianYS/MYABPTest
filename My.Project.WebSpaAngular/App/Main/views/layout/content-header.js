(function () {
    var controllerId = 'app.views.layout.contentHeader';
    angular.module('app').controller(controllerId, [
        '$scope', '$rootScope', '$state',
        function ($scope, $rootScope, $state) {
            var vm = this;
            vm.MainMenu = abp.nav.menus.MainMenu;
            vm.currentMenuName = $state.current.menu;
            vm.currentMenuText = "";
            vm.breadcrumbList = [];

            vm.renderBreadcrumb = function (menus) {
                var found = false;
                if (menus) {
                    var length = menus.length;
                    for (var i = 0; i < length; i++) {
                        var child = menus[i];
                        if (child.name === vm.currentMenuName) {
                            vm.currentMenuText = child.displayName;
                            found = true;
                        } else {
                            found = vm.renderBreadcrumb(child.items);
                        }
                        if (found) {
                            vm.breadcrumbList.splice(0,0, child);
                            break;
                        }
                    }
                }
                
                return found;
            }
            vm.renderBreadcrumb(vm.MainMenu.items);
        }]);
})();