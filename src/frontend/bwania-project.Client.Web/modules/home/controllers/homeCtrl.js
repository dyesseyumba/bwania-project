'use strict';

app.controller('homeCtrl', ['$scope', 'UserFactory', '$cookieStore', '$location',
    function($scope, UserFactory, $cookieStore, $location) {

        //Vérifiction du status d'authentification
        

        $scope.newsDetail = false;

        $scope.hideNewsDetail = function() {
            if ($scope.newsDetail) {
                $scope.newsDetail = false;
            }
            else {
                $scope.newsDetail = true;
            }
        };

        /*
         *Affichages des 10 dernières publications et des 10 documents les plus consultés
         */
        $scope.documents = UserFactory.docResourceGet.query({pageIndex:0});
        $scope.listDocCons = UserFactory.getDocMoreConsulted.query();
        $scope.docUrl = UserFactory.docUrl;

        /*
         * Recherche d'un document
         */
         $scope.docSearch = function(titre){
            $location.path(/formation/+titre.toString());
         }

    }]);