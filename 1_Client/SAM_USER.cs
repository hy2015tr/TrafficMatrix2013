//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrafficMatrix2013
{
    using System;
    using System.Collections.Generic;
    
    public partial class SAM_USER
    {
        public decimal ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string FULLNAME { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public Nullable<decimal> GROUPID { get; set; }
        public string ADMIN { get; set; }
        public string ACTIVE { get; set; }
    
        public virtual SAM_GROUP SAM_GROUP { get; set; }
    }
}
