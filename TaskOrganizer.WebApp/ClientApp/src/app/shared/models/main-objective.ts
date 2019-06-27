import { ChildObjective } from './child-objective';

export class MainObjective {
  id: number;
  title: string;
  description?: string;
  status: number;
  deadline?: Date;
  childObjectives?: ChildObjective[];
}
