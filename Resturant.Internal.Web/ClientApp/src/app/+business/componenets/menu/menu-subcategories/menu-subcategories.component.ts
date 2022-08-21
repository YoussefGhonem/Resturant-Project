import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'menu-subcategories',
  templateUrl: './menu-subcategories.component.html',
  styleUrls: ['./menu-subcategories.component.scss']
})
export class MenuSubcategoriesComponent implements OnInit {
  @Input('subcategory') subcategory: any;
  constructor() { }

  ngOnInit(): void {
  }

}
