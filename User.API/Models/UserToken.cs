using System;
using System.Collections.Generic;

namespace User.API.Models;

public partial class UserToken
{
    public long pkid { get; set; }

    public long user_id { get; set; }

    public string token { get; set; } = null!;

    public string? device_info { get; set; }

    public DateTime expired_at { get; set; }

    public DateTime created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public DateTime? revoked_at { get; set; }

    public virtual User user { get; set; } = null!;
}
