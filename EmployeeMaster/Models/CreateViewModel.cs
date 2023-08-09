using System.Collections.Generic;

namespace EmployeeMaster.Models
{
    public class CreateViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int DesignationId { get; set; }
        public List<DesignationMaster> DesignationMaster { get; set; }
    }

}