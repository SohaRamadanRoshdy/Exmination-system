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
    
    public partial class rel_exam_track
    {
        public int TrackId { get; set; }
        public int ExamCode { get; set; }
        public int ID { get; set; }
    
        public virtual rel_exam_track rel_exam_track1 { get; set; }
        public virtual rel_exam_track rel_exam_track2 { get; set; }
        public virtual track track { get; set; }
    }
}
