using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Extensions
{
    public static class SnackbarExtension
    {
        public static ISnackbar Report(this ISnackbar snackbar, bool? result, string action)
        {
            if (result == true)
            {
                snackbar.Add("Successfully " + action, Severity.Success);
            }
            else
            {
                snackbar.Add("Error " + action, Severity.Error);
            }
            return snackbar;
        }
    }
}
