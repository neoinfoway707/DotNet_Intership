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
const Color = document.getElementById("Color");
const Search = document.getElementById("Search");
const Filechoose = document.getElementById("File");
const ImgPreview = document.getElementById("ImgPreview");
const Range = document.getElementById("Range");
const RangeValue = document.getElementById("RangeValue");
const Url = document.getElementById("Url");

//validation field value using pattern
const NamePattern = /^[A-Za-z\s]+$/;
const AddressPattern = /^[A-Za-z0-9\s,./#&'(-]+$/;
const AgePattern = /^[1-9][0-9]{0,1}$/;
const DobPattern = /^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$/;
const EmailPattern = /^[a-z0-9,._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/;
const UrlPattern = /^(https?:\/\/)(www\.)?[a-zA-Z0-9-]+\.[a-zA-Z]{2,}(\/[^\s]*)?$/;
const PassPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$/;

// show error toast
function showToast(element, message) {
    document.getElementById("toastMsg").textContent = message;
    element.focus();
    const toast = new bootstrap.Toast(document.getElementById("errorToast"), { delay: 3000 });
    toast.show();
}

// show success toast
function showSuccessToast(message) {
    document.getElementById("toastMsg").textContent = message;
    const toastId = document.getElementById("errorToast");
    toastId.classList.remove("text-bg-danger");
    toastId.classList.add("text-bg-success");
    const toast = new bootstrap.Toast(toastId, { delay: 3000 });
    toast.show();
}

// validate login fields
function loginValidation() {
    const LoginEmail = document.getElementById("LoginEmail");
    const LoginPass = document.getElementById("LoginPass");

    if (LoginEmail.value !== "admin123@gmail.com") {
        showToast(LoginEmail, "Required valid Email");
        return false;
    }
    if (LoginPass.value !== "Admin@123") {
        showToast(LoginPass, "Required valid Password");
        return false;
    }
    showSuccessToast("Login Success.");
    setTimeout(() => {
        window.location.href = "logout.html?userEmail=" + encodeURIComponent(LoginEmail.value);
    }, 1000);
    return false;
}

// live preview password
Pass.addEventListener('input', () => {
    Pass.style.borderColor = PassPattern.test(Pass.value) ? "green" : "red";
});
ConfirmPas.addEventListener('input', () => {
    ConfirmPas.style.borderColor = Pass.value == ConfirmPas.value ? "green" : "red";
});
[Pass, ConfirmPas].forEach(input => {
    input.onblur = function () { this.style.borderColor = ""; };
});

// show hide password
function togglePassword(id) {
    const el = document.getElementById(id);
    el.type = el.type == "password" ? "text" : "password";
}

// file upload validation
Filechoose.addEventListener('change', function (event) {
    const file = event.target.files[0];
    if (!file) return;
    if (file.size > 2 * 1024 * 1024) {
        Filechoose.value = "";
        ImgPreview.style.display = "none";
        ImgPreview.src = "";
        showToast(Filechoose, "Image size too large! Choose image under 2MB.");
        return;
    }
    const allowedTypes = ['image/png', 'image/gif', 'image/jpeg'];
    if (!allowedTypes.includes(file.type)) {
        Filechoose.value = "";
        ImgPreview.style.display = "none";
        ImgPreview.src = "";
        showToast(Filechoose, "Select a valid image (jpg, png, or gif).");
        return;
    }
    ImgPreview.src = URL.createObjectURL(file);
    ImgPreview.style.display = "block";
});

Range.addEventListener('input', () => {
    RangeValue.textContent = Range.value;
});

// registration validation
function validation() {
    event.preventDefault();

    let PhonePattern;
    if (Country.value === "1")
        PhonePattern = /^[6-9]\d{9}$/;
    else if (Country.value === "2")
        PhonePattern = /^9\d{9}$/;
    else if (Country.value === "3")
        PhonePattern = /^[789]0\d{8}$/;

    //validate Fname
    if (!validate(Fname.value, "First Name", "Fname", NamePattern))
        return false;

    ///validate Email
    if (!validate(Email.value, "Email", "Email", EmailPattern))
        return false;

    //validate Password
    if (!validate(Pass.value, "Password", "Pass", PassPattern))
        return false;

    //validate confirm password
    if (ConfirmPas.value === "") {
        showToast(ConfirmPas, "Required Confirm Password.");
        return false;
    } else if (Pass.value !== ConfirmPas.value) {
        showToast(ConfirmPas, "Password and Confirm Password is not same.");
        return false;
    }

    //validate Address
    if (!validate(Address.value, "Address", "Address", AddressPattern))
        return false;

    //validate Gender
    if (!(Male.checked || Female.checked)) {
        showToast(Male, "Select Gender.");
        return false;
    }

    //vlidate Age
    if (!validate(Age.value, "Age", "Age", AgePattern))
        return false;

    //validate Date of Birth
    if (!validate(Dob.value, "Date Of Birth", "Dob", DobPattern))
        return false;

    //validate birth Time
    if (birthTime.value === "") {
        showToast(birthTime, "Select Birth Time.");
        return false;
    }

    //validate Hobbies 
    if (!(chkReading.checked || chkSupports.checked || chkGames.checked)) {
        showToast(chkSupports, "Select Hobbies.");
        return false;
    }

    //validate country, state, city
    if (Country.value === "") {
        showToast(Country, "Select Country.");
        return false;
    } else if (State.value === "") {
        showToast(State, "Select State.");
        return false;
    } else if (City.value === "") {
        showToast(City, "Select City.");
        return false;
    }

    //validate Phone
    if (!validate(Phone.value, "Phone Number", "Phone", PhonePattern))
        return false;

    //validate Color
    if (Color.value === "#000000") {
        showToast(Color, "Select a Color other than black.");
        return false;
    }

    //validate Search
    if (!validate(Search.value, "Search", "Search"))
        return false;

    //validate Range
    if (Range.value === "0") {
        showToast(Range, "Select Rate from 1 to 10.");
        return false;
    }

    //validate Url
    if (!validate(Url.value, "URL", "Url", UrlPattern))
        return false;

    //validate File Upload image
    if (Filechoose.files.length === 0) {
        showToast(Filechoose, "Select an image under 2MB.");
        return false;
    }

    //call success toast message
    showSuccessToast("Registration Success.");
    setTimeout(() => {
        window.location.href = "Success.html?userEmail=" + encodeURIComponent(Email.value);
    }, 1000);
}

//validatation for login and registartion fields
function validate(value, fieldName, element, pattern = null) {
    const inputField = document.getElementById(element);
    if (value == "" || value.trim() == "") {
        showToast(inputField, `Required ${fieldName}`);
        return false;
    }
    if (fieldName == "Address") {
        if (value.length < 5 || value.length > 60) {
            showToast(inputField, `${fieldName} must be between 5 and 60 characters.`);
            return false;
        }
        return true;
    } else if (fieldName == "Age") {
        if (Number(value) < 16 || Number(value) > 100) {
            showToast(inputField, `${fieldName} must be between 16 and 100.`);
            return false;
        }
        return true;
    } else if (fieldName == "Date Of Birth") {
        const today = new Date();
        const selectedDate = new Date(value);
        const selectedYear = selectedDate.getFullYear();
        if (selectedDate > today) {
            showToast(inputField, `${fieldName} cannot be a future date.`);
            return false;
        } else if (selectedYear > 2006 || selectedYear < 2000) {
            showToast(inputField, `${fieldName} year must be between 2000 and 2006.`);
            return false;
        }
        return true;
    } else if (fieldName == "Search") {
        if (value.trim().length < 3) {
            showToast(inputField, `${fieldName} must be at least 3 characters.`);
            return false;
        }
        return true;
    }
    if (!pattern || !pattern.test(value.trim())) {
        if (fieldName == "Password") {
            showToast(inputField, `Enter minimum 8 character strong ${fieldName}.`);
        } else {
            showToast(inputField, `Enter valid ${fieldName}.`);
        }
        return false;
    }
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

const PhoneCode = { "1": "+91", "2": "+7", "3": "+81" };
//display phone code and display state data
function funCountry() {
    const country = document.getElementById("Country");
    document.getElementById("PhoneCode").value = PhoneCode[country.value] || "";
    DispState(country);
}

const locationData = {
    "1": {
        states: { "1": "Gujarat", "2": "Maharashtra", "3": "Rajasthan" },
        cities: {
            "1": ["Rajkot", "Ahmedabad", "Surat"],
            "2": ["Mumbai", "Pune", "Nagpur"],
            "3": ["Jaipur", "Jodhpur", "Udaipur"]
        }
    },
    "2": {
        states: { "1": "Moscow", "2": "Saint Petersburg", "3": "Krasnodar Krai" },
        cities: {
            "1": ["Balashikha", "Podolsk", "Khimki"],
            "2": ["Gatchina", "Vyborg", "Vsevolozhsk"],
            "3": ["Sochi", "Novorossiysk", "Krasnodar"]
        }
    },
    "3": {
        states: { "1": "Tokyo", "2": "Kyoto", "3": "Osaka" },
        cities: {
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
        for (let id in locationData[countryId].states) {
            options += `<option value="${id}">${locationData[countryId].states[id]}</option>`;
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
    if (locationData[countryId]?.cities[stateId]) {
        locationData[countryId].cities[stateId].forEach((name, i) => {
            options += `<option value="${i + 1}">${name}</option>`;
        });
    }
    city.innerHTML = options;
}