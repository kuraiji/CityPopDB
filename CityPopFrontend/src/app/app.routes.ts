import { Routes } from '@angular/router';
import { LandingComponent } from "./pages/landing/landing.component";
import { ArtistsComponent } from "./pages/artists/artists.component";
import { AlbumsComponent } from "./pages/albums/albums.component";

export const routes: Routes = [
  {
    path: '',
    component: LandingComponent,
    title: 'Landing Page'
  },
  {
    path: 'artists',
    component: ArtistsComponent,
    title: 'Artists Page'
  },
  {
    path: 'albums',
    component: AlbumsComponent,
    title: 'Albums Page'
  }
];
