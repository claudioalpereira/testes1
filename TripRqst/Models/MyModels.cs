using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TripRqst.Models
{
    //https://stackoverflow.com/questions/33197402/link-asp-net-identity-users-to-user-detail-table
    public class TR_UserDetails
    {
        public int Id { get; set; }

        [Key, ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }


}