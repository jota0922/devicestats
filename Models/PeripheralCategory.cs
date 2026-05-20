using Postgrest.Attributes;
using Postgrest.Models;

namespace DeviceStats.Models;

[Table("peripheral_categories")]
public class PeripheralCategory : BaseModel
{
    [PrimaryKey("id")]
    public short Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("display_order")]
    public short DisplayOrder { get; set; }
}
