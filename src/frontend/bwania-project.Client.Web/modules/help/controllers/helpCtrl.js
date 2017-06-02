'use strict';

app.controller('helpCtrl', ['$scope', function($scope) {
	//Masquer les chanps inutiles
	$scope.BwCquoi = false;
	$scope.CmntSinscrir = false;
	$scope.CmntSeConnecter = false;
	$scope.CmntSeDeConnecter = false;
	$scope.QuiPeutCons = false;
	$scope.CmmntCons = false;
	$scope.QuiPeutPub = false;
	$scope.CmntPub = false;
	$scope.CmntSup = false;
	$scope.CmntMajInfo = false;
	$scope.CmntMajInfoCon = false;


	/*
	*
	*Méthode*/
	$scope.hideBwCquoi = function(){
		if ($scope.BwCquoi === true) {
			return $scope.BwCquoi = false;
		} else{
			return $scope.BwCquoi = true;
		};		
	}
	$scope.hideCmntSinscrir = function(){
		if ($scope.CmntSinscrir === true) {
			return $scope.CmntSinscrir = false;
		} else{
			return $scope.CmntSinscrir = true;
		};		
	}
	$scope.hideCmntSeConnecter = function(){
		if ($scope.CmntSeConnecter === true) {
			return $scope.CmntSeConnecter = false;
		} else{
			return $scope.CmntSeConnecter = true;
		};		
	}
	$scope.hideCmntSeDeConnecter = function(){
		if ($scope.CmntSeDeConnecter === true) {
			return $scope.CmntSeDeConnecter = false;
		} else{
			return $scope.CmntSeDeConnecter = true;
		};			
	}
	$scope.hideQuiPeutCons = function(){
		if ($scope.QuiPeutCons === true) {
			return $scope.QuiPeutCons = false;
		} else{
			return $scope.QuiPeutCons = true;
		};			
	}
	$scope.hideCmmntCons = function(){
		if ($scope.CmmntCons === true) {
			return $scope.CmmntCons = false;
		} else{
			return $scope.CmmntCons = true;
		};			
	}
	$scope.hideQuiPeutPub = function(){
		if ($scope.QuiPeutPub === true) {
			return $scope.QuiPeutPub = false;
		} else{
			return $scope.QuiPeutPub = true;
		};			
	}
	$scope.hideCmntPub = function(){
		if ($scope.CmntPub === true) {
			return $scope.CmntPub = false;
		} else{
			return $scope.CmntPub = true;
		};			
	}
	$scope.hideCmntSup = function(){
		if ($scope.CmntSup === true) {
			return $scope.CmntSup = false;
		} else{
			return $scope.CmntSup = true;
		};			
	}
	$scope.hideCmntMajInfo = function(){
		if ($scope.CmntMajInfo === true) {
			return $scope.CmntMajInfo = false;
		} else{
			return $scope.CmntMajInfo = true;
		};			
	}
	$scope.hideCmntMajInfoCon = function(){
		if ($scope.CmntMajInfoCon === true) {
			return $scope.CmntMajInfoCon = false;
		} else{
			return $scope.CmntMajInfoCon = true;
		};			
	}


}]);