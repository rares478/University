var api = require('./api.js').app;
var users = require('./users.json');

api.get('/',function(request,response){
  response.json("node.js backend");
});

api.get('/users',function(request,response){
  response.json(users)
});

api.put('/users',function(request,response){
  users[users.length] = request.body;
    response.json('User was saved successfully');
});

api.delete('/users/:id',function(request,response){
  users.splice(request.params.id,1);
    response.json('User with index' + request.params.id + ' was deleted successfully');
});

api.listen(3000, function(){
    console.log('Server is running on port 3000');
    console.log('http://localhost:3000');
})
