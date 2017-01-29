var dateOfBirth = global('%DATE_OF_BIRTH');
var expectedYears = global('%LIFE_EXPECTANCY');

var splitDOB = dateOfBirth.split('-');

// Months are 0-indexed.
var dateOfDeath = [ 
	parseInt(splitDOB[0]), 
	parseInt(splitDOB[1]) - 1, 
	parseInt(splitDOB[2]) + parseInt(expectedYears)
];

// Get current date
var today = new Date();
var currentDay = today.getDate();
var currentMonth = today.getMonth();
var currentYear = today.getFullYear();

var t1 = new Date(dateOfDeath[2], dateOfDeath[1], dateOfDeath[0]);
var t2 = new Date(currentYear, currentMonth, currentDay);
var dif = t1.getTime() - t2.getTime();
var timeLeft= dif / 1000;

setGlobal('%SECONDS_LEFT', Math.abs(timeLeft));