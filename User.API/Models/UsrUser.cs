using System;
using System.Collections.Generic;

namespace User.API.Models;

public partial class UsrUser
{
    public long pkid { get; set; }

    public string username { get; set; } = null!;

    public string first_name { get; set; } = null!;

    public string? last_name { get; set; }

    public string password_hash { get; set; } = null!;

    public string? email { get; set; }

    public string? phone_number { get; set; }

    public DateTime created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public bool is_active { get; set; }

    public virtual ICollection<UsrUserRole> UsrUserRoles { get; set; } = new List<UsrUserRole>();

    public virtual UsrUserToken? UsrUserToken { get; set; }
}
