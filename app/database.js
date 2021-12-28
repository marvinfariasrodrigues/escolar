const Sequelize = require("sequelize");
const _sequelize = new Sequelize({
    dialect: 'sqlite',
    storage: 'c:\\sqlite\\escolar.db'
});

module.exports = _sequelize