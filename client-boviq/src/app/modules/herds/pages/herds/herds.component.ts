import {
  Component,
  inject,
  OnInit,
  signal,
  WritableSignal,
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { GridComponent } from '../../../../shared/components/grid/grid.component';
import { HerdResponse } from '@app/core/models/herds/herd';
import { HerdEditDialogComponent } from '../../components/herd-edit-dialog/herd.edit.dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { AddHerdDialogComponent } from '../../components/add-herd-dialog/add-herd-dialog.component';
import { HerdService } from '../../services/herd.service';

@Component({
  selector: 'app-herds',
  standalone: true,
  imports: [MatToolbarModule, MatButtonModule, MatIconModule, GridComponent],
  templateUrl: './herds.component.html',
  styleUrl: './herds.component.css',
})
export class HerdsComponent implements OnInit {
  constructor(private readonly herdService: HerdService) {}
  ngOnInit(): void {
    this.getHerds();
  }

  readonly dialog = inject(MatDialog);
  displayedColumns: string[] = ['id', 'name', 'numberOfCows', 'options'];
  $dataSource: WritableSignal<HerdResponse[]> = signal([]);
  editDialogComponent = HerdEditDialogComponent;

  register(): void {
    this.dialog.open(AddHerdDialogComponent);
  }

  getHerds(): void {
    this.herdService.getAll().subscribe((herds: HerdResponse[]) => {
      this.$dataSource.set(herds);
      console.log(herds);
    });
  }
}
