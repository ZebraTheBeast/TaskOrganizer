import { Component, Optional, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-dialog-confirm-delete',
  templateUrl: './dialog-confirm-delete.component.html',
  styleUrls: ['./dialog-confirm-delete.component.css']
})
export class DialogConfirmDelete  {

  constructor(
    public dialogRef: MatDialogRef<DialogConfirmDelete>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: boolean
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
