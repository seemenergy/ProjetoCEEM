﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCEEM.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Senha { get; set; }
        [EnumDataType(typeof(StatusEnum))]
        [Required]
        public StatusEnum Status { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        [Column(TypeName = "Date")]
        [Display(Name = "Data de Inativação")]
        public DateTime DataInativacao { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "Data de Bloqueio")]
        public DateTime DataInicioBloqueio { get; set; }
        [Column(TypeName = "DateTime")]
        [Display(Name = "Data de Desbloqueio")]
        public DateTime DataFimBloqueio { get; set; }
        public virtual ICollection<Equipamento> Equipamento { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Contato> Contato { get; set; }
        public enum StatusEnum
        {
            Ativo = 1,
            Inativo = 2,
            Bloqueado = 3
        }
    }
}
