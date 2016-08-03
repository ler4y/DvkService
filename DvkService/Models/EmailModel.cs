using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvkService.Models
{
    public class EmailModel
    {
        [Required, Display(Name = "Ваше имя")]
        public string FromName { get; set; }
        [Required, Display(Name = "Ваш email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Ваш телефон"), Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Message { get; set; }
    }
}