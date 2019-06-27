import { Component, Optional, Inject } from '@angular/core';
import { MainObjective } from '../shared/models/main-objective';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { element } from 'protractor';

@Component({
  selector: 'app-dialog-main-objective',
  templateUrl: './dialog-main-objective.component.html',
  styleUrls: ['./dialog-main-objective.component.css']
})
export class DialogMainObjective {
  minDate = new Date();
  

  constructor(
    public dialogRef: MatDialogRef<DialogMainObjective>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    if (data.deadLine) {
      this.data.isDeadline = true;
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
