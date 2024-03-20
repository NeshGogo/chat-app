import { Component, input } from '@angular/core';

@Component({
  selector: 'app-avatar',
  standalone: true,
  imports: [],
  template: `
  <div class="bg-primary">
    <h1>{{initials()}}</h1>
  </div>`,
  styles: `
    div {
      max-height: 35px;
      max-width: 35px;
      padding: 5px;
      border-radius: 100%;
      text-align: center;
      h1 {
        line-height: 1.5;
        color: white;
        text-transform: uppercase;
      }
    }
  `,
})
export class AvatarComponent {
  initials = input<string>();
}
