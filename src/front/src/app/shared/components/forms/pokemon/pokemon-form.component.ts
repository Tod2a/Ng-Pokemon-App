import { Component, Input, OnInit } from '@angular/core';
import { PokemonService } from '../../../../core/services/pokemon.service';
import { Pokemon } from '../../../../datas/models/pokemon';
import { PokemonType } from '../../../../datas/enums/pokemon-types.enum';
import { Router } from '@angular/router';
import { SHARED_IMPORTS } from '../../../imports';
import { PokemonTypeColorPipe } from '../../../pipes/pokemon-type-color.pipe';

@Component({
  selector: 'app-pokemon-form',
  standalone: true,
  imports: [
    SHARED_IMPORTS,
    PokemonTypeColorPipe
  ],
  templateUrl: './pokemon-form.component.html',
  styleUrls: ['./pokemon-form.component.css']
})
export class PokemonFormComponent implements OnInit {

  @Input() pokemon: Pokemon;
  types: string[];

  constructor(
    private pokemonService: PokemonService,
    private router: Router
  ) { }

  ngOnInit() {
    this.types = this.pokemonService.getPokemonTypeList();
  }

  hasType(type: string): boolean {
    return this.pokemon.types.includes(type as PokemonType);
  }

  selectType(isChecked: boolean, type: string) {
    if (isChecked) {
      this.pokemon.types.push(type as PokemonType);
    } else {
      const index = this.pokemon.types.indexOf(type as PokemonType);
      if (index !== -1) {
        this.pokemon.types.splice(index, 1);
      }
    }
  }

  isTypeValid(type: string): boolean {
    return (this.pokemon.types.length > 1 && !this.hasType(type)) || (this.pokemon.types.length === 1 && this.hasType(type));
  }

  onSubmit() {
    console.log('Form submitted:', this.pokemon);
    this.router.navigate(['/pokemon', this.pokemon.id]);
  }

}
