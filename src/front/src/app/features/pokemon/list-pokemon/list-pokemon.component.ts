import { Component, OnInit } from '@angular/core';
import { Pokemon } from '../../../datas/models/pokemon';
import { Router } from '@angular/router';
import { PokemonService } from '../../../core/services/pokemon.service';

@Component({
  selector: 'app-list-pokemon',
  templateUrl: './list-pokemon.component.html',
})
export class ListPokemonComponent implements OnInit {
  pokemonList: Pokemon[];

  constructor(
    private router: Router,
    private pokemonService: PokemonService
  ) { }

  ngOnInit() {
    this.pokemonList = this.pokemonService.getPokemonList();
  }

  goToPokemon(pokemon: Pokemon) {
    this.router.navigate(['/pokemon', pokemon.id]);
  }
}
