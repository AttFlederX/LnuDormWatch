﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDW.WebAPI.Models
{
    public class UpdateUserApiModel
    {
        public string PhotoUrl { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CompressedPhotoUrl { get; set; }
    }
}
