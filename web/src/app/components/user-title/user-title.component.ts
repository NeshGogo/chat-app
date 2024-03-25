import { Component, input } from '@angular/core';
import { AvatarComponent } from '../avatar/avatar.component';

@Component({
  selector: 'app-user-title',
  standalone: true,
  imports: [AvatarComponent],
  template: `
    <app-avatar [initials]="initials"></app-avatar>
    <h3>{{name()}}</h3>
  `,
  styles: `
    :host{
      display: flex;
      align-items: center;
      h3{
        margin: 0;
        margin-left:5px;
        font-weight: 500;
      }
    }
  `
})
export class UserTitleComponent {
  name = input<string>('');
  
  public get initials() : string {
    return this.name().substring(0, 2);
  }
  
}
