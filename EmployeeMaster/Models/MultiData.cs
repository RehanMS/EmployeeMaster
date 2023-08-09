namespace EmployeeMaster.Models
{
    public class MultiData
    {
        public EmployeeMaster employeeMasters { get; set; }
        public DesignationMaster designationMasters { get; set; }
        public ParentDetailsModel parentDetails { get; set; }
        public RegistrationViewModel registration { get; set; }
    }
}