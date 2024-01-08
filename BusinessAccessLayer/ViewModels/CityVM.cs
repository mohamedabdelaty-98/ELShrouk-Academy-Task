using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.ViewModels
{
    public class CityVM
    {
        public int ID { get; set; }
        public string CityName { get; set; }

        public ICollection<BranchVM> Branches { get; set; } = new List<BranchVM>();
    }
}
