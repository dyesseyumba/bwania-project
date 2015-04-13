'use strict';

app.controller('loginCtrl', ['$scope', 'UserFactory', '$location', function($scope, UserFactory, $location) {

        //Masquer le message d'érreur
        $scope.submited = true;
        $scope.accountActivated = true;

        //Utilisation de l'évènement ng-submit = "submitLogin"
        $scope.submitLogin = function(userEmail) {

            //Enregistrement de l'email dans le coocky
            UserFactory.setConnectedUser(userEmail);

            UserFactory.connectUser.login(null, $scope.user,
                    function() {
                        $location.path('/home');
                    },
                    function(data) {
                        if (data.data.message === "compte non activé") {
                            $scope.submited = true;
                            $scope.accountActivated = false;
                        }
                        else {
                            $scope.submited = false;
                            $scope.accountActivated = true;
                        }
                    });
        };
    }]);