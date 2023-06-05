using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DtoInfrastructure
{
    public class IdeaInfrastructureDto
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Categories { get; set; }
    }
}
