#Region "#usings"
Imports DevExpress.Mvvm.POCO
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows.Media
#End Region ' #usings

Namespace TemplateExample
    Public Class MainViewModel
        Public Overridable Property Doctors() As ObservableCollection(Of Doctor)
        Public Overridable Property Appointments() As ObservableCollection(Of MedicalAppointment)

        Protected Sub New()
            CreateDoctors()
            CreateMedicalAppointments()
        End Sub
        Private Sub CreateDoctors()
            Doctors = New ObservableCollection(Of Doctor)()
            Doctors.Add(Doctor.Create(Id:=1,Name:="Stomatologist"))
            Doctors.Add(Doctor.Create(Id:=2, Name:="Ophthalmologist"))
            Doctors.Add(Doctor.Create(Id:=3, Name:="Surgeon"))
        End Sub

        Private Sub CreateMedicalAppointments()
            Appointments = New ObservableCollection(Of MedicalAppointment)()
            Dim rand As New Random(Date.Now.Millisecond)
            Appointments.Add(MedicalAppointment.Create(StartTime := Date.Now.Date.AddHours(10), EndTime := Date.Now.Date.AddHours(11), DoctorId := 1, Notes := "", Location := "101", PatientName := "Dave Murrel", FirstVisit := True))
            Appointments.Add(MedicalAppointment.Create(StartTime := Date.Now.Date.AddDays(2).AddHours(15), EndTime := Date.Now.Date.AddDays(2).AddHours(16), DoctorId := 1, Notes := "", Location := "101", PatientName := "Mike Roller", FirstVisit := True))

            Appointments.Add(MedicalAppointment.Create(StartTime := Date.Now.Date.AddDays(1).AddHours(11), EndTime := Date.Now.Date.AddDays(1).AddHours(12), DoctorId := 2, Notes := "", Location := "103", PatientName := "Bert Parkins", FirstVisit := True))
            Appointments.Add(MedicalAppointment.Create(StartTime := Date.Now.Date.AddDays(2).AddHours(10), EndTime := Date.Now.Date.AddDays(2).AddHours(12), DoctorId := 2, Notes := "", Location := "103", PatientName := "Carl Lucas", FirstVisit := False))

            Appointments.Add(MedicalAppointment.Create(StartTime := Date.Now.Date.AddHours(12), EndTime := Date.Now.Date.AddHours(13), DoctorId := 3, Notes := "Blood test results are required", Location := "104", PatientName := "Brad Barnes", FirstVisit := False))
            Appointments.Add(MedicalAppointment.Create(StartTime := Date.Now.Date.AddDays(1).AddHours(14), EndTime := Date.Now.Date.AddDays(1).AddHours(15), DoctorId := 3, Notes := "", Location := "104", PatientName := "Richard Fisher", FirstVisit := True))
        End Sub

    End Class

    Public Class Doctor
        Public Shared Function Create() As Doctor
            Return ViewModelSource.Create(Function() New Doctor())
        End Function
        Public Shared Function Create(ByVal Id As Integer, ByVal Name As String) As Doctor

            Dim doctor_Renamed As Doctor = TemplateExample.Doctor.Create()
            doctor_Renamed.Id = Id
            doctor_Renamed.Name = Name
            Return doctor_Renamed
        End Function

        Protected Sub New()
        End Sub

        Public Overridable Property Id() As Integer
        Public Overridable Property Name() As String
    End Class

    Public Class MedicalAppointment
        Public Shared Function Create() As MedicalAppointment
            Return ViewModelSource.Create(Function() New MedicalAppointment())
        End Function
        Friend Shared Function Create(ByVal StartTime As Date, ByVal EndTime As Date, ByVal DoctorId As Integer, ByVal Notes As String, ByVal Location As String, ByVal PatientName As String, ByVal FirstVisit As Boolean) As MedicalAppointment
            Dim apt As MedicalAppointment = MedicalAppointment.Create()
            apt.StartTime = StartTime
            apt.EndTime = EndTime
            apt.DoctorId = DoctorId
            apt.Notes = Notes
            apt.Location = Location
            apt.PatientName = PatientName
            apt.FirstVisit = FirstVisit
            Return apt
        End Function

        Protected Sub New()
        End Sub
        Public Overridable Property Id() As Integer
        Public Overridable Property AllDay() As Boolean
        Public Overridable Property StartTime() As Date
        Public Overridable Property EndTime() As Date
        Public Overridable Property PatientName() As String
        Public Overridable Property Notes() As String
        Public Overridable Property Subject() As String
        Public Overridable Property PaymentStateId() As Integer
        Public Overridable Property IssueId() As Integer
        Public Overridable Property Type() As Integer
        Public Overridable Property Location() As String
        Public Overridable Property RecurrenceInfo() As String
        Public Overridable Property ReminderInfo() As String
        Public Overridable Property DoctorId() As Integer?
        Public Overridable Property FirstVisit() As Boolean
    End Class

End Namespace
