import {Table, Column, Model} from 'sequelize-typescript';

@Table
class Task extends Model<Task> {
  @Column
  name: string;

  @Column
  description: string;

  @Column
  dateStart: Date;

  @Column
  dateFinish: Date;

  @Column
  completed: boolean;

  @Column
  owner: string;
}
