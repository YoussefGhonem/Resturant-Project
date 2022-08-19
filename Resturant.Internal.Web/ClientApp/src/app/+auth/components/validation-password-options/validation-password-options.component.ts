import { Component, Input, OnInit } from '@angular/core';
import { ValidationPasswordOptions } from '@shared/default-values/validation-password-options';

@Component({
  selector: 'validation-password-options',
  templateUrl: './validation-password-options.component.html',
  styleUrls: ['./validation-password-options.component.scss']
})
export class ValidationPasswordOptionsComponent implements OnInit {
  constructor() { }
  passwordOptions = ValidationPasswordOptions;

  ngOnInit(): void {
    this.showOptuons()
    this.validationMessage()
  }

  validationMessage() {
    // Password Validation set
    var myInput = document.getElementById("password-input") as HTMLInputElement;
    var letter = document.getElementById("pass-lower");
    var capital = document.getElementById("pass-upper");
    var number = document.getElementById("pass-number");
    var length = document.getElementById("pass-length");
    var spceial = document.getElementById("pass-spceial");

    // When the user clicks on the password field, show the message box
    console.log("myInput", myInput);
    if (myInput != null) {
      myInput.onkeyup = function () {
        // Validate lowercase letters
        var lowerCaseLetters = /[a-z]/g;
        if (myInput.value.match(lowerCaseLetters)) {
          letter?.classList.remove("invalid");
          letter?.classList.add("valid");
        } else {
          letter?.classList.remove("valid");
          letter?.classList.add("invalid");
        }

        // Validate capital letters
        var upperCaseLetters = /[A-Z]/g;
        if (myInput.value.match(upperCaseLetters)) {
          capital?.classList.remove("invalid");
          capital?.classList.add("valid");
        } else {
          capital?.classList.remove("valid");
          capital?.classList.add("invalid");
        }

        // Validate capital spcial
        var spceialLetters = /[~`!@#$%^&*();\\\\:"+-/_<>.|^{},’،=?\\.-]/
        if (myInput.value.match(spceialLetters)) {
          spceial?.classList.remove("invalid");
          spceial?.classList.add("valid");
        } else {
          spceial?.classList.remove("valid");
          spceial?.classList.add("invalid");
        }

        // Validate numbers
        var numbers = /[0-9]/g;
        if (myInput.value.match(numbers)) {
          number?.classList.remove("invalid");
          number?.classList.add("valid");
        } else {
          number?.classList.remove("valid");
          number?.classList.add("invalid");
        }

        // Validate length
        if (myInput.value.length >= ValidationPasswordOptions.MinimumCharacters) {
          length?.classList.remove("invalid");
          length?.classList.add("valid");
        } else {
          length?.classList.remove("valid");
          length?.classList.add("invalid");
        }
      };

    }
    // When the user starts to type something inside the password field
  }

  showOptuons() {
    var lower = document.getElementById("pass-lower");
    var capital = document.getElementById("pass-upper");
    var number = document.getElementById("pass-number");
    var spceial = document.getElementById("pass-spceial");

    if (!ValidationPasswordOptions.RequireDigit) {
      let input = number as HTMLElement;
      input.style.display = "none"
    }
    if (!ValidationPasswordOptions.RequireLowercase) {
      let input = lower as HTMLElement;
      input.style.display = "none"
    }
    if (!ValidationPasswordOptions.RequireNonAlphanumeric) {
      let input = spceial as HTMLElement;
      input.style.display = "none"
    }
    if (!ValidationPasswordOptions.RequireUppercase) {
      let input = capital as HTMLElement;
      input.style.display = "none"
    }
  }
}
