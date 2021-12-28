const sequelize = require('../database');
const _sequelize = new Sequelize({
    dialect: 'sqlite',
    storage: 'c:\\sqlite\\escolar.db'
});

const aluno = sequelize.define('aluno', {
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
    descricao: {
        type: Sequelize.STRING
    }
})

module.exports = aluno;