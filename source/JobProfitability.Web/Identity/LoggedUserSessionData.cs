﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Identity
{
    public class LoggedUserSessionData
    {
        public EFDataModel.AspNetUsers LoggedAspNetUser { get; set; }
        public EFDataModel.Person LoggedPeople { get; set; }

    }
}