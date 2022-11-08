using System;
using System.Collections.Generic;

#nullable disable

namespace TestBackend.Models
{
    public partial class MsStorageLocation
    {
        public MsStorageLocation()
        {
            TrBpkbs = new HashSet<TrBpkb>();
        }

        public string LocationId { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<TrBpkb> TrBpkbs { get; set; }
    }
}
