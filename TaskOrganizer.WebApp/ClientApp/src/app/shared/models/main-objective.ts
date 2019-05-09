import { ChildObjective } from './child-objective';

export class MainObjective {
  id: number;
  title: string;
  description?: string;
  status: string;
  deadLine?: Date;
  childObjectives?: ChildObjective[];
}
