angular.module("umbraco").controller("PictureOfTheDayController", function (userService, $http, $sce) {
    var vm = this;
    vm.title = "Hello, here is an umbazing picture for you!!!";

    userService.getCurrentUser().then(function (user) {
        vm.title = "Welcome " + user.name + ", here is an umbazing picture for you!!!";
    });

    $http.get("https://api.nasa.gov/planetary/apod?api_key=9LeHWFqoCqowcoqRsAuDWTV0Qvg06p12hMw4Qvyg&hd=true")
        .then(function (response) {
            vm.pictureOfTheDay = response.data;
        });

    vm.trustSrc = function (src) {
        return $sce.trustAsResourceUrl(src);
    }

});