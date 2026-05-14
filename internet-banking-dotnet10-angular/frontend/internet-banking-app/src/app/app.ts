import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SidebarComponent } from './shared/layout/sidebar-component/sidebar-component';
import { NavbarComponent } from './shared/layout/navbar-component/navbar-component';
import { PagesModule } from './pages/pages-module';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    SidebarComponent,
    NavbarComponent,
    PagesModule
  ],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('internet-banking-app');
}
