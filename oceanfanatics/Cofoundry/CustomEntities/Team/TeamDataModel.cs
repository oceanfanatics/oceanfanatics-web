using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.CustomEntities.Team
{
    public class TeamDataModel : ICustomEntityDataModel
    {
        [Required]
        [MaxLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Image]
        [Display(Name = "Photo")]
        public int PhotoId { get; set; }
    }
}
