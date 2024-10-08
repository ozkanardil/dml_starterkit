﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmlStarterkit.Application.Features.Auth.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public int RecoveryCode { get; set; }
        public int Status { get; set; }
        public string RefreshTokenA { get; set; }
        public DateTime RefreshTokenExpr { get; set; }
    }
}
