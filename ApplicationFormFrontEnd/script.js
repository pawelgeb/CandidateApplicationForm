const jobExperience = document.querySelector(".SingleJobExperience");
const addJobButton = document.querySelector(".addJob");
const sendButton = document.querySelector(".sendButton");
const formPost = document.querySelector(".dataInputLines");
const coverLetter = document.querySelector(".attachmentCoverLetter");
const resume = document.querySelector(".attachmentResume");
const buttonConfirmFirstName = document.querySelector(".confirmFirstName");
const buttonConfirmLastName = document.querySelector(".confirmLastName");
const buttonConfirmDateOfBirth = document.querySelector(".confirmDateOfBirth");
const buttonConfirmEmail = document.querySelector(".confirmEmail");
const buttonConfirmCoverLetter = document.querySelector(".confirmCoverLetter");
const buttonAddJob = document.querySelector(".addJob");

let firstName, lastName, email;
let listOfJobs = [];
let coverLetterPath;

const URL = "https://localhost:7252/api/form";

const putFirstName = () => {
	firstName = document.getElementById("firstName").value;
	console.log(firstName);
};

const putSecondName = () => {
	lastName = document.getElementById("lastName").value;
	console.log(lastName);
};

const putEmail = () => {
	email = document.getElementById("email").value;
	console.log(email);
};

const putDateOfBirth = () => {
	dateOfBirth = document.getElementById("dateOfBirth").value;
	console.log(dateOfBirth);
};

const putCoverLetterPath = () => {
	const file = document.getElementById("atachmentCoverLetter").value;
	const reader = new FileReader();
	coverLetterPath = reader.readAsDataURL(file);
	console.log(coverLetterPath);
};

const addNewJobExperience = () => {
	const companyNameInput = document.getElementById("companyName").value;
	const startJobDateInput = document.getElementById("startJobDate").value;
	const endJobDateInput = document.getElementById("endJobDate").value;
	listOfJobs.push({
		companyName: companyNameInput,
		startJobDate: startJobDateInput,
		endJobDate: endJobDateInput,
	});
	console.log(listOfJobs);
	document.getElementById("companyName").value = "";
	document.getElementById("startJobDate").value = "";
	document.getElementById("endJobDate").value = "";
};

buttonConfirmFirstName.addEventListener("click", putFirstName);
buttonConfirmLastName.addEventListener("click", putSecondName);
buttonConfirmEmail.addEventListener("click", putEmail);
buttonConfirmDateOfBirth.addEventListener("click", putDateOfBirth);
buttonConfirmCoverLetter.addEventListener("click", putCoverLetterPath);
buttonAddJob.addEventListener("click", addNewJobExperience);

const postForm = () => {
	axios
		.post(URL, {
			firstName: firstName,
			lastName: lastName,
			email: email,
			dateOfBirth: dateOfBirth,
			coverLetter: coverLetterPath,

			previousJobs: listOfJobs,
		})
		.then((response) => displayOutput(response))
		.catch((err) => console.log(err));
};

sendButton.addEventListener("click", postForm);
