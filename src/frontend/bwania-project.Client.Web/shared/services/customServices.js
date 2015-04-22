var customServices = angular.module('customServices', ['ngResource']);

var urlMain = 'http://localhost:27573/api/';

customServices.factory('UserFactory', ['$resource', '$location', '$cookieStore', '$upload', function ($resource, $location, $cookieStore, $upload) {

        var connectedUser = {};
        var cookieEmail;

        /***********************consomming Jax-RS UtilisateurRessource**********************************/
        // Consomations de la méthode POST de la ressource UtilisateuResource du Backend
        var createUser = $resource(urlMain + 'users', {}, {
            create: {method: 'POST',
                interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                        $location.path('/first_Login');
                    },
                    responseError: function (data) {
                        $cookieStore.put('login_status', false);
                        console.log('error in interceptor', data);
                    }
                }}
        });
        //Create user by facebook
        var createUserbyfb = $resource(urlMain + 'users/create_by_Fb', {}, {
            create: {method: 'POST',
                interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                        $location.path('/setprofil');
                    },
                    responseError: function (data) {
                        $cookieStore.put('login_status', false);
                        console.log('error in interceptor', data);
                    }
                }}
        });
        // Récupération des informations de l'utilisateur courant
        var getUser = $resource(urlMain + 'users/:email');

        // Mise-à-jour de l'utilisateur
        var editUser = $resource(urlMain + 'users/bwaniaAuthReq/update', {}, {
            edit: {method: 'PUT',
                headers: {"service_key": $cookieStore.get('user_email'),
                    "auth_token": $cookieStore.get('auth_token')},
                interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                    },
                    responseError: function (data) {
                        console.log('error in interceptor', data);
                    }
                }
            }
        });
        //Régénérer son mot de passe
        var resetPassWord = $resource(urlMain + 'users/bwaniaAuthReq/:email', {}, {
            reset: {method: 'PUT', interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                    },
                    responseError: function (data) {
                        console.log('error in interceptor', data);
                    }
                }}
        });
        // Consommation de la ressource d'activation du compte
        var activateAcount = $resource(urlMain + 'users/:email/:codeActivation', {}, {
            activate: {method: 'PUT', interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                    },
                    responseError: function (data) {
                        console.log('error in interceptor', data);
                    }
                }}
        });
        //Modifier son mot de passe
        var updatePassword = $resource(urlMain + 'users/bwaniaAuthReq/updateCredential', {}, {
            edit: {method: 'PUT', interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                    },
                    responseError: function (data) {
                        console.log('error in interceptor', data);
                    }
                }}
        });
        /**********************End consomming Jax-RS UtilisateurRessource************************************/



        /****************************consomming Jax-RS LoginRessource*************************************/
