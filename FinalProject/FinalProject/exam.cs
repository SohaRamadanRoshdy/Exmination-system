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
    
    public partial class exam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public exam()
        {
            this.course_exam = new HashSet<course_exam>();
            this.exam_qusetion = new HashSet<exam_qusetion>();
            this.rel_exam_student = new HashSet<rel_exam_student>();
        }
    
        public int ExamCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.DateTime Date { get; set; }
        public short MaxDegree { get; set; }
        public short MinDegree { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course_exam> course_exam { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<exam_qusetion> exam_qusetion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_exam_student> rel_exam_student { get; set; }
    }
}
