﻿using System.ComponentModel.DataAnnotations;

namespace CRUDUsingMVCwithAdoDotNet.git.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}