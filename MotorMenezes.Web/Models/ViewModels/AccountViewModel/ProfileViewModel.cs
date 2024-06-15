using Microsoft.AspNetCore.Http;
using MotorMenezes.Domain.Aggregates.CNHTypeAgg.Entity;
using MotorMenezes.Web.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorMenezes.Web.Models.ViewModels.AccountViewModel
{
    public class ProfileViewModel
    {
        public List<CNHType> CNHTypeList { get; set; }

        public string Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Name { get; set; }

        [StringLength(18)]
        [CNPJValidation]
        public string CNPJ { get; set; }

        [Display(Name = "Data de Aniversário")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data de nascimento é obrigatória!")]
        [AgeRestriction(ErrorMessage = "Você deve ter mais de 18 anos.")]
        public DateTime? BirthDate { get; set; }

        [StringLength(15)]
        [Display(Name = "Número da CNH")]
        [Required(ErrorMessage = "Número da da CNH é obrigatório!")]
        public string CNHNumber { get; set; }

        [Display(Name = "Tipo da CNH")]
        [Required(ErrorMessage = "Tipo da CNH é obrigatório!")]
        public int? CNHTypeId { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public bool PossuiImagem { get; set; }

        [Display(Name = "Foto da CNH")]
        public IFormFile Archive { get; set; }
    }
}
