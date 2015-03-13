'use strict';

app.controller('userHomeCtrl', ['$scope', 'UserFactory', '$cookieStore', function($scope, UserFactory, $cookieStore) {

        /*
         * 
         * Initialisation des valeurs à afficher
         */
        $scope.eleve = false;
        $scope.etudiant = false;
        $scope.enseignant = false;
        $scope.professionnel = false;
        
        $scope.hideNom = false;
        $scope.hidePrenom = false;
        $scope.sexeModifier = false;
        $scope.hideDateDeNaissance = false;
        $scope.hideLangue = false;
        $scope.hideTel = false;
        $scope.hideVille = false;
        $scope.hidePays = false;
        $scope.hideStatut = false;
        $scope.hideEtablissement = false;
        $scope.hideClasse = false;
        $scope.hideLyceeFrequente = false;
        $scope.hideRole = false;
        $scope.hideEntreprise = false;
        $scope.hideAnciennete = false;
        $scope.hideDomaine = false;
        $scope.hideSiteWeb = false;
        $scope.hideMatiere = false;
        $scope.hideAproposDeVous = false;
        
        $scope.errorMesage = false;
        $scope.updateSucces = false;


        /*
         * 
         * Chargement des informations de l'utilisateur
         */
        var locals = {};
        var getUser = UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
        function() {
            $scope.nom = getUser.nom;
            $scope.prenom = getUser.prenom;
            $scope.dateDeNaissance = getUser.dateDeNaissance;
            $scope.langueParle = getUser.langueParle;
            $scope.telephone = getUser.telephone;
            $scope.ville = getUser.ville;
            $scope.pays = getUser.pays;
            $scope.etablissement = getUser.etablissement;
            $scope.aproposDeVous = getUser.aproposDeVous;
            $scope.statut = getUser.statut;
            $scope.filiere = getUser.filiere;
            $scope.lyceeFrequente = getUser.lyceeFrequente;
            $scope.domaine = getUser.domaine;
            $scope.matiere = getUser.matiere;
            $scope.roles = getUser.roles;
            $scope.societe = getUser.societe;
            $scope.ancienete = getUser.ancienete;
            $scope.siteweb = getUser.siteweb;
            $scope.sexe = getUser.sexe;
            
            locals = $scope.user = {id: getUser.id,
                nom: $scope.nom,
                prenom:$scope.prenom,
                email: getUser.email,
                dateDeNaissance: $scope.dateDeNaissance,
                motDepasse:getUser.motDepasse,
                sexe: $scope.sexe,
                pays: $scope.pays,
                ville: $scope.ville,
                telephone: $scope.telephone,
                etablissement: $scope.etablissement,
                langueParle: $scope.langueParle,
                aproposDeVous: $scope.aproposDeVous,
                filiere: $scope.filiere,
                societe: $scope.societe,
                poste: $scope.poste,
                domaine: $scope.domaine,
                ancienete: $scope.ancienete,
                lyceeFrequente: $scope.lyceeFrequente,
                matiere: $scope.matiere,
                siteweb:$scope.siteweb,
                statut: $scope.statut};


            /*
             *Afficahage des champs importants
             */
            if (getUser.statut === 'élève') {
                $scope.eleve = true;
            }
            else if (getUser.statut === 'étudiant') {
                $scope.etudiant = true;
            }
            else if (getUser.statut === 'enseignant') {
                $scope.enseignant = true;
            }
            else if (getUser.statut === 'professionnel') {
                $scope.professionnel = true;
            }
           
        });
        
        
       /*
         * 
         * Utilisation de l'évènement ng-click=setUser()
         */
        $scope.setUser = function() {
          
            
            UserFactory.updateUser.edit(null,locals,
            function() {                       
                        $scope.updateSucces = true;
                        return $scope.errorMesage = false;
                    },
                    function() {
                        return $scope.errorMesage = true;
                    });
                
        };
        //Disparition du message d'alerte avec ng-click="dismissAlert()"
        $scope.dismissAlert=function(){
             $scope.updateSucces = false;
        }



        
        /*
         * 
         * Affichage et masquage des champs de modifications
         */
            //Evènement ng-click="nomModifier"
            $scope.nomModifier = function() {
                $scope.hideNom=true;
            };            
            //Evènement ng-click="nomAnuler"
            $scope.nomAnuler = function() {
                $scope.hideNom=false;
            };
            //Evènement ng-click="prenomModifier"
            $scope.prenomModifier = function() {
                $scope.hidePrenom=true;
            };            
            //Evènement ng-click="prenomAnnuler"
            $scope.prenomAnnuler = function() {
                $scope.hidePrenom=false;
            };
            //Evènement ng-click="sexeModifier"
            $scope.sexeModifier = function() {
                $scope.hideSexe=true;
            };            
            //Evènement ng-click="sexeAnnuler"
            $scope.sexeAnnuler = function() {
                $scope.hideSexe=false;
            };
            //Evènement ng-click="dateDeNaissanceModifier"
            $scope.dateDeNaissanceModifier = function() {
                $scope.hideDateDeNaissance=true;
            };            
            //Evènement ng-click="dateDeNaissanceAnnuler"
            $scope.dateDeNaissanceAnnuler = function() {
                $scope.hideDateDeNaissance=false;
            };
            //Evènement ng-click="langueModifier"
            $scope.langueModifier = function() {
                $scope.hideLangue=true;
            };            
            //Evènement ng-click="langueAnnuler"
            $scope.langueAnnuler = function() {
                $scope.hideLangue=false;
            };
            //Evènement ng-click="TelModifier"
            $scope.TelModifier = function() {
                $scope.hideTel=true;
            };            
            //Evènement ng-click="TelAnnuler"
            $scope.TelAnnuler = function() {
                $scope.hideTel=false;
            };
            //Evènement ng-click="villeModifier"
            $scope.villeModifier = function() {
                $scope.hideVille=true;
            };            
            //Evènement ng-click="villeAnnuler"
            $scope.villeAnnuler = function() {
                $scope.hideVille=false;
            };
            //Evènement ng-click="paysModifier"
            $scope.paysModifier = function() {
                $scope.hidePays=true;
            };            
            //Evènement ng-click="paysAnnuler"
            $scope.paysAnnuler = function() {
                $scope.hidePays=false;
            };
            //Evènement ng-click="statutModifier"
            $scope.statutModifier = function() {
                $scope.hideStatut=true;
            };            
            //Evènement ng-click="statutAnnuler"
            $scope.statutAnnuler = function() {
                $scope.hideStatut=false;
            };
            //Evènement ng-click="etablissementModifier"
            $scope.etablissementModifier = function() {
                $scope.hideEtablissement=true;
            };            
            //Evènement ng-click="etablissementAnnuler"
            $scope.etablissementAnnuler = function() {
                $scope.hideEtablissement=false;
            };
            //Evènement ng-click="classeModifier"
            $scope.classeModifier = function() {
                $scope.hideClasse=true;
            };            
            //Evènement ng-click="classeAnnuler"
            $scope.classeAnnuler = function() {
                $scope.hideClasse=false;
            };
            //Evènement ng-click="lyceeFrequenteModifier"
            $scope.lyceeFrequenteModifier = function() {
                $scope.hideLyceeFrequente=true;
            };            
            //Evènement ng-click="lyceeFrequenteAnnuler"
            $scope.lyceeFrequenteAnnuler = function() {
                $scope.hideLyceeFrequente=false;
            };
            //Evènement ng-click="roleModifier"
            $scope.roleModifier = function() {
                $scope.hideRole=true;
            };            
            //Evènement ng-click="roleAnnuler"
            $scope.roleAnnuler = function() {
                $scope.hideRole=false;
            };
            //Evènement ng-click="entrepriseModifier"
            $scope.entrepriseModifier = function() {
                $scope.hideEntreprise=true;
            };            
            //Evènement ng-click="entrepriseAnnuler"
            $scope.entrepriseAnnuler = function() {
                $scope.hideEntreprise=false;
            };
            //Evènement ng-click="ancienneteModifier"
            $scope.ancienneteModifier = function() {
                $scope.hideAnciennete=true;
            };            
            //Evènement ng-click="ancienneteAnnuler"
            $scope.ancienneteAnnuler = function() {
                $scope.hideAnciennete=false;
            };
            //Evènement ng-click="siteWebModifier"
            $scope.siteWebModifier = function() {
                $scope.hideSiteWeb=true;
            };            
            //Evènement ng-click="siteWebAnnuler"
            $scope.siteWebAnnuler = function() {
                $scope.hideSiteWeb=false;
            };
            //Evènement ng-click="domaineModifier"
            $scope.domaineModifier = function() {
                $scope.hideDomaine=true;
            };            
            //Evènement ng-click="domaineAnnuler"
            $scope.domaineAnnuler = function() {
                $scope.hideDomaine=false;
            };
            //Evènement ng-click="matiereModifier"
            $scope.matiereModifier = function() {
                $scope.hideMatiere=true;
            };            
            //Evènement ng-click="matiereAnnuler"
            $scope.matiereAnnuler = function() {
                $scope.hideMatiere=false;
            };
            //Evènement ng-click="aproposDeVousModifier"
            $scope.aproposDeVousModifier = function() {
                $scope.hideAproposDeVous=true;
            };            
            //Evènement ng-click="aproposDeVousAnnuler"
            $scope.aproposDeVousAnnuler = function() {
                $scope.hideAproposDeVous=false;
            };


     //Configuere la date maximale du date picker
        $scope.dateMax = new Date();
        $scope.open = function($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
  };
    }]);