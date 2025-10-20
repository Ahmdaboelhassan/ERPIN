import {
  ChangeDetectionStrategy,
  Component,
  ElementRef,
  EventEmitter,
  HostListener,
  Output,
  ViewChild,
  viewChild,
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatAccordion, MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { TranslatePipe, TranslateService } from '@ngx-translate/core';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-nav',
  providers: [provideNativeDateAdapter()],
  imports: [
    MatButtonModule,
    MatExpansionModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    RouterLink,
    RouterLinkActive,
    TranslatePipe,
  ],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css',
})
export class NavComponent {
  accordion = viewChild.required(MatAccordion);
  isRTL = true;
  @ViewChild('nav', { static: true }) navbar: ElementRef;
  @ViewChild('toggleButton', { static: true }) toggleButton: ElementRef;
  @Output() navbarEvent = new EventEmitter<boolean>();

  isSubMenuOpen: { [key: string]: boolean } = {
    items: false,
    salesInvoice: false,
    salesReturn: false,
    purchaseInvoice: false,
    purchaseReturn: false,
  };
  constructor(
    private elementRef: ElementRef,
    private authService: AuthService,
    private translate: TranslateService
  ) {
    const currentLang = this.translate.getCurrentLang();
    this.isRTL = currentLang == 'ar';
  }

  @HostListener('document:click', ['$event'])
  handleOutsideClick(event: MouseEvent): void {
    const targetElement = event.target as HTMLElement;
    if (
      targetElement &&
      !this.elementRef.nativeElement.contains(targetElement)
    ) {
      if (
        !this.navbar.nativeElement.classList.contains('-translate-x-[102%]')
      ) {
        this.navbar.nativeElement.classList.add('-translate-x-[102%]');
      }
    }
  }

  toggleNavBar() {
    const rtlClass = 'translate-x-[102%]';
    const ltrClass = '-translate-x-[102%]';
    const hiddenClass = this.isRTL ? rtlClass : ltrClass;
    if (!this.navbar.nativeElement.classList.contains('lg:translate-x-0')) {
      this.navbar.nativeElement.classList.add('lg:translate-x-0');
      this.navbar.nativeElement.classList.remove(hiddenClass);
      this.toggleButton.nativeElement.classList.add('lg:hidden');
      this.navbarEvent.emit(true);
    } else {
      this.navbar.nativeElement.classList.toggle(hiddenClass);
    }
  }
  toggleSubMenu(key: string) {
    this.isSubMenuOpen[key] = !this.isSubMenuOpen[key];
  }

  hideNavBar() {
    const rtlClass = 'translate-x-[102%]';
    const ltrClass = '-translate-x-[102%]';
    const hiddenClass = this.isRTL ? rtlClass : ltrClass;
    this.navbar.nativeElement.classList.remove('lg:translate-x-0');
    this.navbar.nativeElement.classList.add(hiddenClass);
    this.toggleButton.nativeElement.classList.remove('lg:hidden');
    this.navbarEvent.emit(false);
  }

  LogOut() {
    this.authService.Logout();
  }
}
