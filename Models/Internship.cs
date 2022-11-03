using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace YazGel.Models
{
    public class Internship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TC { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Start { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string End { get; set; }
        public bool SSK { get; set; }
        public bool GSS { get; set; }
        public bool Age { get; set; }
        public bool Gov { get; set; }

        public string ComName { get; set; }
        public string ComBuss { get; set; }
        public string ComAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ComPhoneNumber { get; set; }
        public string ComMail { get; set; }
        public string ComAdmin { get; set; }

        public virtual ICollection<Documents> DocumentId { get; set; }


    }
}
