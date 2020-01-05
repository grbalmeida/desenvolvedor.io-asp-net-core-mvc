using System;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DevIO.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormatsDocument(this RazorPage page, int supplierType, string document)
        {
            return supplierType == (int) SupplierType.NaturalPerson
                ? Convert.ToUInt64(document).ToString(@"000\.000\.000\-00")
                : Convert.ToUInt64(document).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
