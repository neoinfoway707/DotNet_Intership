function Check() {
    try {
        let demo = document.getElementById("demo");
        let input = document.getElementById("txtName").value;
        let a = isNaN(input);
        if (!isNaN(input)) {
            throw "Not allowed Number in Name";
        } else if (input === "") {
            throw "Please Enter your First Name";
        } else if (input.length >= 10) {
            throw "Name is Too Long";
        } else if (input.length <= 1) {
            throw "This Name Not Allowed";
        } else {
            throw "Done";
        }
    } catch (error) {
        demo.innerText = error;
    } finally {
        document.getElementById("txtName").value = "";
    }
}
