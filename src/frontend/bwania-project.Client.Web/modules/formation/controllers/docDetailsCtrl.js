'use strict';

app.controller('docDetailsCtrl', ['$scope', '$cookieStore', 'UserFactory', '$route', '$location',
    function($scope, $cookieStore, UserFactory, $route, $location) {

        //Lecture des commentaires
        $scope.comments = UserFactory.getCommentaire.query({id : $route.current.params.documentId});

        //Vérifiction du status d'authentification
       

        var selectedDoc;

        $scope.document = selectedDoc = UserFactory.getOneDocById.get({documentId: $route.current.params.documentId},
        function() {
            //Affichage des documents similaires
            $scope.documents = UserFactory.getDocSimilars.query({domaine: selectedDoc.domaine});
            if (selectedDoc.nbVote !== 0)
                $scope.rate = Math.round(selectedDoc.moyenneNote);
            else
                $scope.rate = 0;
        });


        /*
         * Notation
         */
        //Mise à jour du document par l'événement ng-submit=updateDoc(document)
        $scope.setRate = function(rate) {

            

                var getDocument = UserFactory.getOneDocById.get({documentId: $route.current.params.documentId},
                function() {

                    //Initialisation des variables qui n'ont pas besoins de maj.
                    var locals = {};
                    var getUser = UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
                    function() {
                        locals = {
                            id: $route.current.params.documentId,
                            pathStockageCrypte: getDocument.pathStockageCrypte,
                            codeActivation: getDocument.codeActivation,
                            fichier: getDocument.fichier,
                            utilisateur: getUser,
                            nbConsultation: getDocument.nbConsultation,
                            note: getDocument.note,
                            nbVote: getDocument.nbVote,
                            titre: getDocument.titre,
                            domaine: getDocument.domaine,
                            discipline: getDocument.discipline,
                            niveau: getDocument.niveau,
                            motCle: getDocument.motCle,
                            dateDePublication: getDocument.dateDePublication,
                            dateUpload: getDocument.dateUpload,
                            description: getDocument.description
                        };

                        //Mise à jour du document
                        UserFactory.setDocNote.setNote({note: rate, documentId: $route.current.params.documentId}, locals,
                                //Rafraïchissement de la page
                                        function() {
                                            $scope.document = selectedDoc = UserFactory.getOneDocById.get({documentId: $route.current.params.documentId},
                                            function() {
                                                //Affichage des documents similaires
                                                if (selectedDoc.nbVote !== 0)
                                                    $scope.rate = Math.round(selectedDoc.moyenneNote);
                                                else
                                                    $scope.rate = 0;
                                            });
                                        });
                            });
                });


            
           
        };

        /*
         * Commentaire
         */
        $scope.SetComment = function(designation) {
            

                //Prendre les information sur l'utilisateur

                var locals = {
                        designation: designation,
                        dateAjout : new Date(),
                        document: {id: $route.current.params.documentId}
                    };
                var getUser = UserFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
                function() {                    
                    locals.utilisateur = {id: getUser.id};
                    //Ajouter le commentaire
                    UserFactory.setCommentaire.save({}, locals,
                        function(){
                            $scope.comments = UserFactory.getCommentaire.query({id : $route.current.params.documentId});
                        });
                });
            
        }

        $scope.docUrl = UserFactory.docUrl;



    }]);