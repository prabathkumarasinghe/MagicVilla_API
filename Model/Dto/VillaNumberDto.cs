using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Model.Dto
{
    public class VillaNumberDto
    {   
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
        public int VillaID { get; set; }
        public VillaDto Villa { get; set; }
    }
}
