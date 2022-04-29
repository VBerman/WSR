using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Extensions
{
    public static class DialogServiceExtension
    {
        public static async Task<bool?> Warning(this IDialogService dialogService, string textWarning)
        {
            var result = await dialogService.ShowMessageBox(
                "Warning",
                textWarning,
                yesText: "Continue!",
                noText: "Cancel");
            return result;
        }
    }
}
