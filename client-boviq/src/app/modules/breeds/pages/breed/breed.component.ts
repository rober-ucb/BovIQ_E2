import {
  Component,
  inject,
  OnInit,
  signal,
  WritableSignal,
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BreedResponse } from '@app/core/models/breeds/breed';
import { GridComponent } from '@app/shared/components/grid/grid.component';
import { BreedService } from '../../services/breed.service';
import { MatDialog } from '@angular/material/dialog';
import { BreedFormDialogComponent } from '../../components/breed-form-dialog/breed-form-dialog.component';
import { AutoDestroyService } from '@app/core/common/auto-destroy.service';
import { takeUntil } from 'rxjs';

@Component({
  selector: 'app-breed',
  standalone: true,
  imports: [MatToolbarModule, MatButtonModule, GridComponent],
  providers: [AutoDestroyService],
  templateUrl: './breed.component.html',
  styleUrl: './breed.component.css',
})
export class BreedComponent implements OnInit {
  constructor(
    private readonly breedService: BreedService,
    private readonly destroy$: AutoDestroyService
  ) {}

  displayedColumns: string[] = ['id', 'name', 'description', 'options'];
  $dataSource: WritableSignal<BreedResponse[]> = signal([]);
  formDialog = BreedFormDialogComponent;
  readonly dialog = inject(MatDialog);

  ngOnInit(): void {
    this.getData();
  }
  register() {
    this.dialog.open(BreedFormDialogComponent);
    this.dialog.afterAllClosed.subscribe((result:any) => {
      console.log(result);
      this.getData();
    });
  }
  getData(): void {
    this.breedService
      .getAll()
      .pipe(takeUntil(this.destroy$))
      .subscribe((data: BreedResponse[]) => {
        this.$dataSource.set(data);
        console.log(data);
      });
  }
}
