var datetimeElement = document.getElementById("datetime");
var currentDate = new Date();
var options = { year: 'numeric', day: 'numeric', month: 'numeric', hour: 'numeric', minute: 'numeric' };
var datetimeString = currentDate.toLocaleString('en-US', options);
datetimeElement.textContent = datetimeString;

document.querySelector(".Post-button").addEventListener("click", function () {
    if (document.getElementById("yourInputFieldId").value === "") {
        console.log(document.getElementById("yourInputFieldId").value);
    } else {
        console.log(document.getElementById("yourInputFieldId").value);
        alert("Thank you for your feedback! It is now pending review.");
    }
});
