import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export default class TaskOrganizerService {
  public API = 'http://localhots:8080/api';
  public TASKORG_API = `${this.API}/taskorganizer`;

  constructor(private http: HttpClient) { }

}
