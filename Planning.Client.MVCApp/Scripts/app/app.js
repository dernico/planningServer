// Define the `todoApp` module
var phonecatApp = angular.module('todoApp', ['ngRoute']);

angular
    .module('todoApp')
    .config(['$locationProvider', '$routeProvider', function (locationProvicer, routeProvider) {

        locationProvicer.hashPrefix("");

        routeProvider
            .when('/todos', { template: '<todo-list></todo-list>' })
            .when('/add', { template: '<todo-add></todo-add>' })
            .otherwise('/todos');
    }]);