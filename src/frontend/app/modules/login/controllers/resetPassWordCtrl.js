'use strict';

app.controller('resetPassWordCtrl', ['$scope', 'UserFactory', function($scope,UserFactory) {

	 //Masquer le message d'érreur
        $scope.submited = true;

    $scope.resetPw=function(userEmail){
    	

            UserFactory.resetPassWord.reset({email:userEmail}, {},
                    function() {
                        return $scope.submited = true;
                    },
                    function() {

                        return $scope.submited = false;
                    });
    }

    }]);