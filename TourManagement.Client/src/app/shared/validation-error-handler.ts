import { FormGroup } from "@angular/forms";

export class ValidationErrorHandler {

    static handleValidationErrors(form: FormGroup, validationResult: any): void {
        for (var property in validationResult) {
          if (validationResult.hasOwnProperty(property)) {

            if (form.controls[property]) {
              // single field
              let validationErrorsForFormField = {};
              for (let validationError of validationResult[property]) {
                validationErrorsForFormField[validationError.validatorKey] = true;
              }
              form.controls[property].setErrors(validationErrorsForFormField);
            } else {
              // cross field
              let validationErrorsForForm = {};
              for (let validationError of validationResult[property]) {
                validationErrorsForForm[validationError.validatorKey] = true;
              }
              form.setErrors(validationErrorsForForm);
            }
          }
        }
      }
}
