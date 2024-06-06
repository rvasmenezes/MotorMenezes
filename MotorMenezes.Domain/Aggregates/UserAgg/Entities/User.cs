using Microsoft.AspNetCore.Identity;
using MotorMenezes.Core.Helpers;
using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Entity;
using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Domain.Aggregates.UserAgg.Entities
{
    public class User : IdentityUser
    {
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime RegisterDate { get; set; }

        [StringLength(14)]
        public string? CNPJ { get; set; }

        [StringLength(15)]
        public string? CNHNumber { get; set; }

        public int? CNHTypeId { get; set; }
        public CNHType? CNHType { get; set; }

        public bool PossuiImagem { get; set; }

        public User(string email, string name)
        {
            UserName = email;
            Email = email;
            Name = name;
            RegisterDate = DateTime.Now.TimeZoneBrasil();
            EmailConfirmed = true;
        }
    }
}
