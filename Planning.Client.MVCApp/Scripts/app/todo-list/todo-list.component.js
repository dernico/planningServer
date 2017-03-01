angular.module('todoApp').component('todoList',
{
    templateUrl: 'Scripts/app/todo-list/todo-list.html',
    controller: [
        '$scope', '$http', function TodoController(scope, http) {
            var self = this;
            scope.todos = [];

			scope.delete = function(id) {
			    http.delete('api/todos/' + id).then( function() {
			    	loadtodos();
			    });
			}

			var loadtodos = function() {
				http.get('api/todos').then(function(response) {
					scope.todos = response.data;
				});   
			}

            loadtodos();
        }
    ]
});