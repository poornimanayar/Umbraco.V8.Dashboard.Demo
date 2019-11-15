angular.module("umbraco").controller("DinoIpsumController", function ($http) {
    var vm = this;
    vm.paragraphs = 5;
    vm.words = 100;
    vm.format = "html";
    vm.getDinoIpsum = function() {
        $http({
            url: "http://dinoipsum.herokuapp.com/api/",
            method: "GET",
            params: {
                format: vm.format,
                words: vm.words,
                paragraphs: vm.paragraphs
            }
        }).then(function (response) {
            angular.element('#dinoipsum').html(response.data);
        });
    };

    vm.getDinoIpsum();
});