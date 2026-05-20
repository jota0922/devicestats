using Postgrest.Attributes;
using Postgrest.Models;

namespace DeviceStats.Models;

[Table("profiles")]
public class Profile : BaseModel
{
    [PrimaryKey("user_id", false)]
    public Guid UserId { get; set; }

    [Column("nickname")]
    public string Nickname { get; set; } = string.Empty;

    [Column("hand_width_mm")]
    public int? HandWidthMm { get; set; }

    [Column("hand_length_mm")]
    public int? HandLengthMm { get; set; }

    [Column("dominant_hand")]
    public string? DominantHand { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
