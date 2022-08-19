import { Validators } from "angular-reactive-validation";
import { emailValidator, whiteSpaceHtmlValidator, whiteSpaceValidator } from "@shared/custom-validators";

export const SettingsValidator = {
    aboutUs: [
        whiteSpaceHtmlValidator(`Value should not be a white spaces`)

    ],
    emailService: [
        whiteSpaceValidator(`Value should not be a white spaces`),
        Validators.minLength(3, minLength => `The minimum length is ${minLength}`),
        Validators.maxLength(100, maxLength => `Maximum length is ${maxLength}`),
        emailValidator(`Email is not valid`),
    ],
    numberService: [
        whiteSpaceHtmlValidator(`Value should not be a white spaces`),
    ],
    workWithUsDescription: [
        whiteSpaceHtmlValidator(`work With Us Description should not be a white spaces`),
    ],
    privateDiningDescription: [
        whiteSpaceHtmlValidator(`work With Us Description should not be a white spaces`),
    ],
    document: [
    ],
};
