import { Breed } from "../breeds/breed";

export interface Cattle {
  id: number;
  breedI: string;
  name: string;
  earTag: string;
  Breed: Breed;
}

export interface CreateCowRequest {
  breedI: string;
  name: string;
  earTag: string;
  firstCalvingDate: string;
  dateOfBirth: string;
}

export interface CreateCowRequest {
  breedI: string;
  name: string;
  earTag: string;
  firstCalvingDate: string;
  dateOfBirth: string;
}
