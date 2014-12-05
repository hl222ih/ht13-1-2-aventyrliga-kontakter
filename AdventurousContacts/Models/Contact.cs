using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdventurousContacts.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {

        public class Contact_Metadata
        {
            [Required(ErrorMessage="Förnamn måste anges.")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Förnamnet innehåller för få eller för många tecken.")]
            [DisplayName("Förnamn")]
            
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Efternamn måste anges.")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Förnamnet innehåller för få eller för många tecken.")]
            [DisplayName("Efternamn")]

            public string LastName { get; set; }
            [Required(ErrorMessage = "E-postadress måste anges.")]
            [EmailAddress(ErrorMessage = "E-postadressen är inte giltig.")]
            [DisplayName("E-postadress")]
            public string EmailAddress { get; set; }
        }
    }
}