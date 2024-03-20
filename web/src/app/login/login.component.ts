import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatCardModule, MatButtonModule],
  template: `
    <div class="background-container">
      <mat-card class="welcome-card">
        <mat-card-header>
          <mat-card-title>Neshgogo Chat APP</mat-card-title>
          <mat-card-subtitle>Connect Seamlessly</mat-card-subtitle>
        </mat-card-header>
        <mat-card-content>
          <p>Stay connected with friends, family, and colleagues effortlessly. Our chat app provides a convenient and intuitive platform for real-time communication.</p>
        </mat-card-content>
        <mat-card-actions>
          <a mat-raised-button color="primary" href="http://localhost:5000/api/accounts/signin-google">Start Chatting</a>
        </mat-card-actions>
      </mat-card>
    </div>
  `,
  styleUrl: './login.component.scss',
})
export class LoginComponent {

}
