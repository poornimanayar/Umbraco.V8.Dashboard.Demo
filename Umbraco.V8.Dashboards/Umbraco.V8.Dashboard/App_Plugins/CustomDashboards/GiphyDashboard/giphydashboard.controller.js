angular.module("umbraco").controller("GiphyDashboardController", function ($scope, $http) {
    var vm = this;
    vm.searchText = '';
    vm.pageNumber = 0;
    vm.gifs = [];

    vm.searchGifs = function () {
        vm.pageNumber = 0;
        vm.gifs = [];
        loadGifs();
    };

    vm.showMore = function() {
        loadGifs();
    };

    function loadGifs() {
        $http({
            url: "https://api.giphy.com/v1/gifs/search",
            method: "GET",
            params: {
                api_key: "Ac3RTfhw9Slz3fvh1jYr0sPemTx3Wrh8",
                q: vm.searchText,
                limit: 25,
                offset: (vm.pageNumber * 25),
                rating: "G",
                lang: "en"
            }
        }).then(function (response) {
            if (response.data.meta.msg === "OK") {
                angular.forEach(response.data.data,
                    function (item) {
                        vm.gifs.push(item);
                    });
            }
            vm.pageNumber = vm.pageNumber + 1;
        });
    }
});