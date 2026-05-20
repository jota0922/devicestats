using Postgrest.Attributes;
using Postgrest.Models;

namespace DeviceStats.Models;

[Table("peripheral_registrations")]
public class PeripheralRegistration : BaseModel
{
    [PrimaryKey("id")]
    public long Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("category_id")]
    public short CategoryId { get; set; }

    [Column("product_name")]
    public string ProductName { get; set; } = string.Empty;

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
