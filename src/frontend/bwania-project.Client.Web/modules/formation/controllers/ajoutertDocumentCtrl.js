'use strict';

app.controller('ajoutertDocumentCtrl', ['$scope', 'UserFactory', 'uuid2', '$cookieStore',
    function ($scope, userFactory, uuid, $cookieStore) {
        $scope.showMsgInfo = true;
        $scope.showErrorInfo = true;

        var documentId = "";


        var locals = $scope.Document = {
            Titre: $scope.Titre,
            Domaine: $scope.Domaine,
            Discipline: $scope.Discipline,
            Diveau: $scope.Niveau,
            MotCle: $scope.MotCle,
            DateDePublication: $scope.DateDePublication,
            Description: $scope.Description
        }


        //var getUser = userFactory.getConnectedUser.get({ email: $cookieStore.get('user_email') },
        //function () {
        //    locals = $scope.document = {
        //        Titre: $scope.titre,
        //        Domaine: $scope.domaine,
        //        Discipline: $scope.discipline,
        //        Diveau: $scope.niveau,
        //        MotCle: $scope.motCle,
        //        DateDePublication: $scope.dateDePublication,
        //        Description: $scope.description
        //        //utilisateur: getUser
        //    }
        //});

        $scope.messageInfo = '';

        $scope.send = function (document) {

            locals.Titre = document.Titre;
            locals.Domaine = document.Domaine;
            locals.Discipline = document.Discipline;
            locals.Niveau = document.Niveau;
            locals.MotCle = document.MotCle;
            locals.DateDePublication = document.DateDePublication;
            locals.DateModification = new Date();
            locals.Description = document.Description;
            locals.Id = documentId;

            userFactory.docResource.save(locals, function () {
                $scope.showMsgInfo = false;
                $scope.showErrorInfo = true;
                $scope.document = {};
                $scope.fileName = "";
            }, function () {
                $scope.showErrorInfo = false;
                $scope.showMsgInfo = true;
                locals = $scope.document = {};
            });

        };

        $scope.onFileSelect = function (files) {
            documentId = "document-" +  uuid.newuuid();
            //$scope.document.Fichier = $files[0].name;
            userFactory.docUpload(files[0], documentId, function () {
                $scope.messageInfo = files[0].name;
            }, function (loaded, total) {
                var value = parseInt(100.0 * loaded / total);
                $scope.dynamic = value;
                $scope.fileName = files[0].name;
            });
        };



        //Remove Alert
        $scope.hideAlert = function () {
            $scope.showMsgInfo = true;
            $scope.showErrorInfo = true;
        }

        //Configurer la date maximale du date picker
        $scope.dateMax = new Date();
        $scope.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.opened = true;
        };
    }]);