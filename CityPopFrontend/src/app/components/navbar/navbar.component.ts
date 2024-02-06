import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatAnchor, MatMiniFabButton } from "@angular/material/button";
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { RouterModule } from "@angular/router";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatToolbarModule, MatAnchor, MatIconModule, MatMiniFabButton, MatMenuModule, RouterModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

}
