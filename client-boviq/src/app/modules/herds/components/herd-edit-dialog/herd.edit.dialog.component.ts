import { ChangeDetectionStrategy, Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';

@Component({
  selector: 'app-herd-edit',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
  template: ` <h2 mat-dialog-title>Edit User</h2>
    <mat-dialog-content>
      <p>Editing user: {{ data.name }}</p>
      <!-- Add form fields for editing -->
    </mat-dialog-content>
    <mat-dialog-actions>
      <button mat-button (click)="onSave()">Save</button>
      <button mat-button (click)="onCancel()">Cancel</button>
    </mat-dialog-actions>`,
  styleUrl: './herd.edit.dialog.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HerdEditDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<HerdEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
  onCancel(): void {
    this.dialogRef.close();
  }

  onSave(): void {
    // Implement save logic
    this.dialogRef.close();
  }
}
