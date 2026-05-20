using Postgrest.Attributes;
using Postgrest.Models;

namespace DeviceStats.Models;

[Table("mouse_registrations")]
public class MouseRegistration : BaseModel
{
    [PrimaryKey("user_id", false)]
    public Guid UserId { get; set; }

    [Column("mouse_id")]
    public long MouseId { get; set; }

    [Column("main_game")]
    public string? MainGame { get; set; }

    [Column("grip_style")]
    public string? GripStyle { get; set; }

    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
