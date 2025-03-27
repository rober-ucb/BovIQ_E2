import { Component } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Breed } from '@app/core/models/breeds/breed';
import { BreedService } from '../../services/breed.service';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { BreedFormDialogComponent } from '../breed-form-dialog/breed-form-dialog.component';

@Component({
  selector: 'app-breed-list',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatButton,
    MatTableModule,
    CommonModule,
  ],
  templateUrl: './breed-list.component.html',
  styleUrl: './breed-list.component.css',
})
export class BreedListComponent {
  displayedColumns: string[] = ['id', 'name', 'description', 'actions'];
  dataSource = new MatTableDataSource<Breed>();

  constructor(
    private breedService: BreedService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadBreeds();
  }

  loadBreeds(): void {
    this.breedService.getAll().subscribe((breeds) => {
      this.dataSource.data = breeds;
    });
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(BreedFormDialogComponent, {
      width: '600px',
      data: { mode: 'add' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.loadBreeds();
        this.snackBar.open('Breed added successfully!', 'Close', {
          duration: 3000,
        });
      }
    });
  }

  openEditDialog(breed: Breed): void {
    const dialogRef = this.dialog.open(BreedFormDialogComponent, {
      width: '600px',
      data: { mode: 'edit', breed },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.loadBreeds();
        this.snackBar.open('Breed updated successfully!', 'Close', {
          duration: 3000,
        });
      }
    });
  }

  deleteBreed(id: number): void {
    if (confirm('Are you sure you want to delete this breed record?')) {
      this.breedService.deleteB(id).subscribe((success) => {
        this.loadBreeds();
        console.log(success);
        if (success) {
          this.loadBreeds();
          this.snackBar.open('Breed deleted successfully!', 'Close', {
            duration: 3000,
          });
        }
      });
    }
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
