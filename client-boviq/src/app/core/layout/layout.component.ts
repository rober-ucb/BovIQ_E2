import { Component } from '@angular/core';
import { NavigationComponent } from "./components/navigation/navigation.component";

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [NavigationComponent],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {

}
