'use strict';
/*
document.getElementById('loginButton').onclick = function() {
	require.ensure(['./login'], function(require){
	    let login = require('./login');
	    login();
	}, 'auth')
}

document.getElementById('logoutButton').onclick = function() {
	require.ensure(['./logout'], function(require){
	    let login = require('./logout');
	    login();
	}, 'auth')
}
*/

let moduleName = location.pathname.slice(1);
let route = require('./routes/' + moduleName);
route();
