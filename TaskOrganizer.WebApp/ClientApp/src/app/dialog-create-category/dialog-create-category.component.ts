import { Component, Inject, Optional } from '@angular/core';
import { Category } from '../shared/models/category';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
@Component({
  selector: 'app-dialog-create-category',
  templateUrl: './dialog-create-category.component.html',
  styleUrls: ['./dialog-create-category.component.css']
})
export class DialogCreateCategory {

  constructor(
    public dialogRef: MatDialogRef<DialogCreateCategory>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Category
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
