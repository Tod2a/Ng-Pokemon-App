import { Component } from '@angular/core';
import { NavbarComponent } from "./shared/components/navbar/navbar.component";
import { SHARED_IMPORTS } from './shared/imports';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [SHARED_IMPORTS, NavbarComponent],
  templateUrl: 'app.component.html'
})
export class AppComponent { }
