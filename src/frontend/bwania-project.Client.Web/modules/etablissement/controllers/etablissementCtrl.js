'use strict';

app.controller('etablissementCtrl', ['$scope', 'UserFactory','$route', '$cookieStore',
 function($scope, UserFactory, $route, $cookieStore) {
 	//Masquer les méssages d'érreures
 	$scope.spaceActivated = false;
 	$scope.activationFaild = false;

        $scope.etablissement = UserFactory.getOneEtablissement.get({id : $route.current.params.etablissementID});

        /*
         **Active l'établissement scolaire
         **/
        $scope.activateSchool = function(etablissementId) {
            var getUser = UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
            function() {
                var localUser = {id: getUser.id,
                    nom: getUser.nom,
                    prenom: getUser.prenom,
                    email: getUser.email,
                    motDepasse: getUser.motDepasse,
                    dateDeNaissance: getUser.dateDeNaissance,
                    sexe: getUser.sexe,
                    codeActivation: getUser.codeActivation,
                    statutActivation: getUser.statutActivation,
                    pays: getUser.pays,
                    ville: getUser.ville,
                    telephone: getUser.telephone,
                    langueParle: getUser.langueParle,
                    aproposDeVous: getUser.aproposDeVous,
                    filiere: getUser.filiere,
                    lyceeFrequente: getUser.lyceeFrequente,
                    matiere: getUser.matiere,
                    societe: getUser.societe,
                    roles: getUser.roles,
                    domaine: getUser.domaine,
                    ancienete: getUser.ancienete,
                    siteweb: getUser.siteweb,
                    statut: getUser.statut,
                    etablissementScolaire: {id: etablissementId}
                };

                UserFactory.updateUser.edit(null, localUser,
                        function() {
                            $scope.spaceActivated = true;
                            $scope.activationFaild = false;                       
                        },
                        function() {
                            $scope.spaceActivated = true;
                            $scope.activationFaild = false;
                        });
            });

        }
    }]);