using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class MyValidationAttribute : DataTypeAttribute
    {
        public MyValidationAttribute() : base("MyValidation") {
        }
        public override bool IsValid(object value)
        {
            bool IsOK = false;

            if (Convert.ToInt16(value) % 2 == 0)
            {
                IsOK = true;
            }

            return IsOK;
        }
    }
}