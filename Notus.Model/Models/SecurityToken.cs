﻿using System;

namespace Notus.Model.Models
{
    public class SecurityToken
    {
        public int SecurityTokenId { get; set; }

        public Guid Token { get; set; }

        public int ActualID { get; set; }
    }
}