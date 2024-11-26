using System;

namespace Genesis.Domain.Models;

public interface ISoftDeleted
{
	DateTime? DeletedAt { get; set; }
}