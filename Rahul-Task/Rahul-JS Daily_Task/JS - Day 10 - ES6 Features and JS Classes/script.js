let write = document.getElementById("demo");
const add = a => a * a;
//Using Array Function to calculate Square
function Cal() {
    const inputNum = document.getElementById("txtNum").value;

    //Check number is valid or not
    const res = checkNumber(inputNum);
    if (res) {
        write.innerHTML = "SQuare is: " + add(Number(inputNum));
    }
}
//Using Object with Array Function to calculate Square
function obj() {
    const num1 = document.getElementById("txtNum").value;
    let text = "";

    //Create object for calculate and return square
    const cal = {
        num1,
        res: add(num1),
        get_Res: function () {
            return `Square Num is ` + this.num1 + ` result is: ` + this.res;
        },
        get() {
            return `Square of ` + this.num1 + ` is: ` + this.res;
        }
    }

    //Check number is valid or not
    const check = checkNumber(num1);
    let num = Number(num1);
    if (check) {
        let { num, res } = cal;
        text = "res variable to get square is: " + res;
        text += "<br>Get square using get_Res() is: " + cal.get_Res();
        text += "<br>Get square using get() is: " + cal.get();
        write.innerHTML = text;
    }

}

//super class
class Person {
    constructor(name) {
        this.name = name;
    }
    get_name() {
        return this.name;
    }
}
//sub class
class Square extends Person {
    constructor(name, num) {
        super(name);
        this.num = num;
    }
    square_Num() {
        return this.num * this.num;
    }
    get_Data() {
        return `Name is ${super.get_name()} and Square of ${this.num} is  ${this.square_Num()}`;
    }
}

//class used to calculate square and display it with user name
function cal_class() {
    const name = document.getElementById("txtName").value;
    const num = document.getElementById("txtNum").value;

    //Check number is valid or not
    const res = checkNumber(num);
    if (res) {
        const square = new Square(name, Number(num));
        write.innerHTML = "<br>Data : " + square.get_Data();
    }
}

//Function to Check number is valid or not for calculation
function checkNumber(inputNum) {
    try {
        if (isNaN(inputNum) || inputNum == "") {
            throw "Please Enter Number for calculate Square";
        }
        return Number.isInteger(Number(inputNum));
    }
    catch (err) {
        dispError(err)
    }
}

//function to display error
function dispError(msg) {
    document.getElementById("error").innerText = msg;
}