import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListPokemonComponent } from './list-pokemon/list-pokemon.component';
import { DetailPokemonComponent } from './detail-pokemon/detail-pokemon.component';
import { PokemonTypeColorPipe } from '../../shared/pipes/pokemon-type-color.pipe';
import { SHARED_IMPORTS } from '../../shared/imports';
import { BorderCardDirective } from '../../shared/directives/border-card.directive';
import { Routes } from '@angular/router';

export const pokemonRoutes: Routes = [
    { path: 'pokemon', component: ListPokemonComponent },
    { path: 'pokemon/:id', component: DetailPokemonComponent },
];

@NgModule({
  declarations: [
    ListPokemonComponent,
    DetailPokemonComponent
  ],
  imports: [
    PokemonTypeColorPipe,
    SHARED_IMPORTS,
    BorderCardDirective
  ]
})
export class PokemonModule { }
