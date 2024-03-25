import { Component, input } from '@angular/core';
import { UserTitleComponent } from '../user-title/user-title.component';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-message',
  standalone: true,
  imports: [UserTitleComponent, MatCardModule],
  template: `
  <div>
    <app-user-title [name]="userName()"></app-user-title>
    <mat-card>
      <mat-card-content>{{content()}}</mat-card-content>
    </mat-card>
  </div>
  `,
})
export class MessageComponent {
  userName = input<string>('');
  content = input<string>('');
}
