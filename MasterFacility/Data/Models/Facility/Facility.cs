using MasterFacility.Data.Models.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Facility
{
    public class facility
    {
        public int id { get; set; }
        public int districtid { get; set; }
        public int facilityypeid { get; set; }
        public DateTime facilitytypestartdate { get; set; }
        public int facilitystatusid { get; set; }
        public string name { get; set; }
        public string namepashto { get; set; }
        public string namedari { get; set; }
        public string shortname { get; set; }
        public string shortnamedari { get; set; }
        public string shortnamepashto { get; set; }
        public string location { get; set; }
        public string locationdari { get; set; }
        public string address { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public DateTime dateestablished { get; set; }
        public DateTime closeddate { get; set; }
        public DateTime registrationdate { get; set; }
        public DateTime lastupdate { get; set; }

        public district district { get; set; }
        public ICollection<facilitycontact> contacts { get; set; }
        public ICollection<facilitydataset> datasets { get; set; }

        public ICollection<facilityhumanresources> humanresources { get; set; }

        public ICollection<privatefacilitylicense> privatefacilitylicenses { get; set; }
        public ICollection<grantfacility> grantfacilities { get; set; }
    }
}
