using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Utilities.Encoders;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IdeasAPI
{
    public class PostData
    {
        [Display(Name = "Onderwerp")]
        [Required(ErrorMessage = "Vereist")]
        [MaxLength(512, ErrorMessage = "Onderwerp mag maximaal 512 characters bevatten.")]
        public string Subject { get; set; }

        [Display(Name = "Beschrijving")]
        [Required(ErrorMessage = "Vereist")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vereist")]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "GebrikersId")]
        public int UserId { get; set; }

        [Display(Name = "Gebrikersnaam")]
        [MaxLength(512)]
        public string UserName { get; set; }

        [Display(Name = "Begindatum")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Einddatum")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Categorien")]
        [MaxLength(512)]
        public string Categories { get; set; }
    }
}