//Connection d'un utilisateur
        var loginUser = $resource(urlMain + 'login', {}, {
            login: {method: 'POST',
                interceptor: {
                    response: function (data) {
                        $cookieStore.put('login_status', true);
                        $cookieStore.put('auth_token', data.data);
                    },
                    responseError: function (data) {
                        $cookieStore.put('login_status', false);
                        $cookieStore.remove('auth_token');
                        console.log('error in interceptor', data);
                    }
                }
            }
        });
        /**********************End consomming Jax-RS LoginRessource************************************/



        /****************************consuming Controller Document*************************************/

        //Charger tous les documents
        var docResourceGet = $resource(urlMain + 'documents/:pageIndex');

        //Uploadre les informations d'un documents
        var docResource = $resource(urlMain + 'document/create');

        //Uploader un documents
        var docUpload = function (file, documentId, successCallBack, progressDownload) {
            $upload.upload({
                method: 'POST',
                url: urlMain + 'document/upload',
                data: {documentId: documentId},
                file: file
            }).progress(function (evt) {
                progressDownload(evt.loaded, evt.total);
            }).success(function (data) {
                successCallBack(data);
            });
        };

        //Charger les documents d'un utilisateur
        var getUserDocuments = $resource(urlMain + 'documents/:utilisateurId/:pageIndex');

        //Modification des informations d'un documents
        var editDoc = $resource(urlMain + 'documents/bwaniaAuthReq', {}, {
            edit: {method: 'PUT', interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                    },
                    responseError: function (data) {
                        console.log('error in interceptor', data);
                    }
                }}
        })

        //Suppression d'un documents
        var removeDocument = $resource(urlMain + 'documents/bwaniaAuthReq/:documentId', {}, {
            deleteDoc: {method: 'DELETE', interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                    },
                    responseError: function (data) {
                        console.log('error in interceptor', data);
                    }
                }}
        });


        //Nombre total des documents
        // var nbTotalDocument = $resource(urlMain + 'documents/numbreDesDoc');

        //Nombre total publié par un utilisateur
        var nbTotalUserDoc = $resource(urlMain + 'documents/user/:utilisateurId');

        //Filtre par dommaine
        var filterByDomaine = $resource(urlMain + 'documents/filter/:pageIndex/:infoTech/:mathematiques/:medecine'
                + '/:physiqueChimie/:banqueFinance/:economieGestion/:langues/:philoLit/:histGeogr/:trucsEtAstuces/:autre/:college'
                + '/:lycee/:univ');

        //Nombre total des documents filtré
        var nbTotalFilteredDocument = $resource(urlMain + 'documents/countfiltered/:infoTech/:mathematiques/:medecine'
                + '/:physiqueChimie/:banqueFinance/:economieGestion/:langues/:philoLit/:histGeogr/:trucsEtAstuces/:autre/:college'
                + '/:lycee/:univ');

        //Recupération des résultats de la recherche
        var getDocSearchResults = $resource(urlMain + 'documents/search/:pageIndex/:titre');

        //Nombre total des résultats de la recherche
        var nbTotalDocSearchResults = $resource(urlMain + 'documents/countresultas/:titre');

        //Recupération des résultats de la recherche filtré
        var getFilteredResultsByDomaine = $resource(urlMain + 'documents/searchfiltered/:pageIndex/:titre/:infoTech/:mathematiques/:medecine'
                + '/:physiqueChimie/:banqueFinance/:economieGestion/:langues/:philoLit/:histGeogr/:trucsEtAstuces/:autre/:college'
                + '/:lycee/:univ');

        //Nombre total des résultats de la recherche filtré
        var nbTotalFilteredResultsByDomaine = $resource(urlMain + 'documents/countfilteredresult/:titre/:infoTech/:mathematiques/:medecine'
                + '/:physiqueChimie/:banqueFinance/:economieGestion/:langues/:philoLit/:histGeogr/:trucsEtAstuces/:autre/:college'
                + '/:lycee/:univ');

        //Recupération des résultats de la recherche des documents d'un utilisateur
        var getUserDocSearchResults = $resource(urlMain + 'documents/user/:pageIndex/:titre/:utilisateurId');

        //Nombre total des résultats de la recherche des documents d'un utilisateur
        var nbTotalUserDocSearchResults = $resource(urlMain + 'documents/user/:titre/:utilisateurId');

        //Filtre par dommaine les documents d'un utilisateur
        var filterDocUserByDomaine = $resource(urlMain + 'documents/user/filter/:pageIndex/:utilisateurId/:infoTech/:mathematiques/:medecine'
                + '/:physiqueChimie/:banqueFinance/:economieGestion/:langues/:philoLit/:histGeogr/:trucsEtAstuces/:autre/:college'
                + '/:lycee/:univ');

        //Nombre total des documents filtrés  d'un utilisateur
        var nbTotalFilteredDocUserByDomaine = $resource(urlMain + 'documents/user/filter/:utilisateurId/:infoTech/:mathematiques/:medecine'
                + '/:physiqueChimie/:banqueFinance/:economieGestion/:langues/:philoLit/:histGeogr/:trucsEtAstuces/:autre/:college'
                + '/:lycee/:univ');

        //Recupération des résultats de la recherche filtré des documents d'un utilisateur
        var getUserFilteredResultsByDomaine = $resource(urlMain + 'documents/user/search/:pageIndex/:utilisateurId/:titre/:infoTech'
                + '/:mathematiques/:medecine/:physiqueChimie/:banqueFinance/:economieGestion/:langues/:philoLit/:histGeogr/:trucsEtAstuces'
                + '/:autre/:college'
                + '/:lycee/:univ');

        //Nombre total des résultats de la recherche filtré des documents d'un utilisateur
        var nbTotalUserFilteredResultsByDomaine = $resource(urlMain + 'documents/user/search/:utilisateurId/:titre/:infoTech/:mathematiques/:medecine'
                + '/:physiqueChimie/:banqueFinance/:economieGestion/:langues/:philoLit/:histGeogr/:trucsEtAstuces/:autre/:college'
                + '/:lycee/:univ');

        //Afficher les détails d'un documents
        var getOneDocById = $resource(urlMain + 'documents/:documentId');

        //Afficher les documents similaire
        var getDocSimilars = $resource(urlMain + 'documents/doc_similaire/:domaine');

        //Décorer du documents
        var setDocNote = $resource(urlMain + 'documents/bwaniaAuthReq/decorer_doc/:note/:documentId', {}, {
            setNote: {method: 'PUT', interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                    },
                    responseError: function (data) {
                        console.log('error in interceptor', data);
                    }
                }}
        });

        //Chargement des documments les plus consulté
        var getDocMoreConsulted = $resource(urlMain + 'documents');
        /**********************End consomming Jax-RS DocumentResource************************************/



        /**********************End consomming Jax-RS CommentaireRessource************************************/
        //Gérer les commentaires
        var setCommentaire = $resource(urlMain + 'commentaires/bwaniaAuthReq');

        //Lire les commentaires
        var getCommentaire = $resource(urlMain + 'commentaires/:id');
        /**********************consomming Jax-RS CommentaireRessource************************************/







        //Chargement de tous les établissements
        var getAllEtablissement = $resource(urlMain + 'etablissementscolaires');


        //Charger tous les entreprises
        var getEnterprise = $resource(urlMain + 'entreprises');



        //Ajouter un établissement scolaire
        var addEtablissement = $resource(urlMain + 'etablissementscolaires', {}, {
            saveEts: {method: 'POST', interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                    },
                    responseError: function (data) {
                        console.log('error in interceptor', data);
                    }
                }}
        });

        //Ajouter une entreprise
        var addEntreprise = $resource(urlMain + 'entreprises', {}, {
            saveEse: {method: 'POST', interceptor: {
                    response: function (data) {
                        console.log('response in interceptor', data);
                    },
                    responseError: function (data) {
                        console.log('error in interceptor', data);
                    }
                }}
        });

        //Charger un établissement
        var getOneEtablissement = $resource(urlMain + 'etablissementscolaires/:id');

        return {
            registerUser: createUser,
            createUserbyfb: createUserbyfb,
            setConnectedUser: function (value) {
                connectedUser = value;
                cookieEmail = $cookieStore.put('user_email', connectedUser.email);
            },
            getConnectedUser: getUser,
            updateUser: editUser,
            resetPassWord: resetPassWord,
            activateAcount: activateAcount,
            editPassword: updatePassword,
            connectUser: loginUser,
            docResourceGet: docResourceGet,
            docResource: docResource,
            docUpload: docUpload,
            docUrl: urlMain + 'documents/bwaniaAuthReq',
            docResourceByUser: getUserDocuments,
            editDocument: editDoc,
            deleteDocument: removeDocument,
            nbTotalUserDoc: nbTotalUserDoc,
            filterByDomaine: filterByDomaine,
            nbTotalFilteredDocument: nbTotalFilteredDocument,
            getDocSearchResults: getDocSearchResults,
            nbTotalDocSearchResults: nbTotalDocSearchResults,
            getFilteredResultsByDomaine: getFilteredResultsByDomaine,
            nbTotalFilteredResultsByDomaine: nbTotalFilteredResultsByDomaine,
            getUserDocSearchResults: getUserDocSearchResults,
            nbTotalUserDocSearchResults: nbTotalUserDocSearchResults,
            filterDocUserByDomaine: filterDocUserByDomaine,
            nbTotalFilteredDocUserByDomaine: nbTotalFilteredDocUserByDomaine,
            getUserFilteredResultsByDomaine: getUserFilteredResultsByDomaine,
            nbTotalUserFilteredResultsByDomaine: nbTotalUserFilteredResultsByDomaine,
            getOneDocById: getOneDocById,
            getDocSimilars: getDocSimilars,
            setDocNote: setDocNote,
            getDocMoreConsulted: getDocMoreConsulted,
            setCommentaire: setCommentaire,
            getCommentaire: getCommentaire,
            getAllEtablissement: getAllEtablissement,
            getEnterprise: getEnterprise,
            addEtablissement: addEtablissement,
            addEntreprise: addEntreprise,
            getOneEtablissement: getOneEtablissement
        };
    }
]);