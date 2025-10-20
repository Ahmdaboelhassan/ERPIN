import { Component, computed, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoadingService } from './Services/loading.service';
import { AuthService } from './Services/auth.service';
import { LoadingComponent } from './Components/loading/loading.component';
import { AuthComponent } from './Components/auth/auth.component';
import { NavComponent } from './Components/nav/nav.component';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  imports: [NavComponent, AuthComponent, LoadingComponent, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  user = computed(() => this.authService.user());
  isLoad = computed(() => this.loadingService.isLoad());

  constructor(
    private loadingService: LoadingService,
    private authService: AuthService,
    private translate: TranslateService
  ) {
    const currentLang = this.translate.getCurrentLang();
    document.dir = currentLang == 'ar' ? 'rtl' : 'ltr';
  }

  ngOnInit(): void {
    this.authService.AutoLogin();
    //this.authService.AutoRefreshToken();
  }

  handleNavbarDispaly(
    isDispaly: boolean,
    navBarHolder: HTMLElement,
    appBody: HTMLElement
  ) {
    if (isDispaly) {
      navBarHolder.classList.remove('lg:absolute');
      appBody.classList.add('lg:col-span-4');
    } else {
      navBarHolder.classList.add('lg:absolute');
      appBody.classList.remove('lg:col-span-4');
    }
  }
}
