import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from '../services/product.service';
import { SortBy, SortOrder } from '../models/sort.enum';

@Component({
  selector: 'app-product-main',
  standalone: true,
  templateUrl: './product-main.component.html',
  styleUrls: ['./product-main.component.css'],
  imports: [CommonModule]
})
export class ProductMainComponent implements OnInit {
  SortBy = SortBy;
  SortOrder = SortOrder;

  products: any[] = [];
  sortBy: SortBy = SortBy.Name;
  sortOrder: SortOrder = SortOrder.Asc;
  take: number = 5;
  skip: number = 0;

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getProducts(this.sortBy, this.sortOrder, this.take, this.skip).subscribe((data) => {
      this.products = data;
    });
  }

  sortProducts(sortBy: SortBy): void {
    this.sortBy = sortBy;
    this.loadProducts();
  }
}
