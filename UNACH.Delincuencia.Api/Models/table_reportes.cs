namespace UNACH.Delincuencia.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class table_reportes
    {
        [Key]
        
        public int Folio { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Primer_ap { get; set; }

        [StringLength(100)]
        public string Segundo_ap { get; set; }

        public int? Edad { get; set; }

        [StringLength(100)]
        public string Sexo { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(100)]
        public string Entidad { get; set; }

        [StringLength(100)]
        public string Municipio { get; set; }

        [StringLength(200)]
        public string Referencias { get; set; }

        [StringLength(100)]
        public string Tipo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        [StringLength(1000)]
        public string Narracion { get; set; }
    }
}
