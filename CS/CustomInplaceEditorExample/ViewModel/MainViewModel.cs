#region #usings
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
#endregion #usings

namespace TemplateExample {
    public class MainViewModel {
        public virtual ObservableCollection<Doctor> Doctors { get; set; }
        public virtual ObservableCollection<MedicalAppointment> Appointments { get; set; }

        protected MainViewModel() {
            CreateDoctors();
            CreateMedicalAppointments();
        }
        private void CreateDoctors() {
            Doctors = new ObservableCollection<Doctor>();
            Doctors.Add(Doctor.Create(Id:1,Name:"Stomatologist"));
            Doctors.Add(Doctor.Create(Id:2, Name:"Ophthalmologist"));
            Doctors.Add(Doctor.Create(Id:3, Name:"Surgeon"));
        }

        private void CreateMedicalAppointments() {
            Appointments = new ObservableCollection<MedicalAppointment>();
            Random rand = new Random(DateTime.Now.Millisecond);
            Appointments.Add(MedicalAppointment.Create(StartTime : DateTime.Now.Date.AddHours(10), EndTime : DateTime.Now.Date.AddHours(11), DoctorId : 1, Notes : "", Location : "101", PatientName : "Dave Murrel", FirstVisit : true));
            Appointments.Add(MedicalAppointment.Create(StartTime : DateTime.Now.Date.AddDays(2).AddHours(15), EndTime : DateTime.Now.Date.AddDays(2).AddHours(16), DoctorId : 1, Notes : "", Location : "101", PatientName : "Mike Roller", FirstVisit : true));

            Appointments.Add(MedicalAppointment.Create(StartTime : DateTime.Now.Date.AddDays(1).AddHours(11), EndTime : DateTime.Now.Date.AddDays(1).AddHours(12), DoctorId : 2, Notes : "", Location : "103", PatientName : "Bert Parkins", FirstVisit : true));
            Appointments.Add(MedicalAppointment.Create(StartTime : DateTime.Now.Date.AddDays(2).AddHours(10), EndTime : DateTime.Now.Date.AddDays(2).AddHours(12), DoctorId : 2, Notes : "", Location : "103", PatientName : "Carl Lucas",  FirstVisit : false));

            Appointments.Add(MedicalAppointment.Create(StartTime : DateTime.Now.Date.AddHours(12), EndTime : DateTime.Now.Date.AddHours(13), DoctorId : 3, Notes : "Blood test results are required", Location : "104", PatientName : "Brad Barnes", FirstVisit : false));
            Appointments.Add(MedicalAppointment.Create(StartTime : DateTime.Now.Date.AddDays(1).AddHours(14), EndTime : DateTime.Now.Date.AddDays(1).AddHours(15), DoctorId : 3, Notes : "", Location : "104", PatientName : "Richard Fisher", FirstVisit : true));
        }

    }

    public class Doctor {
        public static Doctor Create() {
            return ViewModelSource.Create(() => new Doctor());
        }
        public static Doctor Create(int Id, string Name) {
            Doctor doctor = Doctor.Create();
            doctor.Id = Id;
            doctor.Name = Name;
            return doctor;           
        }

        protected Doctor() { }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class MedicalAppointment {
        public static MedicalAppointment Create() {
            return ViewModelSource.Create(() => new MedicalAppointment());
        }
        internal static MedicalAppointment Create(DateTime StartTime, DateTime EndTime, int DoctorId, string Notes, string Location, string PatientName, bool FirstVisit) {
            MedicalAppointment apt = MedicalAppointment.Create();
            apt.StartTime = StartTime;
            apt.EndTime = EndTime;
            apt.DoctorId = DoctorId;
            apt.Notes = Notes;
            apt.Location = Location;
            apt.PatientName = PatientName;
            apt.FirstVisit = FirstVisit;
            return apt;
        }

        protected MedicalAppointment() { }
        public virtual int Id { get; set; }
        public virtual bool AllDay { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string PatientName { get; set; }
        public virtual string Notes { get; set; }
        public virtual string Subject { get; set; }
        public virtual int PaymentStateId { get; set; }
        public virtual int IssueId { get; set; }
        public virtual int Type { get; set; }
        public virtual string Location { get; set; }
        public virtual string RecurrenceInfo { get; set; }
        public virtual string ReminderInfo { get; set; }
        public virtual int? DoctorId { get; set; }
        public virtual bool FirstVisit { get; set; }
    }

}
