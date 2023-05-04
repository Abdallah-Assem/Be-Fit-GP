


const signUpButton = document.getElementById('signUp');
const usernameInput = document.getElementById("username");
const emailInput = document.getElementById("email");
const passwordInput = document.getElementById("password");

const signInButton = document.getElementById('signIn');
const container = document.getElementById('container');

function checkInputs() {
	if (usernameInput.value !== "" && emailInput.value !== "" && passwordInput.value !== "") {
		signUpButton.style.display = "block";
	} else {
		signUpButton.style.display = "none";
	}
}
usernameInput.addEventListener("input", checkInputs);
emailInput.addEventListener("input", checkInputs);
passwordInput.addEventListener("input", checkInputs);


signInButton.addEventListener('click', () => {
		container.classList.remove("right-panel-active");

	});
	signUpButton.addEventListener('click', () => {
			container.classList.add("right-panel-active");
	});


