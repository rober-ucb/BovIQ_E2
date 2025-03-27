import { Component, Inject, inject, Input, Optional } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { BreedService } from '../../services/breed.service';
import { catchError, exhaustMap, filter, Subject, takeUntil } from 'rxjs';
import {
  Breed,
  CreateBreedRequest,
  UpdateBreedRequest,
} from '@app/core/models/breeds/breed';
import { AutoDestroyService } from '@app/core/common/auto-destroy.service';

@Component({
  selector: 'app-breed-form-dialog',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
  ],
  providers: [AutoDestroyService],
  templateUrl: './breed-form-dialog.component.html',
  styleUrl: './breed-form-dialog.component.css',
})
export class BreedFormDialogComponent {
    breedForm!: FormGroup;
    mode: 'add' | 'edit';
    // maxDate: Date;
    constructor(
      private fb: FormBuilder,
      private breedService: BreedService,
      private dialogRef: MatDialogRef<BreedFormDialogComponent>,
      @Inject(MAT_DIALOG_DATA)
      public data: { mode: 'add' | 'edit'; breed?: Breed }
    ) {
      this.mode = data.mode;
    }
  
    ngOnInit(): void {
      this.initForm();
      if (this.mode === 'edit' && this.data.breed) {
        this.breedForm.patchValue({
          ...this.data.breed,
        });
      }
    }
  
    initForm(): void {
      this.breedForm = this.fb.group({
        name: ['', Validators.required],
        description: ['', [Validators.required]],
      });
    }
  
    onSubmit(): void {
      if (this.breedForm.valid) {
        const breed: Breed = this.breedForm.value;
        const operation =
          this.mode === 'add'
            ? this.breedService.add(breed)
            : this.breedService.update(this.data.breed?.id ?? 0, breed);
  
        operation.subscribe(() => {
          this.dialogRef.close(true);
        });
      }
    }
  
    onCancel(): void {
      this.dialogRef.close(false);
    }
}
