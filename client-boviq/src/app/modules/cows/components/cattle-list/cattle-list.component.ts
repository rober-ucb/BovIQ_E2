import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Cattle } from '@app/core/models/cows/cow';
import { CattleService } from '../../services/cow.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { AsyncPipe, CommonModule } from '@angular/common';
import { CattleFormComponent } from '../cattle-form/cattle-form.component';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-cattle-list',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatButton,
    MatTableModule,
    CommonModule,
  ],
  templateUrl: './cattle-list.component.html',
  styleUrl: './cattle-list.component.css',
})
export class CattleListComponent {
  displayedColumns: string[] = ['earTag', 'name', 'breed', 'actions'];
  dataSource = new MatTableDataSource<Cattle>();

  constructor(
    private cattleService: CattleService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadCattle();
  }

  loadCattle(): void {
    this.cattleService.getCattleList().subscribe((cattle) => {
      this.dataSource.data = cattle;
    });
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(CattleFormComponent, {
      width: '600px',
      data: { mode: 'add' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.loadCattle();
        this.snackBar.open('Cattle added successfully!', 'Close', {
          duration: 3000,
        });
      }
    });
  }

  openEditDialog(cattle: Cattle): void {
    const dialogRef = this.dialog.open(CattleFormComponent, {
      width: '600px',
      data: { mode: 'edit', cattle },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.loadCattle();
        this.snackBar.open('Cattle updated successfully!', 'Close', {
          duration: 3000,
        });
      }
    });
  }

  deleteCattle(id: number): void {
    if (confirm('Are you sure you want to delete this cattle record?')) {
      this.cattleService.deleteCattle(id).subscribe((success) => {
        this.loadCattle();
        console.log(success);
        if (success) {
          this.loadCattle();
          this.snackBar.open('Cattle deleted successfully!', 'Close', {
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
