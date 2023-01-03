using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using HumanResourcesWpfApp.Models.Domains;

namespace HumanResourcesWpfApp.Models.Configurations
{
    class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("dbo.Address");

            HasKey(x => x.Id);
        }
    }
}
