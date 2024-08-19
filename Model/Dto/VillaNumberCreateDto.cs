using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Model.Dto
{
    public class VillaNumberCreateDto
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
