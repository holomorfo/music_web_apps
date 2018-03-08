// server
var express = require('express');
var path = require('path');

var app = express();
app.set('port', process.env.PORT || 5000);
app.use(express.static('public'));
app.use(express.static('public/plr_app'));
app.use(express.static('public/piano_dynamics_app'));

// Our first route
app.get('/', function (req, res) {
  //res.send('app_files/index.html');
  res.sendFile(path.join(__dirname + '/index.html'));
});

// Listen to port
app.listen(app.get('port'), function () {
  console.log('App is listening on port ' + app.get('port'));
});