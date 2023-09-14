import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop/shop.service';
import { Product } from './shared/models/product';
import { Category } from './shared/models/category';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'client';

  constructor(){}

  ngOnInit(): void {

  }

}