import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ChatComponent } from './chat/chat.component';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    title: 'Neshgogo Chat APP - Login'
  },
  {
    path: 'chats',
    component: ChatComponent,
    title: 'Neshgogo Chat APP - Chats'
  },
];
