export interface Breed {
  id: number;
  name: string;
  description: string;
}
export interface CreateBreedRequest {
  name: string;
  description: string;
}
export interface UpdateBreedRequest {
    name: string;
    description: string;
  }
  