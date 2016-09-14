app.controller('homeController', ['$scope', '$rootScope','$cookies', 'apiService', function($scope, $rootScope, $cookies, apiService){

    var debug = true;

    

    $scope.register = function(){
        console.log($scope.username)
        
        apiService.post('/api/user/' + $scope.username, {}, function(err, result){
            if (!err){
                $cookies.put('demo_user', $scope.username);
                $rootScope.username = $scope.username;
                $('#myModal').modal('toggle');
                $scope.getData();
            }
        });
    }
    //commentss

    $scope.getData = function(){
        if (!$scope.username) return;

        apiService.get('/api/user/' + $scope.username, function(err, result){
            if (!err){
                $scope.user = result;
                return;
            }
            if (err.status = 404){
                $('#myModal').modal('toggle');
            }
            console.error(err);
        });

    }

    $scope.stageEmptyToDo = function(){
        $scope.newToDo = {};
    };

    $scope.commitNewToDo = function(){
        var todo = {
            id: $scope.user.toDos.length,
            text: $scope.newToDo.text
        }
        $scope.addToDo(todo);
    };

    $scope.addToDo = function(todo){
        if (!$scope.username) return;

        apiService.post('/api/todo/' + $scope.username, todo, function(err, result){
            if (!err){
                delete $scope.newToDo;
                $scope.user.toDos.push(todo);
                return;
            }
            console.error(err);
        });
    }

    $scope.updateToDo = function(todo){
        if (!$scope.username) return;

        apiService.put('/api/todo/' + $scope.username, todo, function(err, result){
            if (!err){             
                return;
            }
            console.error(err);
        });
    }

    $scope.removeToDo = function(todo){
        if (!$scope.username) return;

        apiService.put('/api/todo/' + $scope.username, todo, function(err, result){
            if (!err){
                var index = $scope.user.toDos.indexOf(todo);
                $scope.user.toDos.splice(index, 1);
                return;
            }
            console.error(err);
        });
    }

    $scope.username = $cookies.get("demo_user");
    if (!$scope.username){
        $('#myModal').modal('toggle');
    } else {
        $rootScope.username = $scope.username;
        $scope.getData();
    }

    
}]);