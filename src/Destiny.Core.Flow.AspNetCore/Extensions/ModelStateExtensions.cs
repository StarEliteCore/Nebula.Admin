using Destiny.Core.Flow.AspNetCore.Mvc.Filters;
using Destiny.Core.Flow.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Destiny.Core.Flow.AspNetCore.Extensions
{
    //public static class MvcOptionsExtensions
    //{
    //    public static MvcOptions UseExceptionHandling(this MvcOptions options)
    //    {
    //        options.Filters.Add<HandleException>();
    //        return options;
    //    }
    //}

    //public static class ModelStateExtensions
    //{
    //    public static IDictionary<string, string[]> ToSerializableDictionary(this ModelStateDictionary modelState)
    //    {
    //        return modelState.Where(x => x.Value.Errors.Any()).ToDictionary(
    //            kvp => kvp.Key,
    //            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
    //        );
    //    }

    //    public static string ExportErrors(this ModelStateDictionary modelState, bool useHtmlNewLine = false)
    //    {
    //        var builder = new StringBuilder();

    //        foreach (var error in modelState.Values.SelectMany(a => a.Errors))
    //        {
    //            var message = error.ErrorMessage;
    //            if (string.IsNullOrWhiteSpace(message))
    //            {
    //                continue;
    //            }

    //            builder.AppendLine(!useHtmlNewLine ? message : $"{message}<br/>");
    //        }

    //        return builder.ToString();
    //    }

    //    public static void ExportModelStateToTempData(this ModelStateDictionary modelState, Controller controller,
    //        string key)
    //    {
    //        if (controller != null && modelState != null)
    //        {
    //            var modelStateJson = SerializeModelState(modelState);
    //            controller.TempData[key] = modelStateJson;
    //        }
    //    }

    //    public static string SerializeModelState(this ModelStateDictionary modelState)
    //    {
    //        var values = modelState
    //            .Select(kvp => new ModelStateTransferValue
    //            {
    //                Key = kvp.Key,
    //                AttemptedValue = kvp.Value.AttemptedValue,
    //                RawValue = kvp.Value.RawValue,
    //                ErrorMessages = kvp.Value.Errors.Select(err => err.ErrorMessage).ToList(),
    //            });

    //        return values.ToJson();
    //    }

    //    public class ModelStateTransferValue
    //    {
    //        public string Key { get; set; }
    //        public string AttemptedValue { get; set; }
    //        public object RawValue { get; set; }
    //        public ICollection<string> ErrorMessages { get; set; } = new List<string>();
    //    }
    //}
}