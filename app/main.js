const { BrowserWindow, ipcMain } = require("electron");
const Aluno = require("./models/aluno");

function createWindow() {
    const mainWindow = new BrowserWindow({
        width: 800,
        height: 600,
        webPreferences: {
            nodeIntegration: true
        }
    });

    mainWindow.loadFile("app/index.html");
}

ipcMain.on("new-aluno", async (e, arg) => {
    const resultado = await Aluno.sync();

    const newAluno = new Aluno(arg);
    const alunoSaved = await newAluno.save();
    console.log(alunoSaved);
    e.reply("new-aluno-created", JSON.stringify(alunoSaved));
});

ipcMain.on("get-alunos", async (e, arg) => {
    const alunos = await Aluno.findAll();
    e.reply("get-alunos", JSON.stringify(alunos));
});

ipcMain.on("delete-aluno", async (e, args) => {
    const alunoDeleted = await Aluno.findByPk(args);
    Aluno.destroy();
    e.reply("delete-aluno-success", JSON.stringify(alunoDeleted));
});

ipcMain.on("update-aluno", async (e, args) => {
    console.log(args);
    const alunoToUpdate = await Aluno.findByPk(args.idAlunoToUpdate);
    alunoToUpdate.nome = args.nome;
    alunoToUpdate.sobrenome = args.sobrenome;
    const resultadoSave = await alunoToUpdate.save();
    e.reply("update-aluno-success", JSON.stringify(alunoToUpdate));
});

module.exports = { createWindow };
