import { PokemonType } from "../enums/pokemon-types.enum";

export class Pokemon {
    id: number;
    hp: number;
    cp: number;
    name: string;
    picture: string;
    types: Array<PokemonType>;
    created: Date;
}