import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sideview } from './sideview/sideview';
import { Header } from './header/header';

@Component({
  selector: 'app-root',
  imports: [Sideview,Header],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  
}
