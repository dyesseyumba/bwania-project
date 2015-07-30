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
            filterParameter.domaines.push(domaine);
            findAndRemoveInArray(filterParameter.domaines, "");
            $scope.documents = userFactory.filterByDomaine.filter({ nbPage: 0 }, filterParameter);

            // Appel de la méthode de compatage des des documents
            pagination(filterParameter);
        }

        function applyFilterNiveau(niveau) {
            filterParameter.niveaux.push(niveau);
            findAndRemoveInArray(filterParameter.niveaux, "");
            $scope.documents = userFactory.filterByDomaine.filter({ nbPage: 0 }, filterParameter);

            // Appel de la méthode de compatage des des documents
            pagination(filterParameter);
        }

        //CHeckbox Informatique
        $scope.docInfoClick = function(infoTech) {
            if (infoTech === "") {
                findAndRemoveInArray(filterParameter.domaines, "Informatique & Technologies");
            }

            applyFilterDomaine(infoTech);
        };

        //CHeckbox mathématiques
        $scope.docMathClick = function(mathematiques) {
            if (mathematiques === "") {
                findAndRemoveInArray(filterParameter.domaines, "Mathématiques");
            }

            applyFilterDomaine(mathematiques);
        };

        //CHeckbox Médecine
        $scope.docMedecineClick = function(medecine) {
            if (medecine === "") {
                findAndRemoveInArray(filterParameter.domaines, "Médecine");
            }

            applyFilterDomaine(medecine);
        };

        //CHeckbox Physique & Chimie
        $scope.docPhysiqueClick = function(physiqueChimie) {
            if (physiqueChimie === "") {
                findAndRemoveInArray(filterParameter.domaines, "Physique & Chimie");
            }

            applyFilterDomaine(physiqueChimie);
        };

        //CHeckbox Banque & Finances
        $scope.docBanqueClick = function(banqueFinance) {
            if (banqueFinance === "") {
                findAndRemoveInArray(filterParameter.domaines, "Banque & Finances");
            }

            applyFilterDomaine(banqueFinance);
        };

        //CHeckbox Economie & Gestion
        $scope.docEconomieClick = function(economieGestion) {
            if (economieGestion === "") {
                findAndRemoveInArray(filterParameter.domaines, "Economie & Gestion");
            }

            applyFilterDomaine(economieGestion);
        };

        //CHeckbox Langues
        $scope.docLangueClick = function(langues) {
            if (langues === "") {
                findAndRemoveInArray(filterParameter.domaines, "Langues");
            }

            applyFilterDomaine(langues);
        };

        //CHeckbox Philosophie & Littérature
        $scope.docPhiloClick = function(philoLit) {
            if (philoLit === "") {
                findAndRemoveInArray(filterParameter.domaines, "Philosophie & Littérature");
            }

            applyFilterDomaine(philoLit);
        };

        //CHeckbox Histoire & Géographie
        $scope.docHistoireClick = function(histGeogr) {
            if (histGeogr === "") {
                findAndRemoveInArray(filterParameter.domaines, "Histoire & Géographie");
            }

            applyFilterDomaine(histGeogr);
        };

        //CHeckbox Trucs & Astuces
        $scope.docTrucClick = function(trucsEtAstuces) {
            if (trucsEtAstuces === "") {
                findAndRemoveInArray(filterParameter.domaines, "Trucs & Astuces");
            }

            applyFilterDomaine(trucsEtAstuces);
        };

        //CHeckbox  Autre
        $scope.docAutreClick = function(autre) {
            var findAndRemoveInArray = function(domaines, autre1) { throw new Error("Not implemented"); };
            if (autre === "") {
                findAndRemoveInArray(filterParameter.domaines, "Autre");
            }

            applyFilterDomaine(autre);
        };

        //CHeckbox  Collège
        $scope.docCollegeClick = function(college) {
            if (college === "") {
                findAndRemoveInArray(filterParameter.niveaux, "Collège");
            }

            applyFilterNiveau(college);
        };

        //CHeckbox  Etudiant
        $scope.docLyceeClick = function(lycee) {
            if (lycee === "") {
                findAndRemoveInArray(filterParameter.niveaux, "Lycée");
            }

            applyFilterNiveau(lycee);
        };

        //CHeckbox  Entreprise
        $scope.docUnivClick = function(univ) {
            if (univ === "") {
                findAndRemoveInArray(filterParameter.niveaux, "Université");
            }

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