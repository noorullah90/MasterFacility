using System;
using System.Web;
using System.Resources;
using Westwind.Globalization;

namespace AppResources
{
    public class GeneratedResourceSettings
    {
        // You can change the ResourceAccess Mode globally in Application_Start        
        public static ResourceAccessMode ResourceAccessMode = DbResourceConfiguration.Current.ResourceAccessMode;
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("Westwind.Globalization.StronglyTypedResources", "3.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources
    {
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new ResourceManager("AppResources.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        private static ResourceManager resourceMan = null;

		public static System.String HelloWorld
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Resources","HelloWorld",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String Yesterday
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Resources","Yesterday",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String MarkdownText
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Resources","MarkdownText",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String Today
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Resources","Today",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

	}


    [System.CodeDom.Compiler.GeneratedCodeAttribute("Westwind.Globalization.StronglyTypedResources", "3.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Facility
    {
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new ResourceManager("AppResources.Facility", typeof(Facility).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        private static ResourceManager resourceMan = null;

		public static System.String latitude
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Facility","latitude",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String longitude
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Facility","longitude",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

	}


    [System.CodeDom.Compiler.GeneratedCodeAttribute("Westwind.Globalization.StronglyTypedResources", "3.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Lookups
    {
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new ResourceManager("AppResources.Lookups", typeof(Lookups).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        private static ResourceManager resourceMan = null;

		public static System.String ListOfFacilityTypeCategories
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Lookups","ListOfFacilityTypeCategories",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

	}


    [System.CodeDom.Compiler.GeneratedCodeAttribute("Westwind.Globalization.StronglyTypedResources", "3.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ValidationMessages
    {
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new ResourceManager("AppResources.ValidationMessages", typeof(ValidationMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        private static ResourceManager resourceMan = null;

		public static System.String Required
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("ValidationMessages","Required",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

	}


    [System.CodeDom.Compiler.GeneratedCodeAttribute("Westwind.Globalization.StronglyTypedResources", "3.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Common
    {
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new ResourceManager("AppResources.Common", typeof(Common).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        private static ResourceManager resourceMan = null;

		public static System.String Save
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Common","Save",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String Province
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Common","Province",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String Remakrs
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Common","Remakrs",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String IsActive
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Common","IsActive",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String NameDari
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Common","NameDari",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String NamePashto
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Common","NamePashto",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String Remarks
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Common","Remarks",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String Update
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Common","Update",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String Name
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Common","Name",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String AppTitle
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Common","AppTitle",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

	}


    [System.CodeDom.Compiler.GeneratedCodeAttribute("Westwind.Globalization.StronglyTypedResources", "3.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MessageBox
    {
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new ResourceManager("AppResources.MessageBox", typeof(MessageBox).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        private static ResourceManager resourceMan = null;

		public static System.String Success
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("MessageBox","Success",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String Error
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("MessageBox","Error",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

	}


    [System.CodeDom.Compiler.GeneratedCodeAttribute("Westwind.Globalization.StronglyTypedResources", "3.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Request
    {
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new ResourceManager("AppResources.Request", typeof(Request).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        private static ResourceManager resourceMan = null;

		public static System.String ProcessedDate
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Request","ProcessedDate",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String ApprovedFacilityCode
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Request","ApprovedFacilityCode",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String processedby
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Request","processedby",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String RequestType
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Request","RequestType",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String Fullname
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Request","Fullname",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String ApprovedDate
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Request","ApprovedDate",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String approvedby
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Request","approvedby",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String IsProcessed
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Request","IsProcessed",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

	}


    [System.CodeDom.Compiler.GeneratedCodeAttribute("Westwind.Globalization.StronglyTypedResources", "3.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class District
    {
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new ResourceManager("AppResources.District", typeof(District).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        private static ResourceManager resourceMan = null;

	
		public static System.String AllDistrict
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("District","AllDistrict",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

	}


    [System.CodeDom.Compiler.GeneratedCodeAttribute("Westwind.Globalization.StronglyTypedResources", "3.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Provinces
    {
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    var temp = new ResourceManager("AppResources.Provinces", typeof(Provinces).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        private static ResourceManager resourceMan = null;

		public static System.String AllProvinces
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Provinces","AllProvinces",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String CreateNew
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Provinces","CreateNew",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String ProvincesList
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Provinces","ProvincesList",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

		public static System.String UpdateProvince
		{
			get
			{
				return GeneratedResourceHelper.GetResourceString("Provinces","UpdateProvince",ResourceManager,GeneratedResourceSettings.ResourceAccessMode);
			}
		}

	}

}
