import { Component, Input, OnInit } from '@angular/core';
import { Pokemon } from '../../../datas/models/pokemon';
import { PokemonService } from '../../../core/services/pokemon.service';

@Component({
  selector: 'app-edit-pokemon',
  templateUrl: './edit-pokemon.component.html'
})
export class EditPokemonComponent implements OnInit {

  @Input('id') pokemonId!: string;
  pokemon: Pokemon|undefined;

  constructor(private pokemonService: PokemonService) { }

  ngOnInit() {
    if (this.pokemonId) {
      this.pokemon = this.pokemonService.getPokemonById(+this.pokemonId);
    }
  }

  // Additional methods for editing a Pokémon can be added here

}
 