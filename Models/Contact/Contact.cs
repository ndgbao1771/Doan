
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Contacts
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "{0} không được để trống")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Sai định dạng {0}")]
        [Display(Name = "Địa chỉ email")]
        public string Email { get; set; }

        public DateTime DateSent { get; set; }

        [Display(Name = "Nội dung")]
        public string Message { get; set; }

        [StringLength(11, MinimumLength = 10)]
        [Phone(ErrorMessage = "{0} không đúng")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
    }
}