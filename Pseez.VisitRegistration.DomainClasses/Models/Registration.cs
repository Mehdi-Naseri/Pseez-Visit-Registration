﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.VisitRegistration.DomainClasses.Models
{
    [Table("Registration", Schema = "Registration")]
    public class Registration
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string IPECUsername { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string TelephoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Mobile { get; set; }

        public string FaxNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyPhone { get; set; }

        [Required]
        public string CompanyAddress { get; set; }

        [Required]
        public DateTime RegistrationDateTime { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
