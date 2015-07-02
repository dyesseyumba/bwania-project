"use strict";

app.controller("formationCtrl", [
    "$scope", "$cookieStore", "UserFactory", "$route", function($scope, $cookieStore, userFactory, $route) {

        $scope.infoTech = "";
        $scope.mathematiques = "";
        $scope.medecine = "";
        $scope.physiqueChimie = "";
        $scope.banqueFinance = "";
        $scope.economieGestion = "";
        $scope.langues = "";
        $scope.philoLit = "";
        $scope.histGeogr = "";
        $scope.trucsEtAstuces = "";
        $scope.autre = "";
        $scope.college = "";
        $scope.lycee = "";
        $scope.univ = "";

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
            college: "Collège",
            lycee: "Lycée",
            univ: "Université"
        };

        var filterParameter = {
            domaines: [],
            niveaux: []
        }; /*
         *Cas d'une redirection de la page home - Trillage des documents par domaines - Recherche d'un document.
         */
        //Trie par Informatique & Technologies
        //if ($route.current.params.titre) {
        //    $scope.documents = userFactory.getDocSearchResults.query({ pageIndex: 0, titre: $route.current.params.titre });
        //} else if ($route.current.params.infoTech === "Informatique & Technologies") {
        //    applyFilter("Informatique & Technologies", "", "", "", "", "", "", "", "", "", "", "", "", "");
        //} else if ($route.current.params.mathematiques === "Mathématiques") {
        //    //localFilter{};
        //    applyFilter("", "Mathématiques", "", "", "", "", "", "", "", "", "", "", "", "");
        //} else if ($route.current.params.medecine === "Médecine") {
        //    applyFilter("", "", "Médecine", "", "", "", "", "", "", "", "", "", "", "");
        //} else if ($route.current.params.physiqueChimie === "Physique & Chimie") {
        //    applyFilter("", "", "", "Physique & Chimie", "", "", "", "", "", "", "", "", "", "");
        //} else if ($route.current.params.banqueFinance === "Banque & Finances") {
        //    applyFilter("", "", "", "", "Banque & Finances", "", "", "", "", "", "", "", "", "");
        //} else if ($route.current.params.economieGestion === "Economie & Gestion") {
        //    applyFilter("", "", "", "", "", "Economie & Gestion", "", "", "", "", "", "", "", "");
        //} else if ($route.current.params.langues === "Langues") {
        //    applyFilter("", "", "", "", "", "", "Langues", "", "", "", "", "", "", "");
        //} else if ($route.current.params.philoLit === "Philosophie & Littérature") {
        //    applyFilter("", "", "", "", "", "", "", "Philosophie & Littérature", "", "", "", "", "", "");
        //} else if ($route.current.params.histGeogr === "Histoire & Géographie") {
        //    applyFilter("", "", "", "", "", "", "", "", "Histoire & Géographie", "", "", "", "", "");
        //} else if ($route.current.params.trucsEtAstuces === "Trucs & Astuces") {
        //    applyFilter("", "", "", "", "", "", "", "", "", "Trucs & Astuces", "", "", "", "");
        //} else if ($route.current.params.autre === "Autre") {
        //    applyFilter("", "", "", "", "", "", "", "", "", "", "Autre", "", "", "");
        //} else if ($route.current.params.college === "Collège") {
        //    applyFilter("", "", "", "", "", "", "", "", "", "", "", "Collège", "", "");
        //} else if ($route.current.params.lycee === "Lycée") {
        //    applyFilter("", "", "", "", "", "", "", "", "", "", "", "", "Lycée", "");
        //} else if ($route.current.params.univ === "Université") {
        //    applyFilter("", "", "", "", "", "", "", "", "", "", "", "", "", "Université");
        //} else {
        //Consommation de la ressource de chargement des documents
        //$scope.documents = userFactory.filterByDomaine.query(localFilter);
        //}
        //Consommation de la ressource de chargement des documents
        $scope.documents = userFactory.docResourceGet.query({ pageIndex: 0 });


        /*
         *Activation des checks box pour filtrer
         **/
        //CHeckbox informatique & technologies
        function pagination(filter) {
            var totalDoc = userFactory.nbTotalFilteredDocument.get(filter,
                function() {
                    $scope.totalItems = totalDoc.pageIndex;
                    $scope.currentPage = 1;
                    $scope.maxSize = 10;
                });
            $scope.selectedPage = function(index) {
                filter.pageIndex = index - 1;
                $scope.documents = userFactory.filterByDomaine.query(filter);
            };
        }

        function findAndRemoveInArray(array, value) {
            $.each(array, function(index, result) {
                if (result === value) {
                    //Remove from array
                    array.splice(index, 1);
                }
            });
        }

        function applyFilterDomaine(domaine) {

            if (domaine === "") {

                findAndRemoveInArray(filterParameter.domaines, domaine);
                $scope.documents = userFactory.filterByDomaine.save({ nbPage: 0 }, filterParameter);

                // Appel de la méthode de compatage des des documents
                pagination(filterParameter);

            } else {

                filterParameter.domaines.push(domaine);
                $scope.documents = userFactory.filterByDomaine.save({ nbPage: 0 }, filterParameter);

                // Appel de la méthode de compatage des des documents
                pagination(filterParameter);
            }
        }

        function applyFilterNiveau(niveau) {

            if (domaine === "") {

                findAndRemoveInArray(filterParameter.niveaux, niveau);
                $scope.documents = userFactory.filterByDomaine.save({nbPage:0}, filterParameter);

                // Appel de la méthode de compatage des des documents
                pagination(filterParameter);

            } else {

                filterParameter.niveaux.push(niveau);
                $scope.documents = userFactory.filterByDomaine.save({nbPage:0}, filterParameter);

                // Appel de la méthode de compatage des des documents
                pagination(filterParameter);
            }
        }

        //CHeckbox Informatique
        $scope.docInfoClick = function(infoTech) {
            applyFilterDomaine(infoTech);
        };

        //CHeckbox mathématiques
        $scope.docMathClick = function(mathematiques) {
            applyFilterDomaine(mathematiques);
        };

        //CHeckbox Médecine
        $scope.docMedecineClick = function(medecine) {
            applyFilterDomaine(medecine);
        };

        //CHeckbox Physique & Chimie
        $scope.docPhysiqueClick = function(physiqueChimie) {
            applyFilterDomaine(physiqueChimie);
        };

        //CHeckbox Banque & Finances
        $scope.docBanqueClick = function(banqueFinance) {
            applyFilterDomaine(banqueFinance);
        };

        //CHeckbox Economie & Gestion
        $scope.docEconomieClick = function(economieGestion) {
            applyFilterDomaine(economieGestion);
        };

        //CHeckbox Langues
        $scope.docLangueClick = function(langues) {
            applyFilterDomaine(langues);
        };

        //CHeckbox Philosophie & Littérature
        $scope.docPhiloClick = function(philoLit) {
            applyFilterDomaine(philoLit);
        };

        //CHeckbox Histoire & Géographie
        $scope.docHistoireClick = function(histGeogr) {
            applyFilterDomaine(histGeogr);
        };

        //CHeckbox Trucs & Astuces
        $scope.docTrucClick = function(trucsEtAstuces) {
            applyFilterDomaine(trucsEtAstuces);
        };

        //CHeckbox  Autre
        $scope.docAutreClick = function(autre) {
            applyFilterDomaine(autre);
        };

        //CHeckbox  Collège
        $scope.docCollegeClick = function(college) {
            applyFilterNiveau(college);
        };

        //CHeckbox  Etudiant
        $scope.docLyceeClick = function(lycee) {
            applyFilterNiveau(lycee);
        };

        //CHeckbox  Entreprise
        $scope.docUnivClick = function(univ) {
            applyFilterNiveau(univ);
        };


        /*
         * 
         *Filtrage des documents*/ /*
         *Pagination
         */
        //Initialization de la pagination
        var totalDoc = userFactory.nbTotalDocument.get(null,
            function() {
                $scope.totalItems = totalDoc.totalDoc;
                $scope.currentPage = 1;
                $scope.maxSize = 10;
            });
        $scope.selectedPage = function(index) {
            localFilter.pageIndex = index - 1;
            $scope.documents = userFactory.filterByDomaine.query(localFilter);
        }; /*
         * Recherches
         */
        $scope.clickedBtnSearch = function(titre, infoTech, mathematiques, medecine, physiqueChimie, banqueFinance,
            economieGestion, langues, philoLit, histGeogr, trucsEtAstuces, autre) {

            if (infoTech === "" && mathematiques === "" && medecine === "" && physiqueChimie === ""
                && banqueFinance === "" && economieGestion === "" && langues === "" && philoLit === ""
                && histGeogr === "" && trucsEtAstuces === "" && autre === "") {

                $scope.documents = userFactory.getDocSearchResults.query({ pageIndex: 0, titre: titre });

                // Appel de la méthode de compatage des des documents
                var totalDoc = userFactory.nbTotalDocSearchResults.get({ titre: titre },
                    function() {
                        $scope.totalItems = totalDoc.pageIndex;
                        $scope.currentPage = 1;
                        $scope.maxSize = 10;
                    });
                $scope.selectedPage = function(index) {
                    $scope.documents = userFactory.getDocSearchResults.query({ pageIndex: index - 1, titre: titre });
                };

            } else {
                localFilter.titre = titre;
                var watchedLocalFilter = {
                    pageIndex: 0,
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
                    autre: autre
                };
                $scope.documents = userFactory.getFilteredResultsByDomaine.query(watchedLocalFilter);

                // Appel de la méthode de compatage des des documents
                watchedLocalFilter.titre = titre;
                var totalDoc = userFactory.nbTotalFilteredResultsByDomaine.get(watchedLocalFilter,
                    function() {
                        $scope.totalItems = totalDoc.pageIndex;
                        $scope.currentPage = 1;
                        $scope.maxSize = 10;
                    });
                $scope.selectedPage = function(index) {
                    watchedLocalFilter.pageIndex = index - 1;
                    $scope.documents = userFactory.getFilteredResultsByDomaine.query(watchedLocalFilter);
                };

            }
        };
    }
]);