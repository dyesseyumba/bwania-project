'use strict';

app.controller('creerEntrepriseCtrl', ['$scope', 'UserFactory', '$cookieStore', '$location',
    function($scope, UserFactory, $cookieStore, $location) {

        //Masquer le message d'érreur
        $scope.submited = true;

        
            //Consommation du service de création d'un établissement
            $scope.addEntreprise = function(entreprise) {
                UserFactory.addEntreprise.saveEse(entreprise);
            };
        
    }]);
