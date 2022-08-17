using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class BundleFileEntity : BaseEntity
    {
#nullable disable
        public long BundleSize { get; set; }
        public int BundleFiles { get; set; }
        public DateTime ModifiedAt { get; set; }

        public BundleFileEntity()
        {
            ModifiedAt = DateTime.Now;
        }
    }
}
