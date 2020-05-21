class SequelizeService {
  constructor() {
    const { Sequelize } = require('sequelize')
    const dbConfig = require('../configs/DataBase')

    this.connection = new Sequelize(dbConfig.uri, dbConfig.options)
  }

  async checkConnect() {
    try {
      await this.connection.authenticate()
      console.log('Connection has been established successfully.')
      await this.connection.close()

      return true;
    } catch (error) {
      console.error('Unable to connect to the database:', error)

      return false;
    }
  }
}

module.exports = new SequelizeService()
