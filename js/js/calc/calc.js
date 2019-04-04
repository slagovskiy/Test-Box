var readline = require('readline-sync');

var num = readline.question('Enter a number to be muliplied by 3: ');

console.log('Your number ' + num + ' multiplied by 3 equals ' + parseInt(num) * 3);