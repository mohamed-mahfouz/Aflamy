using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // to use ValidationAttribute

namespace Aflame.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        // we use this method cuz give access other property of Model(Customer) through(ValidationContext) and this what we need..
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
            var customer = (Customer)validationContext.ObjectInstance; // ObjectInstance Give us access to containing class(Customer), you must cast it to Model
                                                                       // which you want to make on it your custom validation  
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo ||
                customer.MembershipTypeId == MembershipType.Unknown) 
                return ValidationResult.Success; //Success is static field in class validationResult 
            if (customer.BD == null)
                return new ValidationResult("Brith Date is Required"); // Message if it's empty..
          
            var age = DateTime.Now.Year - customer.BD.Value.Year; // this way calc age of customer according to entered BD..
                                                                  // We use value => cuz BD nullable property..                  
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on 18");
        }

    }
}