import { Component, input } from '@angular/core';

@Component({
  selector: 'app-avatar',
  standalone: true,
  imports: [],
  template: `
  <div class="bg-primar">
    <h1>{{initials()}}</h1>
  </div>`,
  styles: `
    div {
      padding: 10px;
      border-radius: 100%;
      text-align: center;
      h1 {
        color: white;
        text-transform: uppercase;
      }
    }
  `,
})
export class AvatarComponent {
  initials = input<string>();
}
