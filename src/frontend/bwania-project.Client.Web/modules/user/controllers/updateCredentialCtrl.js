'use strict';
app.controller('updateCredentialCtrl', ['$scope', 'UserFactory', '$cookieStore', function($scope, UserFactory, $cookieStore) {
//Masquer le message d'érreur
        $scope.errorMesage = true;
        $scope.errorMessage2 = false;
        $scope.hideEmail = false;
        $scope.hideMotDePasse = false;
        $scope.updateSucces = false;
        var locals = {};
        var getUser = UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
        function() {
            $scope.email = getUser.email;
            $scope.password2 = getUser.motDepasse;
            $scope.motDepasse = getUser.motDepasse;
            $scope.password3 = getUser.motDepasse;
            locals = $scope.user = {id: getUser.id,
                nom: getUser.nom,
                prenom: getUser.prenom,
                email: $scope.email,
                dateDeNaissance: getUser.dateDeNaissance,
                motDepasse: getUser.motDepasse,
                sexe: getUser.sexe,
                pays: getUser.pays,
                ville: getUser.ville,
                telephone: getUser.telephone,
                etablissement: getUser.etablissement,
                langueParle: getUser.langueParle,
                aproposDeVous: getUser.aproposDeVous,
                filiere: getUser.filiere,
                societe: getUser.societe,
                poste: getUser.poste,
                domaine: getUser.domaine,
                ancienete: getUser.ancienete,
                lyceeFrequente: getUser.lyceeFrequente,
                codeActivation : getUser.codeActivation,
                statutActivation : getUser.statutActivation,
                matiere: $scope.matiere,
                siteweb: $scope.siteweb,
                statut: $scope.statut}

        });
        //Utilisation de l'évènement ng-click = "updateEmail"
        $scope.updateEmail = function() {

//Si l'utilisateur ne change pas d'email
            if (locals.email === $cookieStore.get('user_email')) {
                editEmail();
            }
//S'il change d'email
            else {
                UserFactory.getConnectedUser.get({email: locals.email},
                function() {
                    $scope.errorMessage2 = true;
                    $scope.errorPassword2 = false;
                    $scope.errorPassword = false;
                    $scope.errorPassword3 = false;
                },
                        function() {
                            $cookieStore.put('user_email', locals.email);                        
                            editEmail();
                        }
                );
            }
        };
        //Mis à jour de l'email
        function editEmail() {
            UserFactory.updateUser.edit(null, locals,
                    function() {
                        $scope.email = $cookieStore.get('user_email');                      
                        $scope.updateSucces = true;
                        $scope.errorMesage = true;
                        $scope.errorMessage2 = false;
                        $scope.hideEmail = false;
                        $scope.hideMotDePasse = false;
                    },
                    function() {
                        $scope.errorMesage = false;
                    });
        }




        //Utilisation de l'évènement ng-click = "updatePassWord"
        $scope.updatePassWord = function() {
             if ($scope.user.motDepasse.length < 8) {
                $scope.hideMotDePasse = true;
                $scope.errorPassword2 = true;
                $scope.errorPassword = false;
                $scope.errorPassword3 = false;
                $scope.errorMessage2 = false;
            }
            else if ($scope.user.motDepasse !== $scope.password3) {
                 $scope.hideMotDePasse = true;
                $scope.errorPassword2 = false;
                $scope.errorPassword = true;
                $scope.errorPassword3 = false;
                $scope.errorMessage2 = false;
            }
            else{
            UserFactory.editPassword.edit(null,{id: locals.id, oldPassword: $scope.password2, newPassword: $scope.user.motDepasse},
                    function() {
                        $scope.updateSucces = true;
                        $scope.errorMesage = true;
                        $scope.errorMessage2 = false;
                        $scope.errorPassword2 = false;
                        $scope.errorPassword = false;
                        $scope.errorPassword3 = false;
                        
                    },
                    function() {
                        $scope.errorPassword2 = false;
                        $scope.errorPassword = false;
                        $scope.errorPassword3 = true;
                        $scope.errorMessage2 = false;
                        $scope.errorMesage = false;
                    }
            );
        }
        };


        //Disparition du message d'alerte avec ng-click="dismissAlert()"
        $scope.dismissAlert = function() {
            $scope.updateSucces = false;
        }


        //Evènement ng-click="emailModifier"
        $scope.emailModifier = function() {
            $scope.hideEmail = true;
        };
        //Evènement ng-click="emailAnuler"
        $scope.emailAnuler = function() {
            $scope.hideEmail = false;
        };
        $scope.hideMotDePasse = false;
        //Evènement ng-click="motDePasseModifier"
        $scope.motDePasseModifier = function() {
            $scope.hideMotDePasse = true;
            $scope.password2 = "";
            $scope.user.motDepasse = "";
            $scope.password3 = "";
        };
        //Evènement ng-click="motDePasseAnuler"
        $scope.motDePasseAnuler = function() {
            $scope.hideMotDePasse = false;
            $scope.password2 = getUser.motDepasse;
            $scope.user.motDepasse = getUser.motDepasse;
            $scope.password3 = getUser.motDepasse;
        };
    }]);