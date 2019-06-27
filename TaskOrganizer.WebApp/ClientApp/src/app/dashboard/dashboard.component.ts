import { ChangeDetectionStrategy, Component, OnInit, ChangeDetectorRef, ViewChild } from '@angular/core';
import { Category } from '../shared/models/category';
import { MainObjective } from '../shared/models/main-objective';
import { DialogCreateCategory } from '../dialog-create-category/dialog-create-category.component';
import { MatDialog, MatAccordion } from '@angular/material';
import { DialogMainObjective } from '../dialog-main-objective/dialog-main-objective.component';
import { ChildObjective } from '../shared/models/child-objective';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material';
import { DashboardService } from './dashboard.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DashboardComponent implements OnInit {
  categories: Category[];
  userId: number;
  isCategoryChoosen: boolean = false;
  isMainObjectiveChoosen: boolean = false;
  @ViewChild("matAccordion") matAccordion: MatAccordion;
  choosenCategory?: Category = new Category();
  choosenMainObjective?: MainObjective;

  expanded: boolean = false;

  constructor(
    public dialog: MatDialog,
    private cd: ChangeDetectorRef,
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer,
    private dashboardService: DashboardService,
    private router: Router) {
    iconRegistry.addSvgIcon(
      'in-progress',
      sanitizer.bypassSecurityTrustResourceUrl('assets/in-progress.svg'));
    iconRegistry.addSvgIcon(
      'done',
      sanitizer.bypassSecurityTrustResourceUrl('assets/done.svg'));
  }

  ngOnInit() {
    console.log(localStorage.getItem("userId"));
    if (localStorage.getItem("userId")) {
      var newUserId = +localStorage.getItem("userId");
      this.userId = newUserId;
      this.dashboardService.getCategories(this.userId).subscribe(result => { this.categories = result; this.cd.markForCheck(); });
    } else {
      this.router.navigate(['account']);
    }
  }

  public chooseCategory(id: number): void {
    this.choosenCategory = this.categories.find(category => category.id == id);
    this.choosenMainObjective = new MainObjective();
  }

  public chooseMainObjective(id: number): void {
    this.matAccordion.closeAll();
    this.choosenMainObjective = this.choosenCategory.mainObjectives.find(mainObjective => mainObjective.id == id);
  }

  changeMainObjectiveStatus(id: number, idStatus: number): void {
    //db change status -danzo-
    this.dashboardService.updateStatusMainObjective(id, idStatus).subscribe(result => {
      this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives.find(mo => mo.id == id).status = idStatus;
      this.cd.markForCheck();
    });

  }

  changeChildObjectiveStatus(id: number, idStatus: number): void {
    //db change status -danzo-
    this.dashboardService.updateStatusChildObjective(id, idStatus).subscribe(result => {
      this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives.find(mo => mo.id == this.choosenMainObjective.id).childObjectives.find(childobj => childobj.id == id).status = idStatus;
      this.cd.markForCheck();
    });


  }

  openCategoryDialog(id?: number): void {
    let category: Category;
    let index: number;
    if (id) {
      category = this.categories.find(ctg => ctg.id == id);
      index = this.categories.findIndex(ctg => ctg.id == id);
    }
    else {
      category = new Category();
    }

    const dialogRef = this.dialog.open(DialogCreateCategory, {
      width: '250px',
      data: { title: category.title, description: category.description }
    });

    if (id) {
      dialogRef.afterClosed().subscribe(result => {
        //save to db change of categories -danzo-
        //-------------------------------
        if (result) {
          result.id = this.categories[index].id;
          this.dashboardService.editCategory(result, this.userId).subscribe(res => {
            console.log(res);
            this.categories[index] = result;
            this.categories = this.categories.slice();
            this.cd.markForCheck();
          }, ex => console.log(ex));
        }
      });
    }
    else {
      dialogRef.afterClosed().subscribe(result => {
        //save to db new category -danzo-
        if (result) {

          this.dashboardService.addCategory(result, this.userId).subscribe(
            newCategory => {
              console.log(newCategory);
              this.categories.push(newCategory);
              this.categories = this.categories.slice();
              this.cd.markForCheck();
            },
            error =>
              console.log(error));
        }
      });
    }
  }

  deleteCategory(id: number): void {
    //delte from db -danzo-
    let index: number;
    index = this.categories.indexOf(this.categories.find(ctg => ctg.id == id), 0);
    if (index > -1) {
      this.dashboardService.deleteCategory(this.categories[index]).subscribe(res => {

        this.categories.splice(index, 1);
        //delete all main objectives
        this.choosenMainObjective.childObjectives = undefined;
        this.choosenMainObjective = undefined;
        this.choosenCategory = undefined;

        this.categories = this.categories.slice();
        this.cd.markForCheck();
      });
    }
  }

  deleteMainObjective(id: number): void {
    //delte from db -danzo-
    let index: number;
    let categoryIndex: number;
    categoryIndex = this.categories.findIndex(ctg => ctg.id == this.choosenCategory.id);
    index = this.categories[categoryIndex].mainObjectives
      .findIndex(mainObjective => mainObjective.id == id);
    if (index > -1) {
      this.dashboardService.deleteMainObjective(this.categories[categoryIndex].mainObjectives[index]).subscribe(res => {
        this.categories[categoryIndex].mainObjectives.splice(index, 1);

        //delete all child obj
        this.choosenMainObjective.childObjectives = undefined;

        this.choosenCategory.mainObjectives = this.choosenCategory.mainObjectives.slice();
        this.cd.markForCheck();
      });
    }
  }

  deleteChildObjective(id: number): void {
    //delte from db -danzo-
    let index: number;
    let categoryIndex: number;
    let mainObjectiveIndex: number;

    categoryIndex = this.categories.findIndex(ctg => ctg.id == this.choosenCategory.id);
    mainObjectiveIndex = this.choosenCategory.mainObjectives.findIndex(mainObj => mainObj.id == this.choosenMainObjective.id);
    index = this.categories[categoryIndex].mainObjectives[mainObjectiveIndex].childObjectives
      .findIndex(childObjective => childObjective.id == id);
    if (index > -1) {
      this.dashboardService.deleteChildObjective(this.categories[categoryIndex].mainObjectives[mainObjectiveIndex].childObjectives[index])
        .subscribe(res => {
          this.categories[categoryIndex].mainObjectives[mainObjectiveIndex].childObjectives.splice(index, 1);

          this.choosenMainObjective.childObjectives = this.choosenMainObjective.childObjectives.slice();
          this.cd.markForCheck();
        });
    }
  }

  openMainObjectiveDialog(id?: number): void {
    let mainObjective: MainObjective;
    let index: number;

    if (!this.choosenCategory.id) {
      return null;
    }

    if (id) {
      mainObjective = this.choosenCategory.mainObjectives.find(ctg => ctg.id == id);
      index = this.choosenCategory.mainObjectives.findIndex(ctg => ctg.id == id);
    }
    else {
      mainObjective = new MainObjective();
    }

    const dialogRef = this.dialog.open(DialogMainObjective, {
      width: '260px',
      data: { title: mainObjective.title, description: mainObjective.description, deadLine: mainObjective.deadline }
    });

    if (id) {
      dialogRef.afterClosed().subscribe(result => {
        //save to db change of mainObjectives -danzo-
        if (result) {
          result.id = mainObjective.id;
          if (result.isDeadline) {
            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives[index].deadline = result.deadLine;
          }
          else {
            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives[index].deadline = null;
            result.deadLine = null;
          }

          this.dashboardService.editMainObjective(result).subscribe(res => {
            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives[index].title = result.title;
            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives[index].description = result.description;

            this.choosenCategory.mainObjectives = this.choosenCategory.mainObjectives.slice();
            this.cd.markForCheck();
          }, ex => console.log(ex));
        }
      });
    }
    else {
      dialogRef.afterClosed().subscribe(result => {
        //save to db new main objective
        //-------------------------------
        if (result) {
          this.dashboardService.addMainObjective(result, this.choosenCategory.id).subscribe(res => {

            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives.push(res);
            this.choosenCategory.mainObjectives = this.choosenCategory.mainObjectives.slice();
            this.choosenMainObjective = res;
            this.cd.markForCheck();
          });
        }
      });
    }
  }

  openChildObjectiveDialog(id?: number): void {
    let childObjective: ChildObjective;
    let index: number;

    if (!this.choosenMainObjective.id) {
      return null;
    }

    if (id) {
      childObjective = this.choosenMainObjective.childObjectives.find(ctg => ctg.id == id);
      index = this.choosenMainObjective.childObjectives.findIndex(ctg => ctg.id == id);
    }
    else {
      childObjective = new ChildObjective();
    }

    const dialogRef = this.dialog.open(DialogMainObjective, {
      width: '260px',
      data: { title: childObjective.title, description: childObjective.description, deadLine: childObjective.deadline }
    });

    if (id) {
      dialogRef.afterClosed().subscribe(result => {
        //save to db change of mainObjectives -danzo-
        //-------------------------------
        if (result) {
          result.id = childObjective.id;
          if (result.isDeadline) {
            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives.find(mo => mo.id == this.choosenMainObjective.id).childObjectives[index].deadline = result.deadLine;
          }
          else {
            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives.find(mo => mo.id == this.choosenMainObjective.id).childObjectives[index].deadline = null;
            result.deadLine = null;
          }
          this.dashboardService.editChildObjective(result).subscribe(res => {

            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives.find(mo => mo.id == this.choosenMainObjective.id).childObjectives[index].title = result.title;
            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives.find(mo => mo.id == this.choosenMainObjective.id).childObjectives[index].description = result.description;
            this.choosenMainObjective.childObjectives = this.choosenMainObjective.childObjectives.slice();
            this.cd.markForCheck();
          });
        }
      });
    }
    else {
      dialogRef.afterClosed().subscribe(result => {
        //save to db new main objective -danzo-
        //-------------------------------
        if (result) {
          if (this.choosenMainObjective.childObjectives == undefined) {
            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives.find(mo => mo.id == this.choosenMainObjective.id).childObjectives = [];
          }
          this.dashboardService.addChildObjective(result, this.choosenMainObjective.id).subscribe(res => {
            this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives.find(mo => mo.id == this.choosenMainObjective.id).childObjectives.push(res);
            this.choosenMainObjective.childObjectives = this.choosenMainObjective.childObjectives.slice();
            this.cd.markForCheck();
          });
        }
      });
    }
  }
}
