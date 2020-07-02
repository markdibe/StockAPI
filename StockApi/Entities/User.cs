﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StockApi.Entities
{
    public class User
    {
        private string userId;
        public string UserId 
        {
            get
            {
                return userId;
            }
            set
            {
                userId = Guid.NewGuid().ToString() + Environment.OSVersion.ToString();
            }
        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string EncriptionKey { get; set; }
    }
}
