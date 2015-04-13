'use strict';

app.controller('compteActivationCtrl', ['$scope', 'UserFactory', '$route','$location', '$cookieStore',
	 function($scope, UserFactory, $route, $location, $cookieStore) {
	
	$scope.submited = true;
	$scope.activated = true;
    $scope.email = $route.current.params.email;

	$scope.submitLogin = function(email){

		//Enregistrement de l'email dans le coocky
            UserFactory.setConnectedUser(email);

            UserFactory.activateAcount.activate({email:$route.current.params.email,
                            codeActivation:$route.current.params.codeActivation},{},
                            function(){
                        $scope.submited = true;
                        $scope.activated = true;

                        UserFactory.connectUser.login(null, {email: $scope.email, motDepasse: $scope.motDepasse },
                    function() {
                        $scope.submited = true;                         
                        $location.path('/setprofil');                                 
                    },
                    function() {
                        $scope.submited = false;
                    });

                            },
                            function(){
                        $scope.submited = true;
                        $scope.activated = false;
                        $cookieStore.remove('user_email');
                        $cookieStore.remove('login_status');
                            });         

	}
}]);