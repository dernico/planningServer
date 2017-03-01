angular.module('todoApp').component('todoAdd',
{
    templateUrl: 'Scripts/app/todo-add/todo-add.html',
    controller: [
        '$scope', '$http', "$location", function TodoController(scope, http, location) {
            var self = this;
            scope.todo = {
                Title: "",
                Description: "",
                Done: false
            };

            scope.add = function (todo) {
                http.post('api/todos/', todo).then(function () {
                    location.path('todos');
                });
            }
        }
    ]
});