'use strict';

app.controller('menuCtrl', ['$scope', '$location', 'UserFactory', '$cookieStore', function($scope, $location, UserFactory, $cookieStore) {

        
       $scope.isCurrentMenu = function(menu) {
            return $location.path() === menu;
        };


    }]);


