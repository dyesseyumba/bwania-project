'use strict';

app.controller('redirectionLoginCtrl2', ['$scope', 'UserFactory', '$location', function($scope, UserFactory, $location) {

       //Masquer le message d'érreur
        $scope.submited = true;
         $scope.accountActivated = true;

        //Utilisation de l'évènement ng-submit = "submitLogin"
        $scope.submitLogin = function(userEmail) {

            UserFactory.setConnectedUser(userEmail);

            UserFactory.connectUser.login(null, $scope.user,
                    function() {
                    	$location.path('/home');
                        $scope.submited = true;
                        $scope.accountActivated = true;
                    },
                    function(data) {
                        if (data.data === "compte nom activé") {
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