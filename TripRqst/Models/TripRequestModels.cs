using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TripRqst.Models
{
    [ValidateTotal(ErrorMessage = "Total mis-match")]
    public class TripRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data do pedido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //        [Editable(allowEdit:false,AllowInitialValue =true)]
        public DateTime DataDoPedido { get; set; }
        //public DateTime DataDoPedido
        //{
        //    get
        //    {
        //        return this.dataDoPedido.HasValue
        //           ? this.dataDoPedido.Value
        //           : DateTime.Now;
        //    }

        //    set { this.dataDoPedido = value; }
        //}

        //private DateTime? dataDoPedido = null;

        [Required]
        [Display(Name = "Passageiro")]
        public string Passageiro { get; set; }

        [Required]
        [Display(Name = "Motivo da viagem (code)")]
        public string MotivoCode { get; set; }

        [Required]
        [Display(Name = "Motivo da viagem (nome)")]
        public string MotivoName { get; set; }

        [Required]
        [Display(Name = "Identificação")]
        public string Identificacao { get; set; }

        [Required]
        public string OrigemPais { get; set; }
        [Required]
        public string OrigemCidade { get; set; }

        [Required]
        public string DestinoPais { get; set; }

        [Required]
        public string DestinoCidade { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Partida { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Chegada { get; set; }

        [Display(Name = "Dias de antecedência")]
        public int DiasDeAntecedencia { get; set; }

        [Display(Name = "Justificação (code)")]
        public string JustificacaoCode { get; set; }

        [Display(Name = "Justificação (nome)")]
        public string JustificacaoName { get; set; }

        public string EmailAnexo { get; set; }
        
        [Display(Name = "Custo Avião")]
        [DataType(DataType.Currency)]
        public decimal CustoAviao { get; set; }

        [Display(Name = "Custo Hotel")]
        [DataType(DataType.Currency)]
        public decimal CustoHotel { get; set; }

        [Display(Name = "Custo Transporte")]
        [DataType(DataType.Currency)]
        public decimal CustoCarro { get; set; }

        [Display(Name = "Custo Outros")]
        [DataType(DataType.Currency)]
        public decimal CustoOutros { get; set; }

        [Display(Name = "Custo Total")]
        [DataType(DataType.Currency)]
        public decimal CustoTotal { get; set; }

        [Required]
        [Display(Name = "Alocação (code)")]
        public string AlocacaoCode { get; set; }

        [Required]
        [Display(Name = "Alocação (nome)")]
        public string AlocacaoName { get; set; }
    }

    public class Alocacao_Tr
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Info { get; set; }
        public bool Active { get; set; }
    }
    public class Motivo_Tr
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Info { get; set; }
        public bool Active { get; set; }
    }
    public class Justificacao_Tr
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Info { get; set; }
        public bool RequiresEmail { get; set; }
        public bool RequiresEmailFromAuthorizedSender { get; set; }
        public bool Active { get; set; }
    }

    public class Country_Tr
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDomestic { get; set; }
        public bool Active { get; set; }
    }

    public class TripRequestCreateOrEditViewModel
    {
        public TripRequest TripRequest { get; set; }
        public IEnumerable<Motivo_Tr> Motivos { get; set; }
        public IEnumerable<Justificacao_Tr> Justificacoes { get; set; }
        public IEnumerable<Alocacao_Tr> Alocacoes { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ValidateTotalAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value.GetType() != typeof(TripRequest))
                return false;
            else
            {
                var tr = (TripRequest)value;
                return tr.CustoTotal == tr.CustoAviao + tr.CustoCarro + tr.CustoHotel + tr.CustoOutros;
            }
        }
    }
}