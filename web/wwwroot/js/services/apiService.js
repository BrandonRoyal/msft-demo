app.service('apiService', function($http, $rootScope){

    var isDebug = false; //TODO: pull from env variables
    var service = {};

    service.get = function(url, callback){
        if (isDebug){
            var fakeData = {
            "id": "broyal",
                "toDos": [
                    {
                    "id": 1,
                    "text": "foo",
                    "complete": false
                    },
                    {
                    "id": 2,
                    "text": "bar",
                    "complete": true
                    }
                ]
            }
            return callback(null, fakeData);
        }
        $http.get(url).then(function(response){
            return callback(null, response.data);
        }, function(err){
            return callback(err);
        });
    }

    service.post = function(url, data, callback){
        if (isDebug){
            var fakeData = {};
            return callback(null, fakeData);
        }
        $http.post(url, data).then(function(response){
            return callback(null, response.data);
        }, function(err){
            return callback(err);
        });
    }

    service.put = function(url, data, callback){
        if (isDebug){
            var fakeData = {};
            return callback(null, fakeData);
        }
        $http.put(url, data).then(function(response){
            return callback(null, response.data);
        }, function(err){
            return callback(err);
        });
    }

    service.delete = function(url, data, callback){
        if (isDebug){
            var fakeData = {};
            return callback(null, fakeData);
        }
        $http.delete(url, data).then(function(response){
            return callback(null, response.data);
        }, function(err){
            return callback(err);
        });
    }

    return service;
});