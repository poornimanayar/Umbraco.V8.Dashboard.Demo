angular.module("umbraco").controller("PictureOfTheDayController", function (userService, $http) {
    var vm = this;
    vm.userName = "guest";

    userService.getCurrentUser().then(function (user) {
        vm.userName = user.name;
    });

    $http.get("https://api.nasa.gov/planetary/apod?api_key=9LeHWFqoCqowcoqRsAuDWTV0Qvg06p12hMw4Qvyg&hd=true")
        .then(function (response) {
            vm.pictureOfTheDay = response.data;
        });
});