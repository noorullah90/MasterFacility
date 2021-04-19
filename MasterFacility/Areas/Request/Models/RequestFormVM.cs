using System.ComponentModel.DataAnnotations;

namespace MasterFacility.Areas.Request.Models
{
    public class RequestFormVM
    {
        public int id { get; set; }

        [Display(Name = "RequestType", ResourceType = typeof(AppResources.Request))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AppResources.ValidationMessages))]
        [MaxLength(100)]
        public int requesttypeid { get; set; }
        public string requesttype { get; set; }
        public int userid { get; set; }
        public string fullname { get; set; }
        public string date { get; set; }

        [Display(Name = "Remarks", ResourceType = typeof(AppResources.Common))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AppResources.ValidationMessages))]
        [MaxLength(100)]
        public string remarks { get; set; }
        public int requeststatusid { get; set; }

        [Display(Name = "Status", ResourceType = typeof(AppResources.Common))]
        public string requeststatus { get; set; }

        // New facility 

        public int newfacilityrequestid { get; set; }
        public int districtid { get; set; }

        public string district { get; set; }
        public string province { get; set; }
        public string grantcode { get; set; }

        public int facilitytypeid { get; set; }
        public string facilitytype { get; set; }
        public string name { get; set; }
        public string namedari { get; set; }
        public string namepashto { get; set; }
        public string establisheddate { get; set; }
        public string location { get; set; }
        public string locationdari { get; set; }
        public string address { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string approvedfacilitycode { get; set; }
        public string approveddate { get; set; }
        public int approvedby { get; set; }
        public string approvedbyname { get; set; }

        // Request for update detials

        public int updaterequestid { get; set; }
        public int facilityid { get; set; }
        public string facility { get; set; }
        public bool isprocessed { get; set; }
        public string processeddate { get; set; }
        public int processedby { get; set; }
        public string processedbyname { get; set; }

    }
}
