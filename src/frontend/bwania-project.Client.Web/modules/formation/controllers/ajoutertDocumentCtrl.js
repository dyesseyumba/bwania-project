'use strict';

app.controller('ajoutertDocumentCtrl', ['$scope', '$upload', 'UserFactory', '$cookieStore',
    function ($scope, $upload, userFactory, $cookieStore) {
        $scope.showMsgInfo = true;
        $scope.showErrorInfo = true;




        var locals = $scope.document = {
            Titre: $scope.titre,
            Domaine: $scope.domaine,
            Discipline: $scope.discipline,
            Diveau: $scope.niveau,
            MotCle: $scope.motCle,
            DateDePublication: $scope.dateDePublication,
            Description: $scope.description
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

            locals.Titre = document.Titre,
            locals.Domaine = document.Domaine,
            locals.Discipline = document.Discipline,
            locals.Niveau = document.Niveau,
            locals.MotCle = document.MotCle,
            locals.DateDePublication = document.DateDePublication,
            locals.DateModification = new Date();
            locals.Description = document.Description,

            userFactory.docResource.save(locals, function () {
                $scope.messageInfo = $scope.document.Fichier;
                $scope.showMsgInfo = false;
                $scope.showErrorInfo = true;
                $scope.document = {};
            }, function () {
                $scope.showErrorInfo = false;
                $scope.showMsgInfo = true;
                locals = $scope.document = {};
            });

        };

        $scope.onFileSelect = function ($files) {
            $scope.document.Fichier = $files[0].name;
            userFactory.docUpload($files[0], function (data) {
                $scope.document.pathStockageCrypte = data;
            }, function (loaded, total) {
                var value = parseInt(100.0 * loaded / total);
                $scope.dynamic = value;
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