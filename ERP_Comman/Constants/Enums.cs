using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Comman
{
    public static class Enums
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        public static string GetEnumDescription<T>(string value)
        {
            Type enumType = typeof(T);
            FieldInfo fi = enumType.GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static List<DropdownListItem> GetSelectList<T>()
        {
            return (Enum.GetValues(typeof(T)).Cast<T>().Select(s => new DropdownListItem()
            {
                Text = s.ToString(),
                Value = s.GetHashCode()
            })).ToList();
        }

        public enum ERPResponseStatusCode
        {
            ModelStateError = -1,
            Ok = 200,
            BadRequest = 400,
            NotFound = 404, // also use for data not found
            ServerError = 500,
            UnAuthorized = 401,
            AccessDenied = 403,
            NotAllowed = 405,
            Conflict = 409
        }

        public static string GetStatusCodeString(ERPResponseStatusCode code)
        {
            if (code == ERPResponseStatusCode.Ok)
                return "Ok";
            else if (code == ERPResponseStatusCode.BadRequest)
                return "Bad Request";
            else if (code == ERPResponseStatusCode.NotFound)
                return "Not Found";
            else if (code == ERPResponseStatusCode.ServerError)
                return "Server Error";
            else if (code == ERPResponseStatusCode.AccessDenied)
                return "Access Denied";
            else if (code == ERPResponseStatusCode.NotAllowed)
                return "Not Allowed";
            else if (code == ERPResponseStatusCode.Conflict)
                return "Conflict";
            else if (code == ERPResponseStatusCode.UnAuthorized)
                return "Token Expired";

            return "";
        }

    }
}
