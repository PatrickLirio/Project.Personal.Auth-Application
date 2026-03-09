import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { faUser, faLock, faEye, faEyeSlash } from '@fortawesome/free-solid-svg-icons';
import { faGoogle, faGithub, faDiscord } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FontAwesomeModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  faUser = faUser;
  faLock = faLock;
  faEye = faEye;
  faEyeSlash = faEyeSlash;

  faGoogle = faGoogle;
  faGithub = faGithub;
  faDiscord = faDiscord;

  isPasswordVisible = false;
  statusText = 'System Ready';

  togglePassword() {
    this.isPasswordVisible = !this.isPasswordVisible;
  }

  onSubmit(event: Event) {
    event.preventDefault();

    this.statusText = 'Authenticating...';

    setTimeout(() => {
      this.statusText = 'Access Granted';

      setTimeout(() => {
        this.statusText = 'System Ready';
      }, 2000);
    }, 1500);
  }
}
