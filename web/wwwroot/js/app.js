var app = angular.module('demo-app', ['ngCookies']);
app.config(function($httpProvider){
    $httpProvider.defaults.headers.delete = { 'Content-Type' : 'application/json' };
})