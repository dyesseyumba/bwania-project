'use strict';

app.controller('signupCtrl', ['$scope', 'UserFactory', '$cookieStore', function($scope, UserFactory, $cookieStore) {

        //Masquer le message d'érreur
        $scope.submited = true;
        $scope.errorPassword = true;
        $scope.errorEmail = true;
        $scope.errorPassword2 = true;
        
        //Utilisation de l'évènement ng-click = "createUser"
        $scope.createUser = function(newUser) {

            UserFactory.setConnectedUser(newUser);


            UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
            function() {
                $scope.errorEmail = false;
            }, function() {
                $scope.errorEmail = true;
                if ($scope.user.motDepasse.length < 8) {
                    $scope.errorPassword2 = false;
                }
                else if ($scope.user.motDepasse === $scope.password2) {
                    UserFactory.registerUser.create(null,
                            $scope.user,
                            function() {
                                $scope.submited = true;
                            },
                            function() {
                                $scope.submited = false;
                            });
                }
                else {
                    $scope.errorPassword2 = true;
                    $scope.errorPassword = false;
                }
            });

        };

        //Configuere la date maximale du date picker
        $scope.dateMax = new Date();
        $scope.open = function($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
  };
    }]);