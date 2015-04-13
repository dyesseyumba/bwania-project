'use strict';

app.directive('bwaniaHeader', ['$cookieStore', '$location', 'UserFactory', 'Facebook',
    function($cookieStore, $location, UserFactory, Facebook) {
        return{
            restrict: 'E',
            replace: true,
            templateUrl: 'shared/directives/headerTemplate.html',
            link: function(scope, element, attrs) {
                scope.logout = function() {
                    $cookieStore.remove('user_email');
                    $cookieStore.remove('login_status');
                    $cookieStore.remove('auth_token');
                    scope.loggedOut = false;                    
                };

                //Connection avec Facebook
                scope.fbLogin = function() {
                    Facebook.getLoginStatus(function(response) {
                        if (response.status === 'connected') {
                            //scope.logged = true;
                            scope.me();
                        }
                        else
                            scope.login();
                    });
                };

                //Authentification
                scope.login = function() {
                    Facebook.login(function(response) {
                        if (response.status === 'connected') {
                            //scope.logged = true;
                            scope.me();
                        }

                    });
                };

                //Recupération des informations et connexion à Bwania               
                scope.me = function() {
                    Facebook.api('/me', function(response) {
                                                
                            // Ajout de l'email dans le cookies
                            $cookieStore.put('user_email', response.email);

                            UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
                            //Cas où l'email se trouve déjà dans l'application
                            function() {
                                $cookieStore.put('login_status', true);
                                $location.path('/home');
                            },
                                    //Cas où l'utilisateur n'est pas encore inscrit
                                            function() {

                                                var valueSex;
                                                if (response.gender === "male") {
                                                    valueSex = "M";
                                                }
                                                else if (response.gender === "female") {
                                                    valueSex = "F"
                                                };
                                                
                                                UserFactory.createUserbyfb.create(null,
                                                        {
                                                            nom: response.last_name,
                                                            prenom: response.first_name,
                                                            email: response.email,
                                                            aproposDeVous: response.about,
                                                            sexe: valueSex,
                                                            siteweb: response.birthday,
                                                            motDepasse : response.id,
                                                            dateDeNaissance : new Date()
                                                        },
                                                function() {
                                                    $cookieStore.put('login_status', true);
                                                },
                                                        function() {
                                                            $cookieStore.put('login_status', false);
                                                            //TODO : Ajouter un messgage pour signifier que l'inscription a raté
                                                        });
                                            });
                                

                    });
                };

                scope.$watch(function() {
                    return $cookieStore.get('login_status');
                },
                        function() {
                            if ($cookieStore.get('login_status') === true) {
                                scope.loggedOut = true;

                                var getUser = UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')}, function() {
                                    scope.MonCompte = getUser.nom;
                                });
                            }
                            else {
                                scope.loggedOut = false;
                            }
                        }
                );

                //Suppression du cookie 'login_status'
                // $scope.$on("$locationChangeStart", function(event){
                //    event.preventDefault()
                //   $cookieStore.remove('login_status');
                //   });

                element.on('$destroy', function() {
                    scope.$digest();
                });

            }
        };

    }]);
