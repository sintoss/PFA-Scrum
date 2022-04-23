import { Sprint } from "./sprint.model";
import { Story } from "./story.model";

export class SprintStory {
    storyId!: number;
    story!: Story;
    sprintId!: number;
    sprint!: Sprint;
}