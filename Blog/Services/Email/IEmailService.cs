﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Email
{
    public interface IEmailService
    {
        void Send(string from, string to, string subject, string html);
    }
}
