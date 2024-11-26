using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalMVC.Models
{
    public class Enum
    {
        public enum NotificationType
        {
            error,
            success,
            warning,
            info,
            question
        }
    }
}