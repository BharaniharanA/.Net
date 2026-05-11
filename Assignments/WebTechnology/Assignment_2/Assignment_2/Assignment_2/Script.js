//1. Write a JavaScript program to find the area of a triangle where three sides are 5, 6, 7.
function Area() {
    let a = 5, b = 6, c = 7;

    let s = (a + b + c) / 2;

    let area = Math.sqrt(s * (s - a) * (s - b) * (s - c));

    console.log("Area of triangle:", area.toPrecision(4));
}



//2. Write a JavaScript program to construct the following pattern, using a nested for loop.
function pattern() {
    console.log("Triangle Pattern");
    var n = prompt("Enter the size:");
    
    for (let i = 1; i <= n; i++) {
        let pattern = "";

        for (let j = 1; j <= i; j++) {
            pattern += "* ";
        }
        console.log(pattern);
    }
}



//3. Write a JavaScript program to determine whether a given year is a leap year
function LeapYear() {

    let year = prompt("Enter the Year:");

    if ((year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0)) {
        console.log(year + " is a Leap Year");
    } else {
        console.log(year + " is not a Leap Year");
    }

}


//4. Write a JavaScript program that calculates the number of days left until
//Independence Day by comparing the current date with August 15th of the current year.
//If today is after August 15th, it calculates the days until next year's
//Independence Day.The difference in days is then logged to the console.
function DaysLeftforIndependence() {
    var tday = new Date;
    var year = tday.getFullYear();
    var indday = new Date(year, 7, 15);

    if (tday < indday) {
        var diff = indday - tday;
    }
    else {
        inday = new Date(year + 1, 7, 15);
        var diff = indday - tday;
    }
    var days = Math.ceil(diff / (1000 * 60 * 60 * 24))
    console.log(days);
}


Area();
pattern();
LeapYear();
DaysLeftforIndependence();