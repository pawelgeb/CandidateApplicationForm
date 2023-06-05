const jobExperience = document.querySelector(".SingleJobExperience");
const addJobButton = document.querySelector(".addJob");
const sendButton = document.querySelector(".sendButtonAPI");
const formPost = document.querySelector(".dataInputLines");
const coverLetter = document.querySelector(".attachmentCoverLetter");
const resume = document.querySelector(".attachmentResume");
const resumeAdditional = document.querySelector(".attachmentResumeAdditional");
const buttonConfirmFirstName = document.querySelector(".confirmFirstName");
const buttonConfirmLastName = document.querySelector(".confirmLastName");
const buttonConfirmDateOfBirth = document.querySelector(".confirmDateOfBirth");
const buttonConfirmEmail = document.querySelector(".confirmEmail");
const buttonLevelOfEducation = document.querySelector(".levelOfEducation");
const buttonConfirmCoverLetter = document.querySelector(".confirmCoverLetter");
const buttonAddJob = document.querySelector(".addJob");
const buttonConfirmResume = document.querySelector(".confirmResume");
const buttonConfirmResumeAdditional = document.querySelector(
	".confirmResumeAdditional"
);
const buttonSaveForm = document.querySelector(".saveForm");

let firstName, lastName, email;
let dateOfBirth, levelOfEducation;
let listOfJobs = [];
let coverLetterPath;
let formData;

const levelsEducation = {
	elementary: "elementary",
	secondary: "secondary",
	higher: "higher",
};

const URL = "https://localhost:7252/api/form";

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

var data = new FormData();
const addtoFormData = () => {
	firstName = document.getElementById("firstName").value;
	lastName = document.getElementById("lastName").value;
	dateOfBirth = document.getElementById("dateOfBirth").value;
	email = document.getElementById("email").value;
	levelOfEducation = document.getElementById("levelOfEducation").value;
	const coverLetter = document.getElementById("attachmentCoverLetter").files[0];
	const resume = document.getElementById("attachmentResume").files[0];
	const resumeAdditional = document.getElementById("attachmentResumeAdditional")
		.files[0];

	data.append("firstName", firstName);
	data.append("lastName", lastName);
	data.append("dateOfBirth", dateOfBirth);
	data.append("email", email);
	data.append("levelOfEducation", levelOfEducation);
	data.append("coverLetterFile", coverLetter);
	data.append(`resumesFile`, resume);
	data.append(`resumeFileAdditional`, resumeAdditional);

	for (var i = 0; i < listOfJobs.length; i++) {
		data.append(`previousJobs[${i}].companyName`, listOfJobs[i].companyName);
		data.append(`previousJobs[${i}].startJobDate`, listOfJobs[i].startJobDate);
		data.append(`previousJobs[${i}].endJobDate`, listOfJobs[i].endJobDate);
	}
	console.log([...data]);
};
buttonSaveForm.addEventListener("click", addtoFormData);

const formEl = document.getElementById("dataInputLines");

var inputLetter = document.getElementById("attachmentCoverLetter");
var inputResumes = document.getElementById("attachmentResume");
var inputResumesAdditional = document.getElementById(
	"attachmentResumeAdditional"
);

const postForm = () => {
	axios.post(URL, data).then((result) => {
		console.log(result);
	});
	return alert("Aplikacja została wysłana");
};
sendButton.addEventListener("click", postForm);
