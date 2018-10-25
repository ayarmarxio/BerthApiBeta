using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BerthApiBeta.Models
{
    public class Record
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordId { get; set; }
        
        public Point Location { get; set; }      

        public DateTime RecordTime { get; set; }

        public double? BPSystolic { get; set; }

        public double? BPDiastolic { get; set; }
        
        public double? BodyTemperature { get; set; }

        public int? HeartBeatPerSecond { get; set; }

        public double? Dust { get; set; }

        public double? Sulphur { get; set; }

        public double? Nitrogen { get; set; }

        public double? Fluor { get; set; }

        public double? CarbonMonoxide { get; set; }

        public double? Ozone { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        
        public User User { get; set; }

      

    }
}
