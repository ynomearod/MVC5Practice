using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public enum MemberLevel
    {
        user,
        admin
    }
    public class RegViewModel
    {
        public string UserId { get; set; }
        public string UserPw { get; set; }
        [UIHint("Enum-radio")]
        public MemberLevel Level { get; set; }
    }
}