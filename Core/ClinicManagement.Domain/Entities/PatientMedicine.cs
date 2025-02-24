﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class PatientMedicine
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }  
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }  
        public DateTime PrescribedDate { get; set; }  // İlaç reçete tarihi
        public string Dosage { get; set; }  
    }
}
