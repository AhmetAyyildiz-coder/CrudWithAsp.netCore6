using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud.Models;

[Table("Islemler")]
public class Islem
{
    [Key]
    public int islemId { get; set; }
    [Display(Name ="Hesap Numarasi")]
    [Column(TypeName = "nvarchar(12)")]
    public string HesapNumarasi { get; set; }
    [Display(Name ="Alici İsim")]
    [Column(TypeName = "nvarchar(100)")]
    public string AliciIsim { get; set; }
    [Display(Name ="Banka isim")]
    [Column(TypeName = "nvarchar(100)")]
    public string BankaIsim { get; set; }
    [Column(TypeName = "nvarchar(11)")]
    /// <summary>
    ///  Swift kodu, bankaların döviz hesaplarına yapılan transferlerin gerçekleştirilmesini sağlayan uluslararası koddu
    /// </summary>
    public string SwiftCode { get; set; }

    public int Miktar { get; set; }
    public DateTime Tarih { get; set; }
}