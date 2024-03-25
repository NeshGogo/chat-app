import { Component, signal } from '@angular/core';
import { LayoutComponent } from '../layout/layout.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { UserTitleComponent } from '../components/user-title/user-title.component';


@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [LayoutComponent, MatToolbarModule, MatIconModule, MatButtonModule, UserTitleComponent, MatDividerModule, ],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.scss'
})
export class ChatComponent {
  toolBarTitle = signal('Your chats')
}
