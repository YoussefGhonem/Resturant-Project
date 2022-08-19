import { Validators } from "angular-reactive-validation";
import { emailValidator, whiteSpaceValidator } from "@shared/custom-validators";

export const RegisterValidator = {
  userAccount: {
    firstName: [
      Validators.required('First name is required'),
      whiteSpaceValidator(`Value should not be a white spaces`),
      Validators.minLength(3, minLength => `The minimum length is ${minLength}`),
      Validators.maxLength(100, maxLength => `Maximum length is ${maxLength}`),
    ],
    lastName: [
      Validators.required('Last name is required'),
      whiteSpaceValidator(`Value should not be a white spaces`),
      Validators.minLength(3, minLength => `The minimum length is ${minLength}`),
      Validators.maxLength(100, maxLength => `Maximum length is ${maxLength}`),
    ],
    email: [
      Validators.required('Email is required'),
      whiteSpaceValidator(`Value should not be a white spaces`),
      Validators.minLength(3, minLength => `The minimum length is ${minLength}`),
      Validators.maxLength(100, maxLength => `Maximum length is ${maxLength}`),
      emailValidator(`Email is not valid`),
    ],
    password: [
      Validators.required('Password is required'),
      whiteSpaceValidator(`Value should not be a white spaces`),
      Validators.minLength(6, minLength => `The minimum length is ${minLength}`),
      Validators.maxLength(100, maxLength => `Maximum length is ${maxLength}`),
      Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$', 'Invalid Format: Lowercase letters, Uppercase letters, Numbers'),
      Validators.pattern('^(?=.*?[~`!@#$%^&*();\\\\:"+-/_<>.|^{},’،=?\']).{1,}$', 'Invalid Format: Special characters')
    ],
    confirmPassword: [
      Validators.required('Confirm Password is required'),
      whiteSpaceValidator(`Value should not be a white spaces`),
      Validators.minLength(6, minLength => `The minimum length is ${minLength}`),
      Validators.maxLength(100, maxLength => `Maximum length is ${maxLength}`),
    ],
    phoneNumber: [
      Validators.maxLength(20, maxLength => `Maximum length is ${maxLength}`),
      whiteSpaceValidator(`Value should not be a white spaces`),
    ],
  },

};
