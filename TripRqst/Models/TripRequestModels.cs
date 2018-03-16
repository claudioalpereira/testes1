using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TripRqst.Models
{
    public class TripRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data do pedido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
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
        public string Passageiro { get; set; }

        [Required]
        [Display(Name = "Motivo da viagem")]
        public string Motivo { get; set; }

        [Required]
        [Display(Name = "Identificação")]
        public string Identificacao { get; set; }

        [Required]
        public string Origem { get; set; }

        [Required]
        public string Destino { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Partida { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Chegada { get; set; }

        [Display(Name = "Dias de antecedência")]
        public int DiasDeAntecedencia { get; set; }

        [Required]
        [Display(Name = "Justificação")]
        public virtual Justificacao_Tr Justificacao { get; set; }

        public int Justificacao_Id { get; set; }

        [Display(Name = "Avião")]
        [DataType(DataType.Currency)]
        public int CustoAviao { get; set; }

        [Display(Name = "Hotel")]
        [DataType(DataType.Currency)]
        public int CustoHotel { get; set; }

        [Display(Name = "Carro")]
        [DataType(DataType.Currency)]
        public int CustoCarro { get; set; }

        [Display(Name = "Outros")]
        [DataType(DataType.Currency)]
        public int CustoOutros { get; set; }

        [Display(Name = "Custo total")]
        [DataType(DataType.Currency)]
        public int CustoTotal { get; set; }

        [Required]
        [Display(Name = "Alocação")]
        public virtual Alocacao_Tr Alocacao{ get; set; }
    }

    public class Alocacao_Tr
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public bool Active { get; set; }
    }
    public class Motivo_Tr
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public bool Active { get; set; }
    }
    public class Justificacao_Tr
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public bool RequiresEmail { get; set; }
        public bool RequiresEmailFromAuthorizedSender { get; set; }
        public bool Active { get; set; }
    }


}