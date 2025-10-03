using System;
using System.Collections.Generic;

namespace User.API.Models;

public partial class UsrUserRole
{
    public long user_pkid { get; set; }

    public long role_pkid { get; set; }

    public DateTime assigned_at { get; set; }

    public virtual UsrRole role_pk { get; set; } = null!;

    public virtual UsrUser user_pk { get; set; } = null!;
}
