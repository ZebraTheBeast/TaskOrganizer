import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Category } from '../shared/models/category';
import { MainObjective } from '../shared/models/main-objective';
import { ChildObjective } from '../shared/models/child-objective';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class DashboardService {
  private dashboardUrl = '/api/values';
  constructor(private http: HttpClient) { }

  getCategories(userId: number): Observable<any> {
    const url = `${this.dashboardUrl}/GetCategories`;
    return this.http.post<any>(url, userId, httpOptions);
  }

  addCategory(category: Category, id: number): Observable<Category> {
    const url = `${this.dashboardUrl}/AddCategory`;
    var request = {
      category: category,
      userId: id
    };

    return this.http.post<Category>(url, request, httpOptions);
  }

  editCategory(category: Category, userId: number): Observable<Category> {
    const url = `${this.dashboardUrl}/EditCategory`;
    var request = {
      category: category,
      userId: userId
    };

    return this.http.post<Category>(url, request, httpOptions);
  }

  deleteCategory(category: Category): Observable<any> {
    const url = `${this.dashboardUrl}/DeleteCategory`;
    return this.http.post<Category>(url, category.id, httpOptions); 
  }


  addMainObjective(mainObjective: MainObjective, categoryId: number): Observable<MainObjective> {
    const url = `${this.dashboardUrl}/AddMainObjective`;
    var request = {
      mainObjective: mainObjective,
      categoryId: categoryId
    };

    return this.http.post<MainObjective>(url, request, httpOptions);
  }

  editMainObjective(mainObjective: MainObjective): Observable<MainObjective> {
    const url = `${this.dashboardUrl}/EditMainObjective`;
    

    return this.http.post<MainObjective>(url, mainObjective, httpOptions);
  }

  deleteMainObjective(mainObjective: MainObjective): Observable<any> {
    const url = `${this.dashboardUrl}/DeleteMainObjective`;
   
    return this.http.post(url, mainObjective.id, httpOptions);
  }


  addChildObjective(childObjective: ChildObjective, mainObjectiveId: number): Observable<ChildObjective> {
    const url = `${this.dashboardUrl}/AddChildObjective`;
    var request = {
      childObjective: childObjective,
      mainObjectiveId: mainObjectiveId
    };

    return this.http.post<ChildObjective>(url, request, httpOptions);
  }

  editChildObjective(childObjective: ChildObjective): Observable<ChildObjective> {
    const url = `${this.dashboardUrl}/EditChildObjective`;

    return this.http.post<ChildObjective>(url, childObjective, httpOptions);
  }

  deleteChildObjective(childObjective: ChildObjective): Observable<any> {
    const url = `${this.dashboardUrl}/DeleteChildObjective`;

    return this.http.post(url, childObjective.id, httpOptions);
  }

  updateStatusMainObjective(mianObjectiveId: number, statusId: number): Observable<any> {
    const url = `${this.dashboardUrl}/UpdateStatusMainObjective`;
    var request = {
      objectiveId: mianObjectiveId,
      statusId: statusId
    }

    return this.http.post(url, request, httpOptions);
  }

  updateStatusChildObjective(childObjectiveId: number, statusId: number): Observable<any> {
    const url = `${this.dashboardUrl}/UpdateStatusChildObjective`;
    var request = {
      objectiveId: childObjectiveId,
      statusId: statusId
    }

    return this.http.post(url, request, httpOptions);
  }

}
