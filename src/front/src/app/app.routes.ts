import { Routes } from '@angular/router';
import { PageNotFoundComponent } from './features/errors/page-not-found/page-not-found.component';
import { pokemonRoutes } from './features/pokemon/pokemon.module';

export const routes: Routes = [
    ...pokemonRoutes,
    { path: '', redirectTo: 'pokemon', pathMatch: 'full'},
    { path: '**', component: PageNotFoundComponent}
];
