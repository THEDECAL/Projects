import { Component, OnInit } from '@angular/core';
import { Task } from '../models/Task';
import { TaskCrud } from '../models/TaskCrud';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss'],
  providers: [TaskCrud]
})

export class TaskListComponent implements OnInit {
  public readonly title: string = 'Task List';
  public taskList: Task[] = [];

  constructor(private readonly crud: TaskCrud) { }

  public async getTaskList() {
    return await this.crud.get_all()
      .catch(err => { console.log(err); return undefined; });
  }

  ngOnInit(): void {
    this.getTaskList().then(list => this.taskList = list);
    console.log("taskList: " + this.taskList);
  }
}
