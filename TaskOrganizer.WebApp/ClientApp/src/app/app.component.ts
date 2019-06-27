import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  logged: boolean = false;

  constructor(private router: Router) { }

  ngOnInit() {
    if (localStorage.getItem("userId")) {
      this.logged = true;
    }
  }

  logout(): void {
    localStorage.removeItem("userId");
    this.router.navigate(['account']);
  }

}
