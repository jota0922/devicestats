using System.ComponentModel.DataAnnotations;

namespace DeviceStats.Models;

public class MouseRegistrationForm
{
    [Required(ErrorMessage = "ニックネームを入力してください")]
    [StringLength(40, MinimumLength = 1, ErrorMessage = "1〜40文字で入力してください")]
    public string Nickname { get; set; } = string.Empty;

    [Range(50, 150, ErrorMessage = "50〜150mmの範囲で入力してください")]
    public int? HandWidthMm { get; set; }

    [Range(100, 250, ErrorMessage = "100〜250mmの範囲で入力してください")]
    public int? HandLengthMm { get; set; }

    [Required(ErrorMessage = "利き手を選択してください")]
    public string DominantHand { get; set; } = "right";

    [Required(ErrorMessage = "マウスを選択してください")]
    public long? MouseId { get; set; }

    public string? MainGame { get; set; }

    [Required(ErrorMessage = "持ち方を選択してください")]
    public string GripStyle { get; set; } = "palm";

    public string? ImageUrl { get; set; }

    [StringLength(500, ErrorMessage = "500文字以内で入力してください")]
    public string? Comment { get; set; }
}
