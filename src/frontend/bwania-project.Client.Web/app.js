'use strict';

var app = angular.module('bwania', ['ngRoute', 'ngCookies', 'bwaniaAnimations', 'customServices', 'ui.bootstrap', 
    'angularFileUpload', 'facebook', 'angular-loading-bar', 'angularUUID2'])
        .config(['$routeProvider', '$httpProvider','FacebookProvider',
         function($routeProvider, $httpProvider, facebookProvider) {
        $routeProvider.when('/home', {templateUrl: 'modules/home/views/homeView.html', controller: 'homeCtrl'});
        $routeProvider.when('/formation', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/:titre', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/infoTech/:infoTech', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/mathematiques/:mathematiques', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/medecine/:medecine', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/physiqueChimie/:physiqueChimie', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/banqueFinance/:banqueFinance', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/economieGestion/:economieGestion', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/langues/:langues', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/histGeogr/:histGeogr', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/philoLit/:philoLit', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'})
        $routeProvider.when('/formation/trucsEtAstuces/:trucsEtAstuces', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/autre/:autre', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/college/:college', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/lycee/:lycee', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/formation/univ/:univ', {templateUrl: 'modules/formation/views/formationView.html', controller: 'formationCtrl'});
        $routeProvider.when('/ajouterundocument', {templateUrl: 'modules/formation/views/ajoutertDocumentView.html', controller: 'ajoutertDocumentCtrl'});
        $routeProvider.when('/modifierundocument/:documentId',
                {templateUrl: 'modules/formation/views/ModifierDocumentView.html', controller: 'ModifierDocumentCtrl'});
        $routeProvider.when('/mydocuments', {templateUrl: 'modules/formation/views/myDocumentsView.html', controller: 'myDocumentsCtrl'});
        $routeProvider.when('/docDetails', {templateUrl: 'modules/formation/views/docDetailsView.html', controller: 'docDetailsCtrl'});
        $routeProvider.when('/docDetails/:documentId', {templateUrl: 'modules/formation/views/docDetailsView.html', controller: 'docDetailsCtrl'});
        $routeProvider.when('/updatecredentials', {templateUrl: 'modules/user/views/updateCredentialView.html', controller: 'updateCredentialCtrl'});
        $routeProvider.when('/userhome', {templateUrl: 'modules/user/views/userHomeView.html', controller: 'userHomeCtrl'});
        $routeProvider.when('/login', {templateUrl: 'modules/login/views/loginView.html', controller: 'loginCtrl'});
        $routeProvider.when('/first_Login', {templateUrl: 'modules/login/views/firstLoginView.html', controller: 'firstLoginCtrl'});
        $routeProvider.when('/resetpassword', {templateUrl: 'modules/login/views/resetPassWordView.html', controller: 'resetPassWordCtrl'});
        $routeProvider.when('/signup', {templateUrl: 'modules/login/views/signupView.html', controller: 'signupCtrl'});
        $routeProvider.when('/setprofil', {templateUrl: 'modules/login/views/setProfilView.html', controller: 'setProfilCtrl'});        
        $routeProvider.when('/compteActivation/:email/:codeActivation',
                {templateUrl: 'modules/user/views/compteActivationView.html', controller: 'compteActivationCtrl'});
        $routeProvider.when('/help', {templateUrl: 'modules/help/views/helpView.html', controller: 'helpCtrl'});
        $routeProvider.when('/redirectionlogin', {templateUrl: 'modules/redirection/views/redirectionLoginView.html', controller: 'redirectionLoginCtrl'});
        $routeProvider.when('/redirectionlogin2', {templateUrl: 'modules/redirection/views/redirectionLoginView2.html', controller: 'redirectionLoginCtrl2'});
        $routeProvider.when('/add_etablissement', {templateUrl: 'modules/etablissement/views/creerEtablissementView.html', controller: 'CreerEtablissementCtrl'});
        $routeProvider.when('/add_entreprise', {templateUrl: 'modules/entreprise/views/ceerEntrepriseView.html', controller: 'creerEntrepriseCtrl'});
        $routeProvider.when('/entreprise', {templateUrl: 'modules/entreprise/views/entrepriseView.html', controller: 'entrepriseCtrl'});
        $routeProvider.when('/etablissements', {templateUrl: 'modules/etablissement/views/etablissementsView.html', controller: 'etablissementsCtrl'});
        $routeProvider.when('/etablissement/:etablissementID', {templateUrl: 'modules/etablissement/views/etablissementView.html', controller: 'etablissementCtrl'});
        $routeProvider.otherwise({redirectTo: '/home'});

        //CORS
        $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];

        //Initialisation de facebook javascript SDK
        facebookProvider.init('1414324985471775');

    }]);

// Activates the Carousel
$('.carousel').carousel({
    interval: 5000
});

var serviceBase = 'http://localhost:27573/';

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

//app.config(function ($httpProvider) {
//    $httpProvider.interceptors.push('authInterceptorService');
//});

//app.run(['authService', function (authService) {
//    authService.fillAuthData();
//}]);