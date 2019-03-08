using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF.Models
{
    // pri takoy arxitekture kak sdelat ctobi u odnogo usera bilo neskolo roley
    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public class User
    {
        public User()
        {
        }

        public User(int ıd, string name, string surname, DateTime dateOfBirth, Gender gender, string phoneNumber, string email, string password, string login, string image, List<AccessLevel> аccessLevels)
        {
            Id = ıd;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            İmage = image ?? throw new ArgumentNullException(nameof(image));
            AccessLevels = аccessLevels ?? throw new ArgumentNullException(nameof(аccessLevels));
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(20)]
        public string Patronymic { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        [MaxLength(40)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        public string Password { get; set; }
        [MaxLength(40)]
        [Index(IsUnique = true)]
        public string Login { get; set; }
        public string İmage { get; set; }
        public List<AccessLevel> AccessLevels { get; set; }
    }
}
