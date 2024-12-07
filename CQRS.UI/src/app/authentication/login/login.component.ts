import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormGroupDirective,
  NgForm,
  Validators,
} from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { LoginUser } from '../../models/loginUser';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { ChangeDetectionStrategy, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { merge } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    ReactiveFormsModule,
    MatButtonModule,
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage = signal('');

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.pattern(
            /^(?=.*[A-Z])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]+$/
          ),
          Validators.minLength(6),
        ],
      ],
    });
    merge(this.loginForm.statusChanges, this.loginForm.valueChanges)
      .pipe(takeUntilDestroyed())
      .subscribe(() => this.updateErrorMessage());
  }

  onSubmit(loginUser: LoginUser) {}

  updateErrorMessage() {
    const errorMessages = {
      emailRequired: 'Email is required',
      emailInvalid: 'Not a valid email',
      passwordRequired: 'Password is required',
      passwordMinLength: 'Password must be at least 6 characters long',
      passwordPattern:
        'Password must include at least one uppercase letter and one special character',
    } as const;

    if (this.loginForm.hasError('required', ['email'])) {
      this.errorMessage.set(errorMessages['emailRequired']);
      return;
    }
    if (this.loginForm.hasError('email', ['email'])) {
      this.errorMessage.set(errorMessages['emailInvalid']);
      return;
    }
    const passwordControl = this.loginForm.get('password');
    if (passwordControl?.hasError('required')) {
      this.errorMessage.set(errorMessages['passwordRequired']);
      return;
    }
    if (passwordControl?.hasError('minlength')) {
      this.errorMessage.set(errorMessages['passwordMinLength']);
      return;
    }
    if (passwordControl?.hasError('pattern')) {
      this.errorMessage.set(errorMessages['passwordPattern']);
      return;
    }
    this.errorMessage.set('');
  }
}
