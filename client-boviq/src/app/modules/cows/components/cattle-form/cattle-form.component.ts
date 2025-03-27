import { Component, Inject, signal, WritableSignal } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { provideNativeDateAdapter } from '@angular/material/core';
import { Cattle } from '@app/core/models/cows/cow';
import { CattleService } from '../../services/cow.service';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogModule,
} from '@angular/material/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { BreedService } from '@app/modules/breeds/services/breed.service';
import { Breed } from '@app/core/models/breeds/breed';

@Component({
  selector: 'app-cattle-form',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatDialogModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatButtonModule,
  ],
  providers: [provideNativeDateAdapter()],
  templateUrl: './cattle-form.component.html',
  styleUrl: './cattle-form.component.css',
})
export class CattleFormComponent {
  cattleForm!: FormGroup;
  mode: 'add' | 'edit';
  // maxDate: Date;
  breeds: WritableSignal<Breed[]> = signal([]);
  constructor(
    private fb: FormBuilder,
    private cattleService: CattleService,
    private breedService: BreedService,
    private dialogRef: MatDialogRef<CattleFormComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: { mode: 'add' | 'edit'; cattle?: Cattle }
  ) {
    this.mode = data.mode;
  }

  ngOnInit(): void {
    this.initForm();
    this.getBreeds();
    if (this.mode === 'edit' && this.data.cattle) {
      this.cattleForm.patchValue({
        ...this.data.cattle,
      });
    }
  }

  initForm(): void {
    this.cattleForm = this.fb.group({
      breedId: ['', Validators.required],
      name: ['', Validators.required],
      earTag: ['', [Validators.required]],
    });
  }

  onSubmit(): void {
    if (this.cattleForm.valid) {
      const cattle: Cattle = this.cattleForm.value;
      const operation =
        this.mode === 'add'
          ? this.cattleService.addCattle(cattle)
          : this.cattleService.updateCattle(this.data.cattle?.id ?? 0, cattle);

      operation.subscribe(() => {
        this.dialogRef.close(true);
      });
    }
  }

  onCancel(): void {
    this.dialogRef.close(false);
  }
  // get breeds
  getBreeds() {
    this.breedService.getAll().subscribe((breeds) => {
      this.breeds.set(breeds);
    });
  }
}
