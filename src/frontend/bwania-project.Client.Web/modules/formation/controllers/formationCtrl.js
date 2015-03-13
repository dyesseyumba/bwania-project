'use strict';

app.controller('formationCtrl', ['$scope', '$cookieStore', 'UserFactory', '$route', function($scope, $cookieStore, UserFactory, $route) {

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
        $scope.college = "''";
        $scope.lycee = "''";
        $scope.univ = "''";

        var localFilter = {
            pageIndex: 0,
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
            autre: "Autre",
            college : "Collège",
            lycee : "Lycée",
            univ : "Université"
        };


        /*
         *Cas d'une redirection de la page home - Trillage des documents par domaines - Recherche d'un document.
         */
        //Trie par Informatique & Technologies
         if ($route.current.params.titre) {
            $scope.documents = UserFactory.getDocSearchResults.query({pageIndex: 0, titre: $route.current.params.titre})
        }
        else if ($route.current.params.infoTech === "Informatique & Technologies") {
            applyFilter('Informatique & Technologies', "''", "''", "''", "''", "''","''", "''", "''", "''", "''", "''", "''", "''");
        }
        else if ($route.current.params.mathematiques === "Mathématiques") {
            //localFilter{};
            applyFilter("''", "Mathématiques", "''", "''", "''", "''","''", "''", "''", "''", "''", "''", "''", "''");
        }
        else if ($route.current.params.medecine === "Médecine") {
            applyFilter("''", "''", "Médecine", "''", "''", "''","''", "''", "''", "''", "''", "''", "''", "''");
        }
        else if ($route.current.params.physiqueChimie === "Physique & Chimie") {
            applyFilter("''", "''", "''", "Physique & Chimie", "''", "''","''", "''", "''", "''", "''", "''", "''", "''");
        }
        else if ($route.current.params.banqueFinance === "Banque & Finances") {
            applyFilter("''", "''", "''", "''", "Banque & Finances", "''","''", "''", "''", "''", "''", "''", "''", "''");
        }
        else if ($route.current.params.economieGestion === "Economie & Gestion") {
            applyFilter("''", "''", "''", "''", "''", "Economie & Gestion","''", "''", "''", "''", "''", "''", "''", "''");
        }
        else if ($route.current.params.langues === "Langues") {
            applyFilter("''", "''", "''", "''", "''", "''","Langues", "''", "''", "''", "''", "''", "''", "''");
        }
        else if ($route.current.params.philoLit === "Philosophie & Littérature") {
            applyFilter("''", "''", "''", "''", "''", "''","''", "Philosophie & Littérature", "''", "''", "''", "''", "''", "''");
        }
        else if ($route.current.params.histGeogr === "Histoire & Géographie") {
            applyFilter("''", "''", "''", "''", "''", "''","''", "''", "Histoire & Géographie", "''", "''", "''", "''", "''");
        }
        else if ($route.current.params.trucsEtAstuces === "Trucs & Astuces") {
            applyFilter("''", "''", "''", "''", "''", "''","''", "''", "''", "Trucs & Astuces", "''", "''", "''", "''");
        }
        else if ($route.current.params.autre === "Autre") {
            applyFilter("''", "''", "''", "''", "''", "''","''", "''", "''", "''", "Autre", "''", "''", "''");
        }
        else if ($route.current.params.college === "Collège") {
            applyFilter("''", "''", "''", "''", "''", "''","''", "''", "''", "''", "''", "Collège", "''", "''");
        }
        else if ($route.current.params.lycee === "Lycée") {
            applyFilter("''", "''", "''", "''", "''", "''","''", "''", "''", "''", "''", "''", "Lycée", "''");
        }
        else if ($route.current.params.univ === "Université") {
            applyFilter("''", "''", "''", "''", "''", "''","''", "''", "''", "''", "''", "''", "''", "Université");
        }
        else {
            //Consommation de la ressource de chargement des documents
            $scope.documents = UserFactory.filterByDomaine.query(localFilter);
        }

        

        /*
         *Activation des checks box pour filtrer
         **/
        //CHeckbox informatique & technologies
        $scope.docInfoClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox mathématiques
        $scope.docMathClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox Médecine
        $scope.docMedecineClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox Physique & Chimie
        $scope.docPhysiqueClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox Banque & Finances
        $scope.docBanqueClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox Economie & Gestion
        $scope.docEconomieClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox Langues
        $scope.docLangueClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox Philosophie & Littérature
        $scope.docPhiloClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox Histoire & Géographie
        $scope.docHistoireClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox Trucs & Astuces
        $scope.docTrucClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox  Autre
        $scope.docAutreClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox  Collège
        $scope.docCollegeClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox  Etudiant
        $scope.docLyceeClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };

        //CHeckbox  Entreprise
        $scope.docUnivClick = function(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance, economieGestion,
                    langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ);
        };


        /*
         * 
         *Filtrage des documents*/
        function applyFilter(infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre ,college, lycee, univ) {

            if (infoTech === "''" && mathematiques === "''" && medecine === "''" && physiqueChimie === "''"
                    && banqueFinance === "''" && economieGestion === "''" && langues === "''" && philoLit === "''"
                    && histGeogr === "''" && trucsEtAstuces === "''" && autre === "''" && college === "''"
                    && lycee === "''" && univ === "''") {

                $scope.documents = UserFactory.filterByDomaine.query(localFilter);

                // Appel de la méthode de compatage des des documents
                pagination(localFilter);

            } else
            {
                var watchedLocalFilter = {pageIndex: 0,
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
                    autre: autre,
                    college : college,
                    lycee : lycee,
                    univ : univ};
                $scope.documents = UserFactory.filterByDomaine.query(watchedLocalFilter);

                // Appel de la méthode de compatage des des documents
                pagination(watchedLocalFilter);
            }
        }

        /*
         *Pagination
         */
        //Initialization de la pagination
        var totalDoc = UserFactory.nbTotalFilteredDocument.get(localFilter,
                function() {
                    $scope.totalItems = totalDoc.pageIndex;
                    $scope.currentPage = 1;
                    $scope.maxSize = 10;
                });
        $scope.selectedPage = function(index) {
            localFilter.pageIndex = index - 1;
            $scope.documents = UserFactory.filterByDomaine.query(localFilter);
        };
        function pagination(filter) {
            var totalDoc = UserFactory.nbTotalFilteredDocument.get(filter,
                    function() {
                        $scope.totalItems = totalDoc.pageIndex;
                        $scope.currentPage = 1;
                        $scope.maxSize = 10;
                    });
            $scope.selectedPage = function(index) {
                filter.pageIndex = index - 1;
                $scope.documents = UserFactory.filterByDomaine.query(filter);
            };
        }


        /*
         * Recherches
         */
        $scope.clickedBtnSearch = function(titre, infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
                economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

            if (infoTech === "''" && mathematiques === "''" && medecine === "''" && physiqueChimie === "''"
                    && banqueFinance === "''" && economieGestion === "''" && langues === "''" && philoLit === "''"
                    && histGeogr === "''" && trucsEtAstuces === "''" && autre === "''") {

                $scope.documents = UserFactory.getDocSearchResults.query({pageIndex: 0, titre: titre});

                // Appel de la méthode de compatage des des documents
                var totalDoc = UserFactory.nbTotalDocSearchResults.get({titre: titre},
                function() {
                    $scope.totalItems = totalDoc.pageIndex;
                    $scope.currentPage = 1;
                    $scope.maxSize = 10;
                });
                $scope.selectedPage = function(index) {
                    $scope.documents = UserFactory.getDocSearchResults.query({pageIndex: index - 1, titre: titre});
                };

            } else
            {
                localFilter.titre = titre;
                var watchedLocalFilter = {pageIndex: 0,
                    titre: titre,
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
                $scope.documents = UserFactory.getFilteredResultsByDomaine.query(watchedLocalFilter);

                // Appel de la méthode de compatage des des documents
                watchedLocalFilter.titre = titre;
                var totalDoc = UserFactory.nbTotalFilteredResultsByDomaine.get(watchedLocalFilter,
                        function() {
                            $scope.totalItems = totalDoc.pageIndex;
                            $scope.currentPage = 1;
                            $scope.maxSize = 10;
                        });
                $scope.selectedPage = function(index) {
                    watchedLocalFilter.pageIndex = index - 1;
                    $scope.documents = UserFactory.getFilteredResultsByDomaine.query(watchedLocalFilter);
                };

            }
        }




    }]);