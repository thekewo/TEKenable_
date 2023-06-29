import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../shared/models/user';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  title = 'app';
  angForm!: FormGroup;
  isEmailDuplicate!: boolean;
  isSubmitted!: boolean;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
  ) {
    this.createForm();
    this.isEmailDuplicate = false;
    this.isSubmitted = false;
  }

  createForm() {
    this.angForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      contactSource: ['', Validators.required],
      contactReason: ['', Validators.required]
    });
  }

  submitNewsletter(data: { value: { email: string; contactSource: string; contactReason: string; }; }) {
    var user = new User();
    user.email = data.value.email;
    user.contactSource = data.value.contactSource;
    user.contactReason = data.value.contactReason;

    this.userService.isEmailInDatabase(user.email).subscribe(result => {
      this.isEmailDuplicate = result.result;
    }, error => {
      console.error(error);
    });

    if (!this.isEmailDuplicate) {
      this.userService.submitNewsletter(user).subscribe(result => {
      }, error => {
        console.error(error);
        return false;
      });
    }

    this.isSubmitted = true;
  }
}
