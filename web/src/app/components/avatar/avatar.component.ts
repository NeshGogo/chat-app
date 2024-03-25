import { Component, input } from '@angular/core';

@Component({
  selector: 'app-avatar',
  standalone: true,
  imports: [],
  template: `
  <div class="bg-primary">
    <h2>{{initials()}}</h2>
  </div>`,
  styles: `
    div {
      max-height: 35px;
      max-width: 35px;
      padding: 3px 6px;
      border-radius: 100%;
      text-align: center;
      h2 {
        line-height: 1.8;
        color: white;
        text-transform: uppercase;
      }
    }
  `,
})
export class AvatarComponent {
  initials = input<string>();
}
