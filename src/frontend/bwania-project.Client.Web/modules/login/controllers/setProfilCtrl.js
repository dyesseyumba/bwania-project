'use strict';

app.controller('setProfilCtrl', ['$scope', 'UserFactory', '$cookieStore', '$location',
    function($scope, UserFactory, $cookieStore, $location) {

        /*
         * Configuration du fichier Json qui sera mis à jour
         **/
        var locals = {};
        var getUser = UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
        function() {
            $scope.userName = getUser.nom;
            locals = $scope.user = {id: getUser.id,
                nom: getUser.nom,
                prenom: getUser.prenom,
                email: getUser.email,
                motDepasse: getUser.motDepasse,
                dateDeNaissance: getUser.dateDeNaissance,
                sexe: getUser.sexe,
                codeActivation : getUser.codeActivation,
                statutActivation : getUser.statutActivation,
                pays: $scope.pays,
                ville: $scope.ville,
                telephone: $scope.telephone,
                etablissementScolaire: $scope.etablissementScolaire,
                langueParle: $scope.langueParle,
                aproposDeVous: $scope.aproposDeVous,
                filiere: $scope.filiere,
                lyceeFrequente: $scope.lyceeFrequente,
                matiere: $scope.matiere,
                societe: $scope.societe,
                roles: $scope.roles,
                domaine: $scope.domaine,
                ancienete: $scope.ancienete,
                siteweb: $scope.siteweb,
                statut: ''};
        });
        
        
        //Chargement des établissement scolaire et des entreprises
        $scope.etablissements = UserFactory.getAllEtablissement.query();
        $scope.entreprises = UserFactory.getEnterprise.query();



        /*
         * Utilsation des évènement ng-submit : 'setEleve', 'setEtudiant', 'setEnseignant', 'setProfessionnel'
         */
        $scope.setEleve = function() {
            locals.statut = 'élève';
            UserFactory.updateUser.edit(null, locals,
                    function() {
                        $location.path('/home');
                        $scope.submited = true;                        
                    },
                    function() {
                        $scope.submited = false;
                    });
        };

        $scope.setEtudiant = function() {
            locals.statut = 'étudiant';
            UserFactory.updateUser.edit(null, locals,
                    function() {
                         $location.path('/home');
                        $scope.submited = true;                       
                    },
                    function() {
                        $scope.submited = false;
                    });
        };

        $scope.setEnseignant = function() {
            locals.statut = 'enseignant';
            UserFactory.updateUser.edit(null, locals,
                    function() {
                         $location.path('/home');
                        $scope.submited = true;                       
                    },
                    function() {
                        $scope.submited = false;
                    });
        };

        $scope.setProfessionnel = function() {
            locals.statut = 'professionnel';
            UserFactory.updateUser.edit(null, locals,
                    function() {
                        $location.path('/home');
                        $scope.submited = true;                        
                    },
                    function() {
                        $scope.submited = false;
                    });
        };



        /*
         * Affichage et masquage des formulaires
         */
        $scope.submited = true;
        $scope.eleveSelected = function() {
            $scope.eleveChecked = true;
            $scope.etudiantChecked = false;
            $scope.enseignantChecked = false;
            $scope.professionnelChecked = false;
        };
        $scope.etudiantSelected = function() {
            $scope.eleveChecked = false;
            $scope.etudiantChecked = true;
            $scope.enseignantChecked = false;
            $scope.professionnelChecked = false;
        };
        $scope.enseigntSelected = function() {
            $scope.eleveChecked = false;
            $scope.etudiantChecked = false;
            $scope.enseignantChecked = true;
            $scope.professionnelChecked = false;
        };
        $scope.professionnelSelected = function() {
            $scope.eleveChecked = false;
            $scope.etudiantChecked = false;
            $scope.enseignantChecked = false;
            $scope.professionnelChecked = true;
        };

    }]);