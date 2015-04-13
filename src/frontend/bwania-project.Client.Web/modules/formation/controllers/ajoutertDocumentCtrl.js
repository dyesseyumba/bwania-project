'use strict';

app.controller('ajoutertDocumentCtrl', ['$scope', '$upload', 'UserFactory', '$cookieStore', '$location',
    function($scope, $upload, userFactory, $cookieStore, $location) {
        $scope.showMsgInfo=true;
        $scope.showErrorInfo=true;


        

            var locals = {};
            var getUser = userFactory.getConnectedUser.get({email: $cookieStore.get('user_email')}, 
            function(){             
            locals = $scope.document = {
                titre: $scope.titre,
                domaine: $scope.domaine,
                discipline: $scope.discipline,
                niveau: $scope.niveau,
                motCle: $scope.motCle,
                dateDePublication: $scope.dateDePublication,
                description: $scope.description,
                utilisateur: getUser}
            });

            $scope.messageInfo = '';

            $scope.send = function(document) {
                        
                locals.titre = document.titre,
                locals.domaine = document.domaine,
                locals.discipline = document.discipline,
                locals.niveau = document.niveau,
                locals.motCle = document.motCle,
                locals.dateDePublication = document.dateDePublication,
                locals.dateUpload = new Date();
                locals.description = document.description,
                                
                userFactory.docResource.save(locals, function() {
                    $scope.messageInfo = $scope.document.fichier;
                    $scope.showMsgInfo=false;
                    $scope.showErrorInfo=true;
                    $scope.document = {};
                }, function(){
                    $scope.showErrorInfo=false;
                    $scope.showMsgInfo=true;
                    locals = $scope.document = {};
                });

            };

            $scope.onFileSelect = function($files) {
                $scope.document.fichier = $files[0].name;
                userFactory.docUpload($files[0], function(data) {
                    $scope.document.pathStockageCrypte = data;
                }, function(loaded, total){
                    var value = parseInt(100.0 * loaded / total);
                    $scope.dynamic = value;
                });
            };

       

         //Remove Alert
        $scope.hideAlert = function(){
             $scope.showMsgInfo=true;
             $scope.showErrorInfo=true;
        }
        
        //Configuere la date maximale du date picker
        $scope.dateMax = new Date();
        $scope.open = function($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
  };
    }]);