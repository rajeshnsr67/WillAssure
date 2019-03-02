using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class AssetMappingModel
    {
        public int BeneficiaryId { get; set; }
        public string BeneficiaryText { get; set; }


        public int AssetId { get; set; }
        public string AssetText { get; set; }


        public string AssetValues { get; set; }

    }
}