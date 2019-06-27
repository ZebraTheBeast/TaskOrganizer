import { Component, OnInit } from '@angular/core';
import { AccountService } from './account.service';
import { Router } from '@angular/router';
import { MatIconRegistry } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  hide = true;
  username: string;
  password: string;
  status: string;
  constructor(
    private accountService: AccountService,
    private router: Router,
    private iconRegistry: MatIconRegistry,
    private sanitizer: DomSanitizer) {
    iconRegistry.addSvgIcon(
      'visibility',
      sanitizer.bypassSecurityTrustResourceUrl('assets/visibility.svg'));
    iconRegistry.addSvgIcon(
      'visibility_off',
      sanitizer.bypassSecurityTrustResourceUrl('assets/visibility_off.svg'));}

  ngOnInit() {
    if (localStorage.getItem("userId")) {
      this.router.navigate(['/dashboard']);
    } 
  }

  login(): void {
    this.accountService.login(this.username, this.password).subscribe(
      result => {
        if (result.status == "Ok") {
          localStorage.setItem("userId", result.user.id);
          this.router.navigate(['dashboard']);
        }
        else {
          this.status = result.status;
        }
      }
    );
  }

}
