using Microsoft.AspNetCore.Authorization;

namespace Authentication.AuthorisationPolicies
{
    public class AdminRequirement : IAuthorizationRequirement
    {

        public AdminRequirement(string employeeRole) 
        {
            EmployeeRole = employeeRole;
        

        }
        public string EmployeeRole { get; set; }
    }
}
