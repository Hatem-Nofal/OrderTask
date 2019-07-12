using System.ComponentModel.DataAnnotations;

namespace  Oreders.API.Dtos {
    public class UserForRegisterDto {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="Password not vlid it must be bewteen 4 and 8 char")]
        public string Password { get; set; }

        public string Role  { get; set; }

    }
}