const { ipcRenderer } = require("electron");

const alunoForm = document.querySelector("#alunoForm");
const alunoNome = document.querySelector("#nome");
const alunoSobrenome = document.querySelector("#sobrenome");
const alunoList = document.querySelector("#alunoList");

let updateStatus = false;
let idAlunoToUpdate = "";
let alunos = [];

function deleteAluno(id) {
	const response = confirm("Tem certeza que quer deletar?");
	if (response) {
		ipcRenderer.send("delete-aluno", id);
	}
	return;
}

function editAluno(id) {
	updateStatus = true;
	idAlunoToUpdate = id;
	const _aluno = alunos.find(aluno => aluno.id === parseInt(id));
	alunoNome.value = _aluno.nome;
	alunoSobrenome.value = _aluno.sobrenome;
}

function renderAlunos(alunos) {
	alunoList.innerHTML = "";
	console.log(alunos);
	alunos.map(t => {
		alunoList.innerHTML += `
          <li class="card">
            <h4>
              ID: ${t.id}
            </h4>
            <p>
              Nome: ${t.nome}
            </p>
            <p>
              Sobrenome: ${t.sobrenome}
            </p>
            <button class="btn btn-danger" onclick="deleteAluno('${t.id}')">
              🗑 Deletar
            </button>
            <button class="btn btn-secondary" onclick="editAluno('${t.id}')">
              ✎ Editar
            </button>
          </li>
        `;
	});
}


ipcRenderer.send("get-alunos");

alunoForm.addEventListener("submit", async e => {
	e.preventDefault();

	const aluno = {
		nome: alunoNome.value,
		sobrenome: alunoSobrenome.value
	};

	console.log(updateStatus);

	if (!updateStatus) {
		ipcRenderer.send("new-aluno", aluno);
	} else {
		ipcRenderer.send("update-aluno", { ...aluno, idAlunoToUpdate });
	}

	alunoForm.reset();
});

ipcRenderer.on("new-aluno-created", (e, arg) => {
	console.log(arg);
	const alunoSaved = JSON.parse(arg);
	alunos.push(alunoSaved);
	console.log(alunos);
	renderAlunos(alunos);
	alert("Aluno Created Successfully");
	alunoNome.focus();
});

ipcRenderer.on("get-alunos", (e, args) => {
	const receivedAlunos = JSON.parse(args);
	alunos = receivedAlunos;
	renderAlunos(alunos);
});

ipcRenderer.on("delete-aluno-success", (e, args) => {
	const deletedAluno = JSON.parse(args);
	const newAlunos = alunos.filter(t => {
		return t.id !== deletedAluno.id;
	});
	alunos = newAlunos;
	renderAlunos(alunos);
});

ipcRenderer.on("update-aluno-success", (e, args) => {
	updateStatus = false;
	const updatedAluno = JSON.parse(args);
	alunos = alunos.map((t, i) => {
		if (t.id === updatedAluno.id) {
			t.nome = updatedAluno.nome;
			t.sobrenome = updatedAluno.sobrenome
		}
		return t;
	});
	renderAlunos(alunos);
});
