import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CattleListComponent } from '../../components/cattle-list/cattle-list.component';

@Component({
  selector: 'app-cow',
  standalone: true,
  imports: [CattleListComponent],
  templateUrl: './cow.component.html',
  styleUrl: './cow.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CowComponent {
  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = [];
 }
