import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sideview } from './sideview/sideview';
import { Header } from './header/header';
import { Contentpanel } from './contentpanel/contentpanel';

@Component({
  selector: 'app-root',
  imports: [Sideview,Header,Contentpanel],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  
}
