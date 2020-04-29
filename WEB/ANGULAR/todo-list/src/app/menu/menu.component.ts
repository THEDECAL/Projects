import { Component, OnInit } from '@angular/core';
import {Sequelize} from 'sequelize-typescript';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  title = 'ToDoList!';
  constructor() {
    this.checkDb();
  }

  async checkDb(){
    try {
      const seqlz =  new Sequelize({
        database: 'tasks_db',
        dialect: 'sqlite',
        username: 'root',
        password: '',
        storage: ':memory:',
        models: [__dirname + '/src/app/models/task.ts']
      });
      seqlz.authenticate();
      console.log('Connection has been established successfully.');
    } catch (error) {
      console.error('Unable to connect to the database:', error);
    }
  }

  ngOnInit(): void {
  }

}
