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
  BreedResponse,
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
  form!: FormGroup;
  isEditMode = false;
  currentId: number | null = null;
  $submit: Subject<void> = new Subject<void>();

  private _breedData: BreedResponse | null = null;

  readonly dialogRef = inject(MatDialogRef<BreedFormDialogComponent>);

  constructor(
    private readonly fb: FormBuilder,
    private readonly breedService: BreedService,
    private readonly destroy$: AutoDestroyService,
    @Optional()
    @Inject(MAT_DIALOG_DATA)
    public dialogData: { element: BreedResponse }
  ) {
    if (this.dialogData?.element) {
      this._breedData = this.dialogData.element; // Store but don't process yet
    }
  }

  @Input()
  set breedData(breed: BreedResponse) {
    this._breedData = breed;
    this.updateFormIfInitialized();
  }

  get breedData(): BreedResponse | null {
    return this._breedData;
  }

  ngOnInit(): void {
    this.initForm();
    this.updateFormIfInitialized(); // Now form exists, we can patch values
    this.subscribeToSubmit();
  }

  private initForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  private updateFormIfInitialized() {
    if (this.form && this._breedData) {
      this.isEditMode = true;
      this.currentId = this._breedData.id;
      this.form.patchValue({
        name: this._breedData.name,
        description: this._breedData.description,
      });
    }
  }

  private subscribeToSubmit() {
    this.$submit
      .pipe(
        filter(() => this.form.valid),
        exhaustMap(() => {
          if (this.isEditMode && this.currentId) {
            const request: UpdateBreedRequest = this.form.value;
            return this.breedService.update(this.currentId, request).pipe(
              catchError((error) => {
                console.error('Update error:', error);
                return [];
              })
            );
          } else {
            const request: CreateBreedRequest = this.form.value;
            return this.breedService.add(request).pipe(
              catchError((error) => {
                console.error('Create error:', error);
                return [];
              })
            );
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe(() => {
        this.dialogRef.close(this.form.value); // Close the dialog and pass true to indicate success
      });
  }
}
