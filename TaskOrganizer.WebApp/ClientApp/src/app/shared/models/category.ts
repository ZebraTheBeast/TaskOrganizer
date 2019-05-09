import { MainObjective } from './main-objective';

export class Category {
  id: number;
  title: string;
  description?: string;
  mainObjectives?: MainObjective[];
}
