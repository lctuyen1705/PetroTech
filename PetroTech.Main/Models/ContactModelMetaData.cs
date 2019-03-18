using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetroTech.Main.Models
{
    [MetadataType(typeof(ContactModelMetaData))]
    public partial class ContactModel
    {
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string Message { get; set; }
    }

    public class ContactModelMetaData
    {
        [Required(ErrorMessageResourceName = "RequiredField",
        ErrorMessageResourceType = typeof(RGlobal))]
        [Display(Name = "ContactName", ResourceType = typeof(RHome))]
        public string ContactName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField",
        ErrorMessageResourceType = typeof(RGlobal))]
        [Display(Name = "ContactEmail", ResourceType = typeof(RHome))]
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField",
        ErrorMessageResourceType = typeof(RGlobal))]
        [Display(Name = "Message", ResourceType = typeof(RHome))]
        public string Message { get; set; }
    }
}