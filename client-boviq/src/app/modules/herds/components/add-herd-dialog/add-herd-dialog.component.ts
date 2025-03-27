import { Component, inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { catchError, exhaustMap, filter, Subject } from 'rxjs';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

import { HerdService } from '../../services/herd.service';
import { CreateHerdRequest } from '@app/core/models/herds/herd';

@Component({
  selector: 'app-add-herd-dialog',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
  ],
  templateUrl: './add-herd-dialog.component.html',
  styleUrl: './add-herd-dialog.component.css',
})
export class AddHerdDialogComponent implements OnInit {
  form!: FormGroup;
  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', Validators.required],
      ownerId: ['', Validators.required],
    });
    this.subscribeToSubmit();
  }

  constructor(
    private readonly fb: FormBuilder,
    private readonly herdService: HerdService
  ) {}
  $submit: Subject<void> = new Subject<void>();

  readonly dialogRef = inject(MatDialogRef<AddHerdDialogComponent>);

  private subscribeToSubmit() {
    this.$submit
      .pipe(
        filter(() => this.form.valid),
        exhaustMap(() => {
          const request: CreateHerdRequest = this.form.value;
          return this.herdService.addHerd(request).pipe(
            catchError((error) => {
              console.error(error);
              return [];
            })
          );
        })
      )
      .subscribe(() => {
        console.log(this.form.value);
        this.form.reset();
        this.dialogRef.close(this.form.value);
      });
  }
}
