angular.module("umbraco").controller("BaconIpsumController", function ($http) {
    var vm = this;
    vm.paragraphs = 5;
    vm.words = 100;
    vm.format = "html";
    vm.getBaconIpsum = function() {
        $http({
            url: "https://baconipsum.com/api/",
            method: "GET",
            params: {
                format: vm.format,
                type: "meat-and-filler",
                paras: vm.paragraphs
            }
        }).then(function (response) {
            angular.element('#baconipsum').html(response.data);
        });
    };

    vm.getBaconIpsum();
});