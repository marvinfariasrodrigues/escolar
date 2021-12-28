const Sequelize = require("sequelize");
const _sequelize = new Sequelize({
    dialect: 'sqlite',
    storage: 'c:\\sqlite\\escolar.db'
});

const aluno = _sequelize.define('aluno', {
    id: {
        type: Sequelize.INTEGER,
        autoIncrement: true,
        allowNull: false,
        primaryKey: true
    },
    nome: {
        type: Sequelize.STRING,
        allowNull: false
    },
    sobrenome: {
        type: Sequelize.STRING
    }
})

module.exports = aluno;