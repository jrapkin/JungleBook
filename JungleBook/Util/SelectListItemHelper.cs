using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Util
{
    public static class SelectListItemHelper
    {
        public static IEnumerable<SelectListItem> GetInterests()
        {
            IList<SelectListItem> items = new List<SelectListItem>
                {
                    new SelectListItem() {Text="Hiking", Value="hiking"},
                    new SelectListItem() { Text="Camping", Value="camping"},
                    new SelectListItem() { Text="Food", Value="resturant"},
                    new SelectListItem() { Text="Beer", Value="brewery"},
                    new SelectListItem() { Text="Music", Value="music"}
                };
            return items;
        }
    }
}

