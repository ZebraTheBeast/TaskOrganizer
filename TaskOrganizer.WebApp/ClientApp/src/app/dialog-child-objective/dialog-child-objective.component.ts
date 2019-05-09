import { Component, Optional, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ChildObjective } from '../shared/models/child-objective';

@Component({
  selector: 'app-dialog-child-objective',
  templateUrl: './dialog-child-objective.component.html',
  styleUrls: ['./dialog-child-objective.component.css']
})
export class DialogChildObjective {

  constructor(
    public dialogRef: MatDialogRef<DialogChildObjective>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: ChildObjective 
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
