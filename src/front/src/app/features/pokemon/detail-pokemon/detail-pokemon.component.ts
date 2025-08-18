import { Component, Input, OnInit } from '@angular/core';
import { Pokemon } from '../../../datas/models/pokemon';
import { POKEMONS } from '../../../datas/mocks/mock-pokemon-list';
import { Router } from '@angular/router';

@Component({
  selector: 'app-detail-pokemon',
  templateUrl: './detail-pokemon.component.html'
})
export class DetailPokemonComponent implements OnInit {

  @Input('id') pokemonId!: string;

  pokemonList: Pokemon[];
  pokemon: Pokemon|undefined;

  constructor(private router: Router) { }

  ngOnInit() {
    this.pokemonList = POKEMONS;

    if (this.pokemonId) {
      this.pokemon = this.pokemonList.find(pokemon => pokemon.id == +this.pokemonId)
    } 

  }

  public goToPokemonList() {
    this.router.navigate(['/pokemon']);
  }

}
