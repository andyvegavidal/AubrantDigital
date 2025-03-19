import { Component } from '@angular/core';
import { ProductMainComponent } from './product-main/product-main.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [ProductMainComponent, FormsModule]
})
export class AppComponent {
  title = 'inventory-app';
}
