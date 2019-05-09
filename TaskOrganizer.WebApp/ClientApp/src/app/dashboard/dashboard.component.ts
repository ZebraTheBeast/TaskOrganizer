import { ChangeDetectionStrategy, Component, OnInit, ChangeDetectorRef, ViewChild } from '@angular/core';
import { Category } from '../shared/models/category';
import { CATEGORIES } from '../shared/models/mock-category';
import { MainObjective } from '../shared/models/main-objective';
import { DialogCreateCategory } from '../dialog-create-category/dialog-create-category.component';
import { MatDialog, MatAccordion } from '@angular/material';
import { DialogMainObjective } from '../dialog-main-objective/dialog-main-objective.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DashboardComponent implements OnInit {
  categories: Category[] = CATEGORIES;
  mainstep = 999;
  childstep = 999;
  isCategoryChoosen: boolean = false;
  isMainObjectiveChoosen: boolean = false;

  isCategoryOpen = false;
  choosenCategory?: Category = new Category();
  choosenMainObjective?: MainObjective;

  expanded: boolean = false;

  constructor(public dialog: MatDialog, private cd: ChangeDetectorRef) { }

  ngOnInit() {  }

  public chooseCategory(id: number): void {
    this.mainstep = 999;
    this.isCategoryOpen = false;
    this.choosenCategory = this.categories.find(category => category.id == id);
    this.choosenMainObjective = new MainObjective();
  }

  public chooseMainObjective(id: number): void {
    this.childstep = 999;
    this.choosenMainObjective = this.choosenCategory.mainObjectives.find(mainObjective => mainObjective.id == id);
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
        //save to db change of categories
        //-------------------------------
        if (result) {
          this.categories[index].title = result.title;
          this.categories[index].description = result.description;

          this.categories = this.categories.slice();
          this.cd.markForCheck();
        }
      });
    }
    else {
      dialogRef.afterClosed().subscribe(result => {
        //save to db new category
        //-------------------------------
        if (result) {
          this.categories.push(this.testingCategory(result.title, result.description));
          this.categories = this.categories.slice();
          this.cd.markForCheck();
        }
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
      width: '250px',
      data: { title: mainObjective.title, description: mainObjective.description, status: mainObjective.status, deadLine: mainObjective.deadLine }
    });

    if (id) {
      dialogRef.afterClosed().subscribe(result => {
        //save to db change of mainObjectives
        //-------------------------------
        if (result) {
          this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives[index].title = result.title;
          this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives[index].description = result.description;
          this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives[index].status = result.status;
          this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives[index].deadLine = result.deadLine;

          this.categories = this.categories.slice();
          this.choosenCategory = this.categories.find(ctg => ctg.id == this.choosenCategory.id);
          this.cd.markForCheck();
        }
      });
    }
    else {
      dialogRef.afterClosed().subscribe(result => {
        //save to db new main objective
        //-------------------------------
        if (result) {
          this.categories.find(ctg => ctg.id == this.choosenCategory.id).mainObjectives.push(this.testingMainObjective(result.title, result.status, result.deadLine, result.description));
          this.choosenCategory.mainObjectives = this.choosenCategory.mainObjectives.slice();
          this.cd.markForCheck();
        }
      });
    }
  }



  private testingMainObjective(title: string, status: string, deadLine: Date, description?: string): MainObjective {
    let mainObjective: MainObjective = new MainObjective();
    let index: number;
    index = this.choosenCategory.mainObjectives.length;
    mainObjective.id = index + 1;
    mainObjective.title = title;
    mainObjective.description = description;
    mainObjective.status = status;
    mainObjective.deadLine = deadLine;
    mainObjective.childObjectives = [];

    return mainObjective;
  }


  private testingCategory(title: string, description?: string): Category {
    let category: Category = new Category();
    let index: number;
    index = this.categories.length;
    category.id = index + 1;
    category.title = title;
    category.description = description;
    category.mainObjectives = [];

    return category;
  }
}
