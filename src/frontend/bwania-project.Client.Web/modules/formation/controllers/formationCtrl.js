"use strict";

app.controller("formationCtrl", [
    "$scope", "$cookieStore", "UserFactory", "$route", "$location", function($scope, $cookieStore, userFactory, $route, $location) {

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
        };

        var currentPg = parseInt($route.current.params.nbPage);
        

        /*
        *Initial load
        */
        $scope.documents = userFactory.docResourceGet.query({ pageIndex: currentPg - 1});


        /*
         *Activation des checks box pour filtrer
         **/
        //function pagination(filter) {
        //    var totalDoc = userFactory.nbTotalFilteredDocument.get(filter,
        //        function() {
        //            $scope.totalItems = totalDoc.pageIndex;
        //            $scope.currentPage = 1;
        //            $scope.maxSize = 10;
        //        });
            //$scope.selectedPage = function(index) {
            //    filter.pageIndex = index - 1;
            //    $scope.documents = userFactory.filterByDomaine.query(filter);
            //};
        //}

/***********/        //Initialization de la pagination
        function pagination(filterParameter) {
            var totalFilteredDoc = userFactory.nbFilteredTotalDocument.filter({ nbPage: 0 }, filterParameter,
            function () {
                $scope.totalItems = totalFilteredDoc.totalDoc;
                $scope.currentPage = parseInt(currentPg);
                $scope.maxSize = 10;
            });
            $scope.selectedPage = function (index) {
                var pg = index-1;
                $scope.documents = userFactory.filterByDomaine.filter({ nbPage: pg }, filterParameter);
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

        //CHeckbox informatique & technologies
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
               $scope.currentPage = parseInt(currentPg);
               $scope.maxSize = 10;
           });
        $scope.selectedPage = function(index) {
           localFilter.pageIndex = index - 1;
           var pg = index ;
           $scope.documents = $location.path("/formation/" + pg);
        };

        /*
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