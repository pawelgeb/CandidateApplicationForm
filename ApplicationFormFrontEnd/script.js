const jobExperience = document.querySelector(".SingleJobExperience");
const addJobButton = document.querySelector(".addJob");
const sendButton = document.querySelector(".sendButtonAPI");
const formPost = document.querySelector(".dataInputLines");
const coverLetter = document.querySelector(".attachmentCoverLetter");
const resume = document.querySelector(".attachmentResume");
const resumeAdditional = document.querySelector(".attachmentResumeAdditional");
const buttonAddJob = document.querySelector(".addJob");
const buttonSaveForm = document.querySelector(".saveForm");
const addResumeAdditional = document.querySelector(
	".attachmentResumeAdditionalButton"
);
let firstName, lastName, email;
let dateOfBirth, levelOfEducation;
let listOfJobs = [];
let coverLetterPath;
let formData;
const URL = "https://localhost:7252/api/form";

const addNewJobExperience = () => {
	const companyNameInput = document.getElementById("companyName").value;
	const startJobDateInput = document.getElementById("startJobDate").value;
	const endJobDateInput = document.getElementById("endJobDate").value;

	let table = document.querySelector("table");
	let template = `
	<tbody>
	<td>${companyNameInput}</td>
	<td>${startJobDateInput}</td>
	<td>${endJobDateInput}</td>
	</tbody>
	`;
	table.innerHTML += template;

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

const validInput = (input) => {
	if (input == "") {
		return alert(`Uzupełnij pole: ${input}`);
	}
};

const validEmail = (email) => {
	var mailformat =
		/^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
	if (email.match(mailformat)) {
		return true;
	}
	return false;
};

const validateFileType = (fileName) => {
	var re = /(\.jpg|\.jpeg|\.pdf|\.doc)$/i;
	if (!re.exec(fileName)) {
		alert(
			`Załączony plik: ${fileName} posiada niedozwolony format. Załącz plik w formacie pdf, doc lub jpg`
		);
	}
};

const sendForm = () => {
	var data = new FormData();
	firstName = document.getElementById("firstName").value;
	lastName = document.getElementById("lastName").value;
	dateOfBirth = document.getElementById("dateOfBirth").value;
	email = document.getElementById("email").value;
	levelOfEducation = document.getElementsByName("levelOfEducation")[0].value;
	const coverLetter = document.getElementById("attachmentCoverLetter").files[0];
	const resume = document.getElementById("attachmentResume").files[0];
	const resumeAdditional = document.getElementById("attachmentResumeAdditional")
		.files[0];

	const validInputCondition =
		firstName == "" ||
		lastName == "" ||
		dateOfBirth == "" ||
		email == "" ||
		levelOfEducation == undefined ||
		coverLetter == undefined ||
		resume == undefined;

	if (validInputCondition) {
		return alert("Uzupełnij puste pola formularza");
	}
	if (!validEmail(email)) {
		return alert("Niepoprawny format email!");
	}
	validateFileType(coverLetter.name);
	validateFileType(resume.name);
	if (resumeAdditional != undefined) {
		validateFileType(resumeAdditional.name);
	}
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
	axios
		.post(URL, data)
		.then((result) => {
			console.log(result);
		})
		.then(() => {
			return alert("Aplikacja została wysłana");
		});
};
buttonAddJob.addEventListener("click", addNewJobExperience);

const additionalResume = () => {
	document.getElementById("attachmentResumeAdditional").disabled = false;
};
addResumeAdditional.addEventListener("click", additionalResume);
sendButton.addEventListener("click", sendForm);
