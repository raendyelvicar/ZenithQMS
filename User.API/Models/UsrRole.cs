using System;
using System.Collections.Generic;

namespace User.API.Models;

public partial class UsrRole
{
    public long pkid { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public bool is_active { get; set; }

    public DateTime created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<UsrUserRole> UsrUserRoles { get; set; } = new List<UsrUserRole>();
}
