import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';  
import { Observable, of } from 'rxjs';
import { HttpRequest } from '@angular/common/http';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getAll();
  }

  getAll(): void {
    this.startGame().subscribe(
      title => {
        console.log(title);
      }
    );
  }
  
  startGame(): Observable<any> {
    return this.http.get("/api/values");
  }
}
