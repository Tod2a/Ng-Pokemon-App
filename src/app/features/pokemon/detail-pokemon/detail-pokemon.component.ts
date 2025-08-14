import { Component, Input, OnInit } from '@angular/core';
import { Pokemon } from '../../../datas/models/pokemon';
import { POKEMONS } from '../../../datas/mocks/mock-pokemon-list';
import { CommonModule } from '@angular/common';
import { PokemonTypeColorPipe } from '../../../shared/pipes/pokemon-type-color.pipe';

@Component({
  selector: 'app-detail-pokemon',
  standalone: true,
  imports: [CommonModule, PokemonTypeColorPipe],
  templateUrl: './detail-pokemon.component.html'
})
export class DetailPokemonComponent implements OnInit {

  @Input('id') pokemonId!: string;

  pokemonList: Pokemon[];
  pokemon: Pokemon|undefined;

  constructor() { }

  ngOnInit() {
    this.pokemonList = POKEMONS;

    if (this.pokemonId) {
      this.pokemon = this.pokemonList.find(pokemon => pokemon.id == +this.pokemonId)
    } 

  }

}
