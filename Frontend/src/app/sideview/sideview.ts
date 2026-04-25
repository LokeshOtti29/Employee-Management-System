import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-sideview',
  imports: [CommonModule],
  templateUrl: './sideview.html',
  styleUrl: './sideview.css',
})
export class Sideview {
 items = ['Dashboard','My Profile','Employees','Departments','Leaves','Payroll']
}
