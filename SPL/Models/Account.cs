﻿using System;

namespace SPL.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string CompanyNameEnglish { get; set; }

    }
}
