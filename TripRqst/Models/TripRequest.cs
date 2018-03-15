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
        [Editable(allowEdit:false,AllowInitialValue =true)]
        //public DateTime DataDoPedido { get; set; }
        public DateTime DataDoPedido
        {
            get
            {
                return this.dataDoPedido.HasValue
                   ? this.dataDoPedido.Value
                   : DateTime.Now;
            }

            set { this.dataDoPedido = value; }
        }

        private DateTime? dataDoPedido = null;
        [Required]
        public string Passageiro { get; set; }

        [Required]
        [Display(Name = "Motivo da viagem")]
        public virtual TR_Def_Motivo MotivoViagem { get; set; }

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
        public virtual TR_Def_Justif Justificacao { get; set; }

        [Display(Name = "Avião")]
        public int CustoAviao { get; set; }

        [Display(Name = "Hotel")]
        public int CustoHotel { get; set; }

        [Display(Name = "Carro")]
        public int CustoCarro { get; set; }

        [Display(Name = "Outros")]
        public int CustoOutros { get; set; }

        [Display(Name = "Custo total")]
        public int CustoTotal { get; set; }

        [Required]
        [Display(Name = "Alocação")]
        public virtual TripRequest_Alocacao Aloc { get; set; }
    }

    public class TR_Def_Aloc
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TR_Def_Motivo
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class TR_Def_Justif
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool RequiresEmail { get; set; }
        public bool RequiresAuthorizedMailSender { get; set; }
    }

    public class TripRequest_Alocacao
    {
        public int Id { get; set; }
        public TR_Def_Aloc AlocacaoDef { get; set; }
        public bool RequiresEmail { get; set; }
        public bool RequiresAuthorizedMailSender { get; set; }
    }

    //https://stackoverflow.com/questions/33197402/link-asp-net-identity-users-to-user-detail-table
    public class TR_UserDetails
    {
        public int Id { get; set; }

        [Key, ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }


}