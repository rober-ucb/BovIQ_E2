import { Component, input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-grid',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatIconModule,
    MatButtonModule,
  ],
  templateUrl: './grid.component.html',
  styleUrl: './grid.component.css',
})
export class GridComponent<T> implements OnInit, OnChanges  {
  constructor(private readonly dialog: MatDialog) {}
  editDialog = input<any>(); // Component to use for edit dialog
  deleteDialog = input<any>(); // Component to use for delete dialog
  ngOnInit(): void {
    this.dataSource.data = this.data();
  }
  displayedColumns = input.required<string[]>();
  data = input.required<T[]>();

  dataSource = new MatTableDataSource<T>();
  edit(element: T) {
    if (this.editDialog()) {
      this.dialog.open(this.editDialog(), {
        data: element,
      });
    }
  }

  delete(element: T) {
    if (this.deleteDialog()) {
      this.dialog.open(this.deleteDialog(), {
        data: element,
      });
    }
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['data']) {
      this.updateDataSource();
    }
  }

  private updateDataSource(): void {
    this.dataSource.data = this.data();
    console.log('Updated dataSource:', this.dataSource.data);
  }
}
