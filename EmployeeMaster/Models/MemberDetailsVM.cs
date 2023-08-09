using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMaster.Models
{
    [Table("MemberDetailsVM")]
    public class MemberDetailsVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime JoiningDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime InvestmentDate { get; set; }
        public string Tenure { get; set; }
        public string IDProof { get; set; }
        public string Photo { get; set; }
        public int ParentId { get; set; }
        [ForeignKey("ParentId")]
        public ParentDetailsModel Parent { get; set; }
    }
}