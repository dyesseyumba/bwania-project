'use strict';

app.controller('myDocumentsCtrl', ['$scope', 'UserFactory', '$cookieStore', function($scope, UserFactory, $cookieStore) {

        $scope.deleteFaild = false;

        $scope.infoTech = "''";
        $scope.mathematiques = "''";
        $scope.medecine = "''";
        $scope.physiqueChimie = "''";
        $scope.banqueFinance = "''";
        $scope.economieGestion = "''";
        $scope.langues = "''";
        $scope.philoLit = "''";
        $scope.histGeogr = "''";
        $scope.trucsEtAstuces = "''";
        $scope.autre = "''";


        var getUser = UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
        function() {
            $scope.documents = UserFactory.docResourceByUser.query({utilisateurId: getUser.id, pageIndex: 0});


            var localFilter = {
            pageIndex: 0,
            utilisateurId : getUser.id,
            infoTech: "Informatique & Technologies",
            mathematiques: "Mathématiques",
            medecine: "Médecine",
            physiqueChimie: "Physique & Chimie",
            banqueFinance: "Banque & Finances",
            economieGestion: "Economie & Gestion",
            langues: "Langues",
            philoLit: "Philosophie & Littérature",
            histGeogr: "Histoire & Géographie",
            trucsEtAstuces: "Trucs & Astuces",
            autre: "Autre"};

        /*
         *Activation des checks box pour filtrer
         **/
        //CHeckbox informatique & technologies
       $scope.docInfoClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
               economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

          applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
       };

       //CHeckbox mathématiques
       $scope.docMathClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
               economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

           applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
       };

        //CHeckbox Médecine
        $scope.docMedecineClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
        };

        //CHeckbox Physique & Chimie
        $scope.docPhysiqueClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
        };

        //CHeckbox Banque & Finances
        $scope.docBanqueClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
        };

        //CHeckbox Economie & Gestion
        $scope.docEconomieClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
        };

        //CHeckbox Langues
        $scope.docLangueClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

           applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
        };

        //CHeckbox Philosophie & Littérature
        $scope.docPhiloClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
        };

        //CHeckbox Histoire & Géographie
        $scope.docHistoireClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
        };

        //CHeckbox Trucs & Astuces
        $scope.docTrucClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

           applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
        };

        //CHeckbox  Autre
        $scope.docAutreClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,economieGestion,
            langues, philoLit, histGeogr, trucsEtAstuces, autre);
        };


        /*
         * 
         *Filtrage des documents*/
        function applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre){

            if (infoTech === "''" && mathematiques === "''" && medecine === "''" && physiqueChimie === "''"
                    && banqueFinance === "''" && economieGestion === "''" && langues === "''" && philoLit === "''"
                    && histGeogr === "''" && trucsEtAstuces === "''" && autre === "''") {

                $scope.documents = UserFactory.filterDocUserByDomaine.query(localFilter);

                // Appel de la méthode de compatage des des documents
                //pagination(localFilter);

            } else
            {
                var watchedLocalFilter = {pageIndex: 0,
                    utilisateurId : getUser.id,
                    infoTech: infoTech,
                    mathematiques: mathematiques,
                    medecine: medecine,
                    physiqueChimie: physiqueChimie,
                    banqueFinance: banqueFinance,
                    economieGestion: economieGestion,
                    langues: langues,
                    philoLit: philoLit,
                    histGeogr: histGeogr,
                    trucsEtAstuces: trucsEtAstuces,
                    autre: autre};
                $scope.documents = UserFactory.filterDocUserByDomaine.query(watchedLocalFilter);

                // Appel de la méthode de compatage des des documents
                pagination(watchedLocalFilter);
            }
        }


            /*
             *Pagination
             */
             //Initialisation de la pagination
            var totalDoc = UserFactory.nbTotalUserDoc.get({utilisateurId: getUser.id},
            function() {
                $scope.totalItems = totalDoc.pageIndex;
                $scope.currentPage = 1;
                $scope.maxSize = 10;
            });
            $scope.selectedPage = function(index) {
                $scope.documents = UserFactory.docResourceByUser.query({utilisateurId: getUser.id, pageIndex: index - 1});
            };
            function pagination(filter) {
               var totalDoc = UserFactory.nbTotalFilteredDocUserByDomaine.get(filter,
                    function() {
                        $scope.totalItems = totalDoc.pageIndex;
                        $scope.currentPage = 1;
                        $scope.maxSize = 10;
                    });
            $scope.selectedPage = function(index) {
                filter.pageIndex = index - 1;
                $scope.documents = UserFactory.filterDocUserByDomaine.query(filter);
            };
        }
        
        
        /*
         * Recherches
         */
         $scope.clickedBtnSearch = function(titre, infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre){

            if (infoTech === "''" && mathematiques === "''" && medecine === "''" && physiqueChimie === "''"
                    && banqueFinance === "''" && economieGestion === "''" && langues === "''" && philoLit === "''"
                    && histGeogr === "''" && trucsEtAstuces === "''" && autre === "''") {

                $scope.documents = UserFactory.getUserDocSearchResults.query({pageIndex : 0, titre : titre, utilisateurId : getUser.id});

                // Appel de la méthode de compatage des des documents
                var totalDoc = UserFactory.nbTotalUserDocSearchResults.get({titre : titre, utilisateurId : getUser.id},
                    function() {
                        $scope.totalItems = totalDoc.pageIndex;
                        $scope.currentPage = 1;
                        $scope.maxSize = 10;
                    });
            $scope.selectedPage = function(index) {
                $scope.documents = UserFactory.getUserDocSearchResults.query({
                    pageIndex : index - 1,
                    titre : titre,
                    utilisateurId : getUser.id});
            };

            } else
            {
                //localFilter.titre = titre;
                var watchedLocalFilter = {pageIndex: 0,
                    titre: titre,
                    utilisateurId : getUser.id,
                    infoTech: infoTech,
                    mathematiques: mathematiques,
                    medecine: medecine,
                    physiqueChimie: physiqueChimie,
                    banqueFinance: banqueFinance,
                    economieGestion: economieGestion,
                    langues: langues,
                    philoLit: philoLit,
                    histGeogr: histGeogr,
                    trucsEtAstuces: trucsEtAstuces,
                    autre: autre};
                $scope.documents = UserFactory.getUserFilteredResultsByDomaine.query(watchedLocalFilter);

                // Appel de la méthode de compatage des des documents
                watchedLocalFilter.titre = titre;
                var totalDoc = UserFactory.nbTotalUserFilteredResultsByDomaine.get(watchedLocalFilter,
                    function() {
                        $scope.totalItems = totalDoc.pageIndex;
                        $scope.currentPage = 1;
                        $scope.maxSize = 10;
                    });
            $scope.selectedPage = function(index) {
                watchedLocalFilter.pageIndex = index - 1;
                $scope.documents = UserFactory.getUserFilteredResultsByDomaine.query(watchedLocalFilter);
            };

            }
         };
        });

        $scope.docUrl = UserFactory.docUrl;
        $scope.otherDescripeion = false;
        $scope.documentClick = function() {
            if ($scope.otherDescripeion === false) {
                $scope.otherDescripeion = true;
            }
            else {
                $scope.otherDescripeion = false;
            }
            ;
        };

        //Suppression d'un document
        $scope.supprimerDoc = function(documentId, document) {

            //Suppresion dans le serveur
            UserFactory.deleteDocument.deleteDoc({documentId: documentId},
            function() {
                //Retrouver l'index des document
                var index = $scope.documents.indexOf(document);

                //Suppression dans le DOM
                $scope.documents.splice(index, 1);
            }, function() {
                $scope.deleteFaild = true;
            });
        };

    }]);
