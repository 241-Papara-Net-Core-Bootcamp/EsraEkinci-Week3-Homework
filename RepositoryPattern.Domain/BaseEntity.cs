using System;

namespace Repository.Domain
{
    public abstract class BaseEntity
    {
        public int CourseId { get; set; } 
        public bool IsDeleted { get; set; } = false;    
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Admin";   
        public DateTime? LastModifiedDate { get; set; } //It can be null.
        

    }
}
