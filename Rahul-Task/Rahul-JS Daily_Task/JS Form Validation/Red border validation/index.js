const Fname = document.getElementById("Fname");
const Email = document.getElementById("Email");
const Pass = document.getElementById("Pass");
const ConfirmPas = document.getElementById("ConfirmPas");
const Address = document.getElementById("Address");
const Male = document.getElementById("Male");
const Female = document.getElementById("Female");
const Age = document.getElementById("Age");
const Dob = document.getElementById("Dob");
const birthTime = document.getElementById("birthTime");
const chkSupports = document.getElementById("chkSupports");
const chkReading = document.getElementById("chkReading");
const chkGames = document.getElementById("chkGames");
const Country = document.getElementById("Country");
const State = document.getElementById("State");
const City = document.getElementById("City");
const Phone = document.getElementById("Phone");
const PhoneCode = document.getElementById("PhoneCode");
const Color = document.getElementById("Color");
const Search = document.getElementById("Search");
const Filechoose = document.getElementById("File");
const ImgPreview = document.getElementById("ImgPreview");
const Range = document.getElementById("Range");
const RangeValue = document.getElementById("RangeValue")
const Url = document.getElementById("Url");

//Pattterns for different field for validation
const NamePattern = /^[A-Za-z\s]+$/;
const AddressPattern = /^[A-Za-z0-9\s,./#&'(-]+$/;
const AgePattern = /^[1-9][0-9]{0,1}$/;
const DobPattern = /^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$/
const EmailPattern = /^[a-z0-9,._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/;
const UrlPattern = /^(https?:\/\/)(www\.)?[a-zA-Z0-9-]+\.[a-zA-Z]{2,}(\/[^\s]*)?$/;
const PassPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$/;

const LoginEmail = document.getElementById("LoginEmail");
const LoginPass = document.getElementById("LoginPass");

//validate login fields
function loginValidation() {
    clearAllErrors();
    const validateFields = [
        {
            id: "LoginEmail",
            correctValue: "admin123@gmail.com",
            emptyMsg: "Please enter Email.",
            issueMsg: "Requied valid Email"
        },
        {
            id: "LoginPass",
            correctValue: "Admin@123",
            emptyMsg: "PLease enter assword",
            issueMsg: "Required valid Password"
        }
    ]
    let isvalid = true;
    validateFields.forEach(field => {
        const input = document.getElementById(field.id);
        if (input.value.trim() == "") {
            showError(field.id);
            isvalid = false;
        } else if (input.value != field.correctValue) {
            showError(field.id);
            isvalid = false;
        }
    })
    if (!isvalid) return false;
    window.location.href = "logout.html?userEmail=" + encodeURIComponent(LoginEmail.value);
    return false;
}

//display error message
function showError(elementId) {
    if (elementId == "Gender") {
        document.querySelector(".gender-group").classList.add("is-invalid");
        return;
    } if (elementId == "Hobbies") {
        document.querySelector(".hobbies-group").classList.add("is-invalid");
        return;
    }
    const input = document.getElementById(elementId);
    input.classList.add("is-invalid");
}

//clear all error message
function clearAllErrors() {
    document.querySelectorAll(".is-invalid").forEach(el => el.classList.remove("is-invalid"));
}

//clear specific field's error message
function clearError(elementId) {
    const input = document.getElementById(elementId);
    input.classList.remove("is-invalid");
}
//live preview password is strog or coorect
Pass.addEventListener('input', () => {
    Pass.style.borderColor = PassPattern.test(Pass.value) ? "green" : "red";
});
ConfirmPas.addEventListener('input', () => {
    ConfirmPas.style.borderColor = Pass.value == ConfirmPas.value ? "green" : "red";
});

//Reset live preview for password
[Pass, ConfirmPas].forEach(input => {
    input.onblur = function () {
        this.style.borderColor = "";
    };
});

//show or hide password
function togglePassword(id) {
    const inputType = document.getElementById(id);
    if (inputType.type == "password") {
        inputType.type = "text";
    } else {
        inputType.type = "password";
    }
}

//validate file upload data
Filechoose.addEventListener('change', function (event) {
    const file = event.target.files[0];
    if (!file) return;

    const size = 2 * 1024 * 1024;
    if (file.size > size) {
        Filechoose.value = "";
        ImgPreview.style.display = "none";
        ImgPreview.src = "";
        showError("File");
    }
    const allowedTypes = ['image/png', 'image/gif', 'image/jpeg'];
    if (!allowedTypes.includes(file.type)) {
        Filechoose.value = "";
        ImgPreview.style.display = "none";
        ImgPreview.src = "";
        showError("File");
        return;
    }
    clearError("File");
    ImgPreview.src = URL.createObjectURL(file);
    ImgPreview.style.display = "block";
});

//change range field data 
Range.addEventListener('input', () => {
    RangeValue.textContent = Range.value;
});

//registration fields validations
function validation() {
    event.preventDefault();
    clearAllErrors();

    let isValid = true;

    let PhonePattern;
    if (Country.value === "1")
        PhonePattern = /^[6-9]\d{9}$/;
    else if (Country.value === "2")
        PhonePattern = /^9\d{9}$/;
    else if (Country.value === "3")
        PhonePattern = /^[789]0\d{8}$/;

    if (!validate(Fname.value, "First Name", "Fname", NamePattern))
        isValid = false;
    if (!validate(Email.value, "Email", "Email", EmailPattern))
        isValid = false;
    if (!validate(Pass.value, "Password", "Pass", PassPattern))
        isValid = false;

    if (ConfirmPas.value.trim() === "") {
        showError("ConfirmPas");
        isValid = false;
    } else if (Pass.value !== ConfirmPas.value) {
        showError("ConfirmPas");
        isValid = false;
    }

    if (!validate(Address.value, "Address", "Address", AddressPattern))
        isValid = false;

    if (!(Male.checked || Female.checked)) {
        showError("Gender");
        isValid = false;
    }

    if (!validate(Age.value, "Age", "Age", AgePattern))
        isValid = false;
    if (!validate(Dob.value, "Date Of Birth", "Dob", DobPattern))
        isValid = false;

    if (birthTime.value === "") {
        showError("birthTime");
        isValid = false;
    }

    if (!(chkReading.checked || chkSupports.checked || chkGames.checked)) {
        showError("Hobbies");
        isValid = false;
    }

    if (Country.value === "") {
        showError("Country");
        isValid = false;
    } else if (State.value === "") {
        showError("State");
        isValid = false;
    } else if (City.value === "") {
        showError("City");
        isValid = false;
    }

    if (!validate(Phone.value, "Phone Number", "Phone", PhonePattern))
        isValid = false;

    if (Color.value === "#000000") {
        showError("Color");
        isValid = false;
    }

    if (!validate(Search.value, "Search", "Search"))
        isValid = false;

    if (Range.value === "0") {
        showError("Range");
        isValid = false;
    }

    if (!validate(Url.value, "URL", "Url", UrlPattern))
        isValid = false;

    if (Filechoose.files.length === 0) {
        showError("File");
        isValid = false;
    }

    if (!isValid) {
        const firstElement = document.querySelector(".is-invalid");
        if (firstElement.classList.contains("gender-group")) {
            Male.focus();
        } else if (firstElement.classList.contains("hobbies-group")) {
            chkSupports.focus();
        }
        firstElement.focus();
        return false;
    }
    window.location.href = "Success.html?userEmail=" + encodeURIComponent(Email.value);
}
//validatation for login and registartion fields
function validate(value, fieldName, element, pattern = null) {
    const inputField = document.getElementById(element);
    if (value == "" || value.trim() == "") {
        showError(element);
        return false;
    }
    if (fieldName == "Address") {
        if (value.length < 5 || value.length > 60) {
            showError(element);
            return false;
        }
        return true;
    } else if (fieldName == "Age") {
        if (Number(value) < 16 || Number(value) > 100) {
            showError(element);
            return false;
        }
        return true;
    } else if (fieldName == "Date Of Birth") {
        const today = new Date();
        const selectedDate = new Date(value);
        const selectedYear = selectedDate.getFullYear();

        if (selectedDate > today) {
            showError(element);
            return false;
        } else if (selectedYear > 2006 || selectedYear < 2000) {
            showError(element);
            return false;
        }
        return true;
    } else if (fieldName == "Search") {
        if (value.trim().length < 3) {
            showError(element);
            return false;
        }
        return true;
    }
    if (!pattern || !pattern.test(value.trim())) {
        if (fieldName == "Password") {
            showError(element);
            return false;
        } else {
            showError(element)
            return false;
        }
    }
    clearError(element);
    return true;
}

//dislay registration form
function showRegister() {
    const register = document.getElementById("register");
    register.classList.remove("d-none");
    register.classList.add("d-flex");
}

//hide registration form
function hideRegister() {
    const register = document.getElementById("register");
    register.classList.add("d-none");
    register.classList.remove("d-flex");
}

const PhoneCodeNumber = { "1": "+91", "2": "+7", "3": "+81" };
//display phone code and display state data
function funCountry() {
    const country = document.getElementById("Country");
    document.getElementById("PhoneCode").value = PhoneCodeNumber[country.value] || "";
    DispState(country);
}

const locationData = {
    "1": {
        "states": { "1": "Gujarat", "2": "Maharashtra", "3": "Rajesthan" },
        "cities": {
            "1": ["Rajkot", "Ahmedabad", "Surat"],
            "2": ["Mumbai", "Pune", "Nagpur"],
            "3": ["Jaipur", "Jodhpur", "Udaipur"]
        }
    },
    "2": {
        "states": { "1": "Moscow", "2": "Saint Petersburg", "3": "Krasnodar Krai" },
        "cities": {
            "1": ["Balashikha", "Podolsk", "Khimki"],
            "2": ["Gatchina", "Vyborg", "Vsevolozhs"],
            "3": ["Sochi", "Novorossiysk", "Krasnodar"]
        }
    },
    "3": {
        "states": { "1": "Tokyo", "2": "Kyoto", "3": "Osaka" },
        "cities": {
            "1": ["Shibuya", "Hachioji", "Shinjuku"],
            "2": ["Kyoto City", "Uji", "Maizuru"],
            "3": ["Osaka City", "Sakai", "Higashiosaka"]
        }
    }
};

//display state data when select country
function DispState(country) {
    const state = document.getElementById("State");
    const city = document.getElementById("City");
    const countryId = country.value;

    let options = `<option value="">--Select State--</option>`;
    if (locationData[countryId]) {
        const states = locationData[countryId].states;
        for (let id in states) {
            options += `<option value="${id}">${states[id]}</option>`;
        }
    }
    state.innerHTML = options;
    city.innerHTML = `<option value="">--Select City--</option>`;
}

//display city when select state
function funState() {
    const countryId = document.getElementById("Country").value;
    const stateId = document.getElementById("State").value;
    const city = document.getElementById("City");

    let options = `<option value="">--Select City--</option>`;
    if (locationData[countryId] && locationData[countryId].states[stateId]) {
        const cities = locationData[countryId].cities[stateId];
        cities.forEach((cityName, index) => {
            options += `<option value="${index + 1}">${cityName}</option>`;
        });
    }
    city.innerHTML = options;
}