import { Task, ITask } from './Task';
import { throwError, Observable } from 'rxjs';
import { Urls } from '../configs/Urls';
import { HttpClient } from '@angular/common/http';
import { catchError, observeOn } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { __values, __asyncValues } from 'tslib';
import { prototype } from 'events';

interface ICrud<T> {
  // GET
  get_all(): Promise<T[]>;
  find(text: string): T[];

  get(id: number): T;
  del(id: number): boolean;
  // POST
  add(obj: T): boolean;
  update(obj: T): boolean;
}

@Injectable()
export class Crud<T extends ITask> implements ICrud<T> {
  private readonly type: T;
  private readonly http: HttpClient;

  constructor(type: T, http: HttpClient) {
    this.type = type;
    this.http = http;
  }

  public async get_all(): Promise<T[]> {
    const url = Urls.API.concat('/' + this.get_all.name);

    return await this.http.jsonp<T[]>(url, (obj: any): string => (obj as string).);
      // .pipe((data: string): spring[] => JSON.parse(data))
      // .map((item): T => new Array<T>((JSON.parse(item)))
      // ));
        // .subscribe(list => list);
  }

  public async get(id: number): Observable<Task> {
    return await this.http.get(Urls.API.concat('/' + this.get.name))
      .pipe((feed: any): any => {
        const task = JSON.parse(feed);
        return task instanceof Task
          ? task : undefined;
      }, catchError(err => {
        console.log(err);
        return throwError(err);
      }));
  }

  public async del(id: number): Observable<boolean> {
    return await this.http.get(Urls.API.concat('/' + this.del.name))
      .pipe((result: any) =>
        (JSON.parse(result) instanceof Boolean
          ? result : false), catchError(err => {
            console.log(err);
            return throwError(err);
          }));
  }

  public async add(task: this): Observable<boolean> {
    throw new Error('Method not implemented.');
  }

  async update(task: this): Observable<boolean> {
    throw new Error('Method not implemented.');
  }

  public async find(text: string): Observable<any[]> {
    throw new Error('Method not implemented.');
  }
}
