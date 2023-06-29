using System.ComponentModel.DataAnnotations;

namespace TEKenable_Newsletter.Models
{
    public class SignUpViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ContactSource { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ContactReason { get; set; }
    }
}
