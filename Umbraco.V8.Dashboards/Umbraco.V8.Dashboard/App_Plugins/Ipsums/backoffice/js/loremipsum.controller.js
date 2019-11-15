angular.module("umbraco").controller("LoremIpsumController", function ($http) {
    var vm = this;
    vm.paragraphs = 5;
    vm.words = 100;
    vm.format = "html";
    vm.includeLinks = 1;
    vm.includeUl = 1;
    vm.includeOl = 1;
    vm.includeHeadings = 1;
    vm.includeCode = 1;

    vm.getLoremIpsum = function() {
        $http({
            url: "https://loripsum.net/generate.php",
            method: "GET",
            params: {
                format: vm.format,
                words: vm.words,
                p: vm.paragraphs,
                links: vm.includeLinks,
                ul: vm.includeUl,
                ol: vm.includeOl,
                h: vm.includeHeadings,
                co:vm.includeCode
            }
        }).then(function (response) {
            angular.element('#loremipsum').html(response.data);
        });
    };

    vm.toggle = function(param) {
        if (param === "includeLinks") {
            vm.includeLinks = vm.includeLinks === 1 ? 0 : 1;
        }

        if (param === "includeOl") {
            vm.includeOl = vm.includeOl === 1 ? 0 : 1;
        }

        if (param === "includeUl") {
            vm.includeUl = vm.includeUl === 1 ? 0 : 1;
        }

        if (param === "includeHeadings") {
            vm.includeHeadings = vm.includeHeadings === 1 ? 0 : 1;
        }

        if (param === "includeCode") {
            vm.includeCode = vm.includeCode === 1 ? 0 : 1;
        }
    };

    vm.getLoremIpsum();
});