using FluentValidation;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SimplyRugbyApp.Validators
{
    public class PlayerDetailsValidator : AbstractValidator<PlayerDetails>  //PlayerDetailsValidator inherits class AbstractValidator with PlayerDetails class
    {
        #region constructor
        public PlayerDetailsValidator()
        {
            CascadeMode = CascadeMode.Stop; //stop calidate on first faliure

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} empty!")
                .Must(OnlyLetters).WithMessage("{PropertyName} must contains only letters!")
                .Length(2, 50).WithMessage("{PropertyName} lenght must be min: 2 and max: 50 characters!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("{PropertyName} empty!")
                .Must(OnlyLetters).WithMessage("{PropertyName} must contains only letters!")
                .Length(2, 50).WithMessage("{PropertyName} lenght must be min: 2 and max: 50 characters!");

            RuleFor(x => x.DOB)
                .NotEmpty().WithMessage("{PropertyName} empty!")
                .Must(BeAValidDOB).WithMessage("{PropertyName} invalid!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} empty!")
                .Must(BeAValidEmail).WithMessage("{PropertyName} invalid!");


            RuleFor(x => x.Mobile)
                .NotEmpty().WithMessage("{PropertyName} empty!")
                .Length(11).WithMessage("{PropertyName} length must be 11 digits!")
                .Must(BeAValidMobile).WithMessage("{PropertyName} must be numeric!");

            RuleFor(x => x.ParentalConsent)
                .Must(OnlyLetters).WithMessage("{PropertyName} must contains only letters!");

        }
        #endregion

        #region methods
        private static bool BeAValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            bool blnValidEmail;
            Regex regEmail = new Regex(pattern);

            blnValidEmail = regEmail.IsMatch(email);

            return blnValidEmail;
        }

        private static bool BeAValidDOB(string dob)
        {
            string pattern = @"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$";
            bool blnValidDOB;
            Regex regDOB = new Regex(pattern);

            blnValidDOB = regDOB.IsMatch(dob);

            return blnValidDOB;
        }

        private static bool BeAValidMobile(string mobile)
        {
            string pattern = @"^\d{11}$";
            bool blnValidMobile;
            Regex regMobile = new Regex(pattern);

            blnValidMobile = regMobile.IsMatch(mobile);

            return blnValidMobile;
        }

        private static bool OnlyLetters(string input)
        {
            return input.All(Char.IsLetter);
        }
        #endregion
    }
}
