'use strict';

app.controller('CreerEtablissementCtrl', ['$scope', 'UserFactory', '$cookieStore', '$location',
    function($scope, UserFactory, $cookieStore, $location) {

        //Masquer le message d'érreur
        $scope.submited = false;
        $scope.submited = false;

        if ($cookieStore.get('login_status') === true) {
            //Consommation du service de création d'un établissement
            $scope.submitEts = function(etablissement) {
                UserFactory.addEtablissement.saveEts(etablissement,
                    function(){
                        $scope.ets = {};
                        $scope.showMsgInfo = true;
                        $scope.submited = false;
                    },
                    function(){
                        $scope.showMsgInfo = false;
                        $scope.submited = true;
                    });
            };


//Configuere la date maximale du date picker
            $scope.dateMax = new Date();
            $scope.open = function($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.opened = true;
            };
        }
        else {
            $location.path('/redirectionlogin2');
        }

//Remove Alert
        $scope.hideAlert = function(){
             $scope.showMsgInfo=false;
             $scope.submited=false;
        }

    }]);