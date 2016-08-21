﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace JobManagement.WebMvc.Identity
{
    public static class IdentityExtensions
    {
        public static EFDataModel.Person GetPeople(this IIdentity identity)
        {
            EFDataModel.Person _result;
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            _result = DataAccessLayer.DBPeople.getPeopleByIdentityUserName(identity.Name);
            return _result;
        }
    }
}