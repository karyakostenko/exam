using System;
using System.Runtime.Serialization;

namespace BusinessLogic.ViewModels
{
    [DataContract]
    public class ReportViewModel
    {
        [DataMember]
        public string MarketName { get; set; }

        public DateTime DateCreate { get; set; }
        [DataMember]
        public string GoodsName { get; set; }
        [DataMember]
        public int GoodsCost { get; set; }
    }
}
