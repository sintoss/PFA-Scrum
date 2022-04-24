import { Story } from './story.model';
import { Utilisateur } from './utilisateur.model'
export class DeveloppeurStory
{
    storyId!: number;
    story!: Story;
    developpeurId!: number;
    developpeur!: Utilisateur;
}