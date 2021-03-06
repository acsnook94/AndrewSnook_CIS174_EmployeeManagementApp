﻿/** =========================================================

 Andrew Snook

 Operating System: Windows 10

 Microsoft Visual Studio 2017 Enterprise

 CIS 174

 EmployeeManagement (Week 5)

 Program Description: This application allows the user to view and create database records containing employee information

 Academic Honesty:

 I attest that this is my original work.

 I have not used unauthorized source code, either modified or unmodified.

 I have not given other fellow student(s) access to my program.

=========================================================== **/


using System.Threading.Tasks;
using System.Web.Http;
using System.Collections.Generic;
using AndrewSnook.CIS174.EmployeeManagementApp.Shared.ViewModels;
using AndrewSnook.CIS174.EmployeeManagementApp.Shared.Orchestrators.Interfaces;
using System;
using System.Net.Http;
using System.Net;

namespace AndrewSnook.CIS174.EmployeeManagementApp.Api.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeOrchestrator _employeeOrchestrator;

        public EmployeeController(IEmployeeOrchestrator employeeOrchestrator)
        {
            _employeeOrchestrator = employeeOrchestrator;
        }

        [HttpGet]
        [Route("api/v1/employees")]
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var employees = await _employeeOrchestrator.GetAllEmployees();

            return employees;
        }

        [HttpGet]
        [Route("api/v1/empidfullname")]
        public async Task<Dictionary<Guid, string>> GetAllEmpsIDFullName()
        {
            var employees = await _employeeOrchestrator.GetAllEmpsIDFullName();

            return employees;
        }

        [HttpGet]
        [Route("api/v1/empsingleidsearch")]
        public async Task<SingleEmpViewModel> GetEmpByID(Guid empID)
        {
            var employee = await _employeeOrchestrator.GetEmpByID(empID);
           
            if(employee == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return employee;
        }
    }
}
