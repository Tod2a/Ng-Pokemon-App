import { Component, Input, OnInit } from '@angular/core';
import { Pokemon } from '../../../datas/models/pokemon';
import { Router } from '@angular/router';
import { PokemonService } from '../../../core/services/pokemon.service';

@Component({
  selector: 'app-detail-pokemon',
  templateUrl: './detail-pokemon.component.html'
})
export class DetailPokemonComponent implements OnInit {

  @Input('id') pokemonId!: string;

  pokemon: Pokemon|undefined;

  constructor(
    private router: Router,
    private pokemonService: PokemonService
  ) { }

  ngOnInit() {
    if (this.pokemonId) {
      this.pokemon = this.pokemonService.getPokemonById(+this.pokemonId);
    }
  }

  public goToPokemonList() {
    this.router.navigate(['/pokemon']);
  }

  public goToEditPokemon() {
    if (this.pokemon) {
      this.router.navigate(['/pokemon/edit', this.pokemon.id]);
    }
  }

}
