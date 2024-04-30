namespace Authentication.Model
{
    /// <summary>
    /// Represents Employee Details.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the national ID number of the employee.
        /// </summary>
        public string? NationalIDNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the login ID of the employee.
        /// </summary>
        public string? LoginID { get; set; }

        /// <summary>
        /// Gets or sets the job title of the employee.
        /// </summary>
        public string? JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the employee.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the marital status of the employee.
        /// </summary>
        public string? MaritalStatus { get; set; }

        /// <summary>
        /// Gets or sets the gender of the employee.
        /// </summary>
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the hire date of the employee.
        /// </summary>
        public DateTime HireDate { get; set; }

        /// <summary>
        /// Gets or sets the number of vacation hours for the employee.
        /// </summary>
        public short VacationHours { get; set; }

        /// <summary>
        /// Gets or sets the number of sick leave hours for the employee.
        /// </summary>
        public short SickLeaveHours { get; set; }

        /// <summary>
        /// Gets or sets the row GUID of the employee.
        /// </summary>
        public Guid? RowGuid { get; set; }

        /// <summary>
        /// Gets or sets the last modified date of the employee.
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }

}
