'use strict';

app.controller('etablissementsCtrl', ['$scope', 'UserFactory', '$location', '$cookieStore',
    function($scope, UserFactory, $location, $cookieStore) {
        //Masquer les méssages d'érreures
    $scope.activationFaild = false;
        //Vérifie si l'utilisateur est connecté ou pas
        

        var getUser = UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
        //Vérifie si l'utilisateur à acyiver son éspace établissement scolaire ou non.
        function() {
            if (getUser.etablissementScolaire.id > 5) {
                $location.path('/etablissement/' + getUser.etablissementScolaire.id);
            }
            ;
        });

        //Chargement de tous les établissements.
        $scope.etablissements = UserFactory.getAllEtablissement.query();

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
                            $location.path('/etablissement/'+ etablissementId);
                            $scope.spaceActivated = true;                  
                        },
                        function() {
                            $scope.spaceActivated = false;
                        });
            });

        }
    }]);