using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Model.Dto
{
    public class VillaNumberUpdateDto
    {   
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
