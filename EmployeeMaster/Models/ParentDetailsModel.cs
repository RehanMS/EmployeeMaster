using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMaster.Models
{
    [Table("ParentDetailsModel")]
    public class ParentDetailsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParentId { get; set; }
        public string FistName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; } 
        public string AadharNo { get; set; }
        public string PanNo { get; set; }
        public decimal AnnualIncome { get; set; }
    }
}