'use strict';

app.controller('ModifierDocumentCtrl', ['$scope', '$upload', 'UserFactory', '$cookieStore', '$location', '$route',
    function($scope, $upload, userFactory, $cookieStore, $location, $route) {
        $scope.showMsgInfo = true;
        $scope.showErrorInfo = true;

        //Remplir les contôles des informations sur le document
        var getDoc = userFactory.getOneDocById.get({documentId: $route.current.params.documentId},
        function() {

             {

                $scope.document = userFactory.getOneDocById.get({documentId: $route.current.params.documentId});

                //Initialisation des variables qui n'ont pas besoins de maj.
                var locals = {};
                var getUser = userFactory.getConnectedUser.get({email: $cookieStore.get('user_email')},
                function() {
                    locals = {
                        pathStockageCrypte: getDoc.pathStockageCrypte,
                        codeActivation: getDoc.codeActivation,
                        fichier: getDoc.fichier,
                        utilisateur: getUser,
                        nbConsultation: getDoc.nbConsultation,
                        note: getDoc.note,
                        nbVote: getDoc.nbVote
                    };

                    //Mise à jour du document par l'événement ng-submit=updateDoc(document)
                    $scope.updateDoc = function(document) {

                        locals.id = $route.current.params.documentId;
                        locals.titre = document.titre;
                        locals.domaine = document.domaine;
                        locals.discipline = document.discipline;
                        locals.niveau = document.niveau;
                        locals.motCle = document.motCle;
                        locals.dateDePublication = document.dateDePublication;
                        locals.dateUpload = new Date();
                        locals.description = document.description;


                        userFactory.editDocument.edit(locals, function() {
                            $scope.messageInfo = $scope.document.fichier;
                            $scope.showMsgInfo = false;
                            $scope.showErrorInfo = true;
                        }, function() {
                            $scope.showErrorInfo = false;
                            $scope.showMsgInfo = true;
                            locals = $scope.document = {};
                        });
                    };
                });
            }
           
        }
        );


        if ($cookieStore.get('login_status') === true) {
        }


        //Remove Alert
        $scope.hideAlert = function() {
            $scope.showMsgInfo = true;
            $scope.showErrorInfo = true;
        }

        //Configuere la date maximale du date picker
        $scope.dateMax = new Date();
        $scope.open = function($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.opened = true;
        };
    }]);