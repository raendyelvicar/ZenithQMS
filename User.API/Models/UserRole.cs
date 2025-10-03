using System;
using System.Collections.Generic;

namespace User.API.Models;

public partial class UserRole
{
    public long user_pkid { get; set; }

    public long role_pkid { get; set; }

    public DateTime assigned_at { get; set; }

    public virtual Role role_pk { get; set; } = null!;

    public virtual User user_pk { get; set; } = null!;
}
