import { NgModule } from '@angular/core';
import { ListPokemonComponent } from './list-pokemon/list-pokemon.component';
import { DetailPokemonComponent } from './detail-pokemon/detail-pokemon.component';
import { PokemonTypeColorPipe } from '../../shared/pipes/pokemon-type-color.pipe';
import { SHARED_IMPORTS } from '../../shared/imports';
import { BorderCardDirective } from '../../shared/directives/border-card.directive';
import { Routes } from '@angular/router';
import { PokemonFormComponent } from '../../shared/components/forms/pokemon/pokemon-form.component';
import { EditPokemonComponent } from './edit-pokemon/edit-pokemon.component';

export const pokemonRoutes: Routes = [
    { path: 'pokemon', component: ListPokemonComponent },
    { path: 'pokemon/edit/:id', component: EditPokemonComponent },
    { path: 'pokemon/:id', component: DetailPokemonComponent },
];

@NgModule({
  declarations: [
    ListPokemonComponent,
    DetailPokemonComponent,
    EditPokemonComponent
  ],
  imports: [
    PokemonTypeColorPipe,
    SHARED_IMPORTS,
    BorderCardDirective,
    PokemonFormComponent
  ]
})
export class PokemonModule { }
