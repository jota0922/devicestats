using Postgrest.Attributes;
using Postgrest.Models;

namespace DeviceStats.Models;

[Table("mice")]
public class Mouse : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("maker")]
    public string Maker { get; set; } = string.Empty;

    [Column("model_name")]
    public string ModelName { get; set; } = string.Empty;

    [Column("approved")]
    public bool Approved { get; set; }

    [Column("submitted_by")]
    public Guid? SubmittedBy { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
