using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactWebAPI
{
    public class Contact 
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can not be exceed 50 charecter")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last name can not be exceed 50 charecter")]
        public string LastName { get; set; }


        [MaxLength(200, ErrorMessage = "Address can not be exceed 200 charecter")]
        public string ContactAddress { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public bool ContactStatus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
