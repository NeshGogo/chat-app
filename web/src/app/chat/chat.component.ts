import { Component, signal } from '@angular/core';
import { LayoutComponent } from '../layout/layout.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { UserTitleComponent } from '../components/user-title/user-title.component';
import { MessageComponent } from '../components/message/message.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [
    LayoutComponent,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    UserTitleComponent,
    MatDividerModule,
    MessageComponent,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
  ],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.scss',
})
export class ChatComponent {
  toolBarTitle = signal('Your chats');
  chatOpen = signal(false);

  openChat(){
    this.chatOpen.set(true);
  }

  closeChat(){
    this.chatOpen.set(false);
  }
}
