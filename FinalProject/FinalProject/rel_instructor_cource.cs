//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class rel_instructor_cource
    {
        public int CourseId { get; set; }
        public int InsId { get; set; }
        public Nullable<System.DateTime> Year { get; set; }
        public int Id { get; set; }
    
        public virtual course course { get; set; }
        public virtual instructor instructor { get; set; }
    }
}
