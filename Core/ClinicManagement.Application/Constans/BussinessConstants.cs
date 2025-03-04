using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Constans
{
    public static class BussinessConstants
    {
        #region Appointment
        public const string AppointmentSuccessfullyCreated = "Appoinment successfully created";
        public const string AppointmentSuccessfullyDeleted = "Appointment successfully deleted";
        public const string AppointmentSuccessfullyUpdated = "Appointment successfully updated";
        public const string AppointmentCouldNotFind = "Appointment could not find";
        public const string AppointmentCouldNotAdd = "Appointment could not add";
        public const string AppointmentCouldNotDelete = "Appointment could not delete";
        #endregion

        #region Patient
        public const string PatientCouldNotFind = "The patient could not find.";
        #endregion

        #region Clinic
        public const string ClinicCouldNotFind = "The clinic could not find";
        public const string ClinicAlreadyExist = "The clinic already exist";
        public const string ClinicCouldNotAdd = "The clinic could not add";
        public const string ClinicAddedSuccessfully = "The clinic added successfully";
        public const string ClinicDeletedSuccessfully = "The clinic deleted successfully";
        public const string ClinicUpdatedSuccessfully = "The clinic updated successfully";
        #endregion

        #region Employee
        public const string EmployeeCouldNotFind = "The employee could not find";
        public const string EmployeeAlreadyExist = "The employee already exist";
        public const string EmployeeCouldNotAdd = "The employee could not add";
        public const string EmployeeAddedSuccessfully = "The employee added successfully";
        public const string EmployeeDeletedSuccessfully = "The employee deleted successfully";
        public const string EmployeeUpdatedSuccessfully = "The employee updated successfully";
        #endregion

        #region Disease
        public const string DiseaseCouldNotFind = "The disease could not find";
        public const string DiseaseCouldNotAdd = "The disease could not add";
        public const string DiseaseCouldNotDelete = "The disease could not delete";
        public const string DiseaseAlreadyExist = "The disease already exist";
        public const string DiseaseSuccessfullyAdded = "The disease successfully added";
        public const string DiseaseSuccessfullyDeleted = "The disease successfully deleted";
        public const string DiseaseSuccessfullyUpdated = "The disease successfully updated";
        #endregion
    }
}
