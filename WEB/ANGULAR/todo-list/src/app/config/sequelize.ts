import {Sequelize} from 'sequelize-typescript';

export = new Sequelize({
  // repositoryMode: true,
  database: 'tasks_db',
  dialect: 'sqlite',
  username: 'root',
  password: '',
  // storage: __dirname + '/src/app/data/db.sqlite',
  storage: ':memory:',
  models: [__dirname + '/src/app/models/task.ts'],
});
