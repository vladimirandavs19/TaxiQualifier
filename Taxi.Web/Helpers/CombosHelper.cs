using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Common.Enums;

namespace Taxi.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboRoles()
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "[Select a role...]" },
                new SelectListItem { Value = ((int)UserType.Driver).ToString(), Text = UserType.Driver.ToString() },
                new SelectListItem { Value = ((int)UserType.User).ToString(), Text = UserType.User.ToString() }
            };

            return list;
        }
    }
}

