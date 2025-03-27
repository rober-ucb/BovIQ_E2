export interface HerdResponse {
  id: number;
  name: string;
  numberOfCows: number;
}

export interface CreateHerdRequest {
  name: string;
  ownerId: string;
}

export interface UpdateHerdRequest {
  name: string;
  ownerId: string;
}
