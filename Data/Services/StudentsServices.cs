using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using MalaikaSchool.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using static MalaikaSchool.Areas.Identity.Pages.Account.LoginModel;


namespace MalaikaSchool.Data.Services
{
    [Authorize(Roles = "Admin,Employee")]
    public class StudentsService 
    {       

        private readonly MalaikaDbContext _context;

       

        public StudentsService (MalaikaDbContext context)
        {         
            _context = context; 
        }

        public async Task<List<Student>> Index()
        {
            return await _context.Student.AsNoTracking().ToListAsync();
        }

        //Create Student
        public async Task<Student> CreateStudent(Student student)
        {
         
         
            try
            {
                //InputModel modelInput = new InputModel();
                //modelInput.Email = student.Email;
                //modelInput.Password = student.StudentId.ToString();

                //await registering.Custum_Register(modelInput);
                _context.Student.Add(student); 
                _context.SaveChanges(); 
                return await Task.FromResult(student);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw; 
            }
        }


        //Get Student
        public async Task<Student> GetStudent(int? id)
        {
            var d= await _context.Student.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return d;
        }

        //Edit/{Id:int} Student
        public Task<bool> EditStudent(Student student)
        {
            var ExistingStudent = GetStudent(student.Id);
            if (ExistingStudent != null)
            {
               
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else 
            { 
                return Task.FromResult(false); 
            }
            return Task.FromResult(true);
        }

             
     //Delete Student  
        public async Task DeleteConfirmed(int id)
        {
            Admission admsn = await _context.Admission.Where(x => x.StudentId == id).SingleOrDefaultAsync();
            if( admsn!= null)
            {
                _context.Admission.Remove(admsn);
                _context.SaveChanges();   
            }
            
            Guardian grdn = _context.Guardian.Where(x => x.StudentId == id).SingleOrDefault();
            if( grdn!= null)
            {
                _context.Guardian.Remove(grdn);
                _context.SaveChanges();
            }
            
            int arId = _context.AssignRoll.Where(x => x.StudentId == id).Select(x => x.Id).SingleOrDefault();
            Exam em = _context.Exams.Where(x => x.AssignRollId == arId).SingleOrDefault();
            if( em!= null)
            {
                _context.Exams.Remove(em);
                _context.SaveChanges();
            }
            

            AssignRoll ar = _context.AssignRoll.Where(x => x.StudentId == id).SingleOrDefault();
            if (ar != null)
            {
                _context.AssignRoll.Remove(ar);
               _context.SaveChanges();
            }

            Student student = _context.Student.Find(id);
            _context.Student.Remove(student);
            _context.SaveChanges();
        }

        //--------------------------------Guardian-------------------------------------------------------------------

        public async Task<List<Guardian>> GuardianIndex()
        {
            var guardian =_context.Guardian;
            return await Task.FromResult((guardian.ToList()));
        }
        //Create Guardian
        public async Task<Guardian> CreateGuardian(Guardian Guardian)
        {
            Registering registering = new Registering();
            try
            {
                InputModel modelInput = new InputModel();
                modelInput.Email = Guardian.Email;
                modelInput.Password = Guardian.StudentId.ToString();

                await registering.Custum_Register(modelInput);
                _context.Guardian.Add(Guardian);
                _context.SaveChanges();
                return await Task.FromResult(Guardian);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<Guardian> GetGuardian(int? id)
        {
            var g = await _context.Guardian.AsNoTracking().Where(n => n.Id == id).Include(g => g.GuardianType).Include(g => g.Student)
                .FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditGuardian(Guardian guardian)
        {
            var ExistingGuardian = GetGuardian(guardian.Id);
            if (ExistingGuardian != null)
            {

                _context.Entry(guardian).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete Guardian  
        public async Task GuardianDeleteConfirmed(int id)
        {
            Guardian grdn =await GetGuardian(id);
            if (grdn != null)
            {
                _context.Guardian.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End Guardian---------------------------------------------



        //--------------------------------GuardianType-------------------------------------------------------------------

        public async Task<List<GuardianType >> GuardianTypeIndex()
        {
            var guardianType = _context.GuardianType.ToList();
            return await Task.FromResult((guardianType));
        }
        //Create GuardianType 
        public async Task<GuardianType> CreateGuardianType(GuardianType  GuardianType)
        {
            try
            {

                _context.GuardianType.Add(GuardianType);
                _context.SaveChanges();
                return await Task.FromResult(GuardianType);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<GuardianType>GetGuardianType(int? id)
        {
            var g = await _context.GuardianType.AsNoTracking().Where(n => n.Id == id)
                .FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditGuardianType(GuardianType  GuardianType)
        {
            var ExistingGuardianType = GetGuardianType(GuardianType.Id);
            if (ExistingGuardianType != null)
            {

                _context.Entry(GuardianType).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        //Delete  GuardianType   
        public async Task GuardianTypeDeleteConfirmed(int id)
        {
             GuardianType  grdn = await GetGuardianType(id);
            if (grdn != null)
            {
                _context.GuardianType.Remove(grdn);
                _context.SaveChanges();
            }
        }

        //---------------------------------End  GuardianType ---------------------------------------------


        //--------------------------------Admission-------------------------------------------------------------------

        public async Task<List<Admission>> AdmissionIndex()
        {
            var Admission = _context.Admission;
            return await Task.FromResult((Admission.ToList()));
        }
        //Create Admission
        public async Task<Admission> CreateAdmission(Admission Admission)
        {
            try
            {

                _context.Admission.Add(Admission);
                _context.SaveChanges();
                return await Task.FromResult(Admission);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<Admission> GetAdmission(int? id)
        {
            var g = await _context.Admission.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditAdmission(Admission Admission)
        {
            var ExistingAdmission = GetAdmission(Admission.Id);
            if (ExistingAdmission != null)
            {

                _context.Entry(Admission).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete Admission  
        public async Task AdmissionDeleteConfirmed(int id)
        {
            Admission grdn = await GetAdmission(id);
            if (grdn != null)
            {
                _context.Admission.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End Admission-----------------------------------------------------------------


        //--------------------------------StudentClass-------------------------------------------------------------------

        public async Task<List<StudentClass>> StudentClassIndex()
        {
            var StudentClass = _context.StudentClass.AsNoTracking().Include(n=>n.ClassFees);
            return await Task.FromResult((StudentClass.ToList()));
        }
        //Create StudentClass
        public async Task<StudentClass> CreateStudentClass(StudentClass StudentClass)
        {
            try
            {

                _context.StudentClass.Add(StudentClass);
                _context.SaveChanges();
                return await Task.FromResult(StudentClass);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<StudentClass> GetStudentClass(int? id)
        {
            var g = await _context.StudentClass.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditStudentClass(StudentClass StudentClass)
        {
            var ExistingStudentClass = GetStudentClass(StudentClass.Id);
            if (ExistingStudentClass != null)
            {

                _context.Entry(StudentClass).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete StudentClass  
        public async Task StudentClassDeleteConfirmed(int id)
        {
            StudentClass grdn = await GetStudentClass(id);
            if (grdn != null)
            {
                _context.StudentClass.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End StudentClass---------------------------------------------


        //--------------------------------ClassFee-------------------------------------------------------------------

        public async Task<List<ClassFee>> ClassFeeIndex()
        {
            var ClassFee = _context.ClassFee.AsNoTracking();
            return await Task.FromResult((ClassFee.ToList()));
        }
        //Create ClassFee
        public async Task<ClassFee> CreateClassFee(ClassFee ClassFee)
        {
            try
            {

                _context.ClassFee.Add(ClassFee);
                _context.SaveChanges();
                return await Task.FromResult(ClassFee);
            }
            catch (Exception ex)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<ClassFee> GetClassFee(int? id)
        {
            var g = await _context.ClassFee.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public async Task<bool> EditClassFee(ClassFee ClassFee)
        {
            var ExistingClassFee = await GetClassFee(ClassFee.Id);

            if (ExistingClassFee != null)
            {
                ExistingClassFee.StudentClassId = ClassFee.StudentClassId;

                _context.Entry(ExistingClassFee).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> EditClassFeeVM(ClassFeeVM ClassFeeVM)
        {
            var ExistingClassFee = await GetClassFee(ClassFeeVM.ClassFeeId);
            

            if (ExistingClassFee != null)
            {
                ExistingClassFee.StudentClassId = ClassFeeVM.StudentClassId;

                _context.Entry(ExistingClassFee).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }

        //Delete ClassFee  
        public async Task ClassFeeDeleteConfirmed(int id)
        {
            ClassFee grdn = await GetClassFee(id);
            if (grdn != null)
            {
                _context.ClassFee.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End ClassFee---------------------------------------------



        //--------------------------------Group-------------------------------------------------------------------

        public async Task<List<Group>> GroupIndex()
        {
            var Group = _context.Group.AsNoTracking();
            return await Task.FromResult((Group.ToList()));
        }
        //Create Group
        public async Task<Group> CreateGroup(Group Group)
        {
            try
            {

                _context.Group.Add(Group);
                _context.SaveChanges();
                return await Task.FromResult(Group);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<Group> GetGroup(int? id)
        {
            var g = await _context.Group.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditGroup(Group Group)
        {
            var ExistingGroup = GetGroup(Group.Id);
            if (ExistingGroup != null)
            {

                _context.Entry(Group).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete Group  
        public async Task GroupDeleteConfirmed(int id)
        {
            Group grdn = await GetGroup(id);
            if (grdn != null)
            {
                _context.Group.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End Group---------------------------------------------

        //--------------------------------Section-------------------------------------------------------------------

        public async Task<List<Section>> SectionIndex()
        {
            var Section = _context.Section.AsNoTracking();
            return await Task.FromResult((Section.ToList()));
        }
        //Create Section
        public async Task<Section> CreateSection(Section Section)
        {
            try
            {

                _context.Section.Add(Section);
                _context.SaveChanges();
                return await Task.FromResult(Section);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<Section> GetSection(int? id)
        {
            var g = await _context.Section.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditSection(Section Section)
        {
            var ExistingSection = GetSection(Section.Id);
            if (ExistingSection != null)
            {

                _context.Entry(Section).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete Section  
        public async Task SectionDeleteConfirmed(int id)
        {
            Section grdn = await GetSection(id);
            if (grdn != null)
            {
                _context.Section.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End Section---------------------------------------------

        //--------------------------------PhoneNumber-------------------------------------------------------------------

        public async Task<List<PhoneNumber>> PhoneNumberIndex()
        {
            var PhoneNumber = _context.PhoneNumber.AsNoTracking();
            return await Task.FromResult((PhoneNumber.ToList()));
        }
        //Create PhoneNumber
        public async Task<PhoneNumber> CreatePhoneNumber(PhoneNumber PhoneNumber)
        {
            try
            {

                _context.PhoneNumber.Add(PhoneNumber);
                _context.SaveChanges();
                return await Task.FromResult(PhoneNumber);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<PhoneNumber> GetPhoneNumber(int? id)
        {
            var g = await _context.PhoneNumber.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditPhoneNumber(PhoneNumber PhoneNumber)
        {
            var ExistingPhoneNumber = GetPhoneNumber(PhoneNumber.Id);
            if (ExistingPhoneNumber != null)
            {

                _context.Entry(PhoneNumber).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete PhoneNumber  
        public async Task PhoneNumberDeleteConfirmed(int id)
        {
            PhoneNumber grdn = await GetPhoneNumber(id);
            if (grdn != null)
            {
                _context.PhoneNumber.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End PhoneNumber---------------------------------------------


        //--------------------------------Subject-------------------------------------------------------------------

        public async Task<List<Subject>> SubjectIndex()
        {
            var Subject = _context.Subject.AsNoTracking();
            return await Task.FromResult((Subject.ToList()));
        }
        //Create Subject
        public async Task<Subject> CreateSubject(Subject Subject)
        {
            try
            {

                _context.Subject.Add(Subject);
                _context.SaveChanges();
                return await Task.FromResult(Subject);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<Subject> GetSubject(int? id)
        {
            var g = await _context.Subject.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditSubject(Subject Subject)
        {
            var ExistingSubject = GetSubject(Subject.Id);
            if (ExistingSubject != null)
            {

                _context.Entry(Subject).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete Subject  
        public async Task SubjectDeleteConfirmed(int id)
        {
            Subject grdn = await GetSubject(id);
            if (grdn != null)
            {
                _context.Subject.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End Subject---------------------------------------------

        //--------------------------------Employee-------------------------------------------------------------------

        public async Task<List<Employee>> EmployeeIndex()
        {
            var Employee = _context.Employee.AsNoTracking();
            return await Task.FromResult((Employee.ToList()));
        }
        //Create Employee
        public async Task<Employee> CreateEmployee(Employee Employee)
        {
          
            try
            {
                _context.Employee.Add(Employee);
                _context.SaveChanges();
                return await Task.FromResult(Employee);
            }
            catch (Exception e)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<Employee> GetEmployee(int? id)
        {
            var g = await _context.Employee.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditEmployee(Employee Employee)
        {
            var ExistingEmployee = GetEmployee(Employee.Id);
            if (ExistingEmployee != null)
            {

                _context.Entry(Employee).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete Employee  
        public async Task EmployeeDeleteConfirmed(int id)
        {
            Employee grdn = await GetEmployee(id);
            if (grdn != null)
            {
                _context.Employee.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End Employee---------------------------------------------


        //--------------------------------Exam-------------------------------------------------------------------

        public async Task<List<Exam>> ExamIndex()
        {
            var Exam = _context.Exams.AsNoTracking();
            return await Task.FromResult((Exam.ToList()));
        }
        //Create Exam
        public async Task<Exam> CreateExam(Exam Exam)
        {
            try
            {

                _context.Exams.Add(Exam);
                _context.SaveChanges();
                return await Task.FromResult(Exam);
            }
            catch (Exception e)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<Exam> GetExam(int? id)
        {
            var g = await _context.Exams.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditExam(Exam Exam)
        {
            var ExistingExam = GetExam(Exam.Id);
            if (ExistingExam != null)
            {

                _context.Entry(Exam).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete Exam  
        public async Task ExamDeleteConfirmed(int id)
        {
            Exam grdn = await GetExam(id);
            if (grdn != null)
            {
                _context.Exams.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End Exam---------------------------------------------


        //--------------------------------ExamType-------------------------------------------------------------------

        public async Task<List<ExamType>> ExamTypeIndex()
        {
            var ExamType = _context.ExamType.AsNoTracking();
            return await Task.FromResult((ExamType.ToList()));
        }
        //Create ExamType
        public async Task<ExamType> CreateExamType(ExamType ExamType)
        {
            try
            {

                _context.ExamType.Add(ExamType);
                _context.SaveChanges();
                return await Task.FromResult(ExamType);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<ExamType> GetExamType(int? id)
        {
            var g = await _context.ExamType.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditExamType(ExamType ExamType)
        {
            var ExistingExamType = GetExamType(ExamType.Id);
            if (ExistingExamType != null)
            {

                _context.Entry(ExamType).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete ExamType  
        public async Task ExamTypeDeleteConfirmed(int id)
        {
            ExamType grdn = await GetExamType(id);
            if (grdn != null)
            {
                _context.ExamType.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End ExamType---------------------------------------------

        //--------------------------------AccountList-------------------------------------------------------------------

        public async Task<List<AccountList>> AccountListIndex()
        {
            var AccountList = _context.AccountList.AsNoTracking();
            return await Task.FromResult((AccountList.ToList()));
        }
        //Create AccountList
        public async Task<AccountList> CreateAccountList(AccountList AccountList)
        {
            try
            {

                _context.AccountList.Add(AccountList);
                _context.SaveChanges();
                return await Task.FromResult(AccountList);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<AccountList> GetAccountList(int? id)
        {
            var g = await _context.AccountList.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditAccountList(AccountList AccountList)
        {
            var ExistingAccountList = GetAccountList(AccountList.Id);
            if (ExistingAccountList != null)
            {

                _context.Entry(AccountList).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete AccountList  
        public async Task AccountListDeleteConfirmed(int id)
        {
            AccountList grdn = await GetAccountList(id);
            if (grdn != null)
            {
                _context.AccountList.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End AccountList---------------------------------------------


        //--------------------------------StudentAttendance-------------------------------------------------------------------

        public async Task<List<StudentAttendance>> StudentAttendanceIndex()
        {
            var StudentAttendance = _context.StudentAttendances.AsNoTracking();
            return await Task.FromResult((StudentAttendance.ToList()));
        }
        //Create StudentAttendance
        public async Task<StudentAttendance> CreateStudentAttendance(StudentAttendance StudentAttendance)
        {
            try
            {

                _context.StudentAttendances.Add(StudentAttendance);
                _context.SaveChanges();
                return await Task.FromResult(StudentAttendance);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<StudentAttendance> GetStudentAttendance(int? id)
        {
            var g = await _context.StudentAttendances.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditStudentAttendance(StudentAttendance StudentAttendance)
        {
            var ExistingStudentAttendance = GetStudentAttendance(StudentAttendance.Id);
            if (ExistingStudentAttendance != null)
            {

                _context.Entry(StudentAttendance).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete StudentAttendance  
        public async Task StudentAttendanceDeleteConfirmed(int id)
        {
            StudentAttendance grdn = await GetStudentAttendance(id);
            if (grdn != null)
            {
                _context.StudentAttendances.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End StudentAttendance---------------------------------------------


        //--------------------------------StaffAttendance-------------------------------------------------------------------

        public async Task<List<StaffAttendance>> StaffAttendanceIndex()
        {
            var StaffAttendance = _context.staffAttendances.AsNoTracking();
            return await Task.FromResult((StaffAttendance.ToList()));
        }
        //Create StaffAttendance
        public async Task<StaffAttendance> CreateStaffAttendance(StaffAttendance StaffAttendance)
        {
            try
            {

                _context.staffAttendances.Add(StaffAttendance);
                _context.SaveChanges();
                return await Task.FromResult(StaffAttendance);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<StaffAttendance> GetStaffAttendance(int? id)
        {
            var g = await _context.staffAttendances.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditStaffAttendance(StaffAttendance StaffAttendance)
        {
            var ExistingStaffAttendance = GetStaffAttendance(StaffAttendance.Id);
            if (ExistingStaffAttendance != null)
            {

                _context.Entry(StaffAttendance).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete StaffAttendance  
        public async Task StaffAttendanceDeleteConfirmed(int id)
        {
            StaffAttendance grdn = await GetStaffAttendance(id);
            if (grdn != null)
            {
                _context.staffAttendances.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End StaffAttendance---------------------------------------------


        //--------------------------------Session-------------------------------------------------------------------

        public async Task<List<Session>> SessionIndex()
        {
            var Session = _context.Session.AsNoTracking();
            return await Task.FromResult((Session.ToList()));
        }
        //Create Session
        public async Task<Session> CreateSession(Session Session)
        {
            try
            {

                _context.Session.Add(Session);
                _context.SaveChanges();
                return await Task.FromResult(Session);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<Session> GetSession(int? id)
        {
            var g = await _context.Session.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditSession(Session Session)
        {
            var ExistingSession = GetSession(Session.Id);
            if (ExistingSession != null)
            {

                _context.Entry(Session).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete Session  
        public async Task SessionDeleteConfirmed(int id)
        {
            Session grdn = await GetSession(id);
            if (grdn != null)
            {
                _context.Session.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End Session---------------------------------------------

        //--------------------------------Designation-------------------------------------------------------------------

        public async Task<List<Designation>> DesignationIndex()
        {
            var Designation = _context.Designation.AsNoTracking();
            return await Task.FromResult((Designation.ToList()));
        }
        //Create Designation
        public async Task<Designation> CreateDesignation(Designation Designation)
        {
            try
            {

                _context.Designation.Add(Designation);
                _context.SaveChanges();
                return await Task.FromResult(Designation);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<Designation> GetDesignation(int? id)
        {
            var g = await _context.Designation.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditDesignation(Designation Designation)
        {
            var ExistingDesignation = GetDesignation(Designation.Id);
            if (ExistingDesignation != null)
            {

                _context.Entry(Designation).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete Designation  
        public async Task DesignationDeleteConfirmed(int id)
        {
            Designation grdn = await GetDesignation(id);
            if (grdn != null)
            {
                _context.Designation.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End Designation---------------------------------------------

        //--------------------------------JobInfo-------------------------------------------------------------------

        public async Task<List<JobInfo>> JobInfoIndex()
        {
            var JobInfo = _context.JobInfo.AsNoTracking();
            return await Task.FromResult((JobInfo.ToList()));
        }
        //Create JobInfo
        public async Task<JobInfo> CreateJobInfo(JobInfo JobInfo)
        {
            try
            {

                _context.JobInfo.Add(JobInfo);
                _context.SaveChanges();
                return await Task.FromResult(JobInfo);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<JobInfo> GetJobInfo(int? id)
        {
            var g = await _context.JobInfo.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditJobInfo(JobInfo JobInfo)
        {
            var ExistingJobInfo = GetJobInfo(JobInfo.Id);
            if (ExistingJobInfo != null)
            {

                _context.Entry(JobInfo).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete JobInfo  
        public async Task JobInfoDeleteConfirmed(int id)
        {
            JobInfo grdn = await GetJobInfo(id);
            if (grdn != null)
            {
                _context.JobInfo.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End JobInfo---------------------------------------------



        //--------------------------------SchedulerEvent-------------------------------------------------------------------

        public async Task<List<SchedulerEvent>> SchedulerEventIndex()
        {
            var SchedulerEvent = _context.SchedulerEvents.AsNoTracking();
            return await Task.FromResult((SchedulerEvent.ToList()));
        }
        //Create SchedulerEvent
        public async Task<SchedulerEvent> CreateSchedulerEvent(SchedulerEvent SchedulerEvent)
        {
            try
            {

                _context.SchedulerEvents.Add(SchedulerEvent);
                _context.SaveChanges();
                return await Task.FromResult(SchedulerEvent);
            }
            catch (Exception)
            {
                DetachAllEntities();
                throw;
            }
        }

        public async Task<SchedulerEvent> GetSchedulerEvent(int? id)
        {
            var g = await _context.SchedulerEvents.AsNoTracking().Where(n => n.Id == id).FirstOrDefaultAsync();
            return g;
        }

        public Task<bool> EditSchedulerEvent(SchedulerEvent SchedulerEvent)
        {
            var ExistingSchedulerEvent = GetSchedulerEvent(SchedulerEvent.Id);
            if (ExistingSchedulerEvent != null)
            {

                _context.Entry(SchedulerEvent).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        //Delete SchedulerEvent  
        public async Task SchedulerEventDeleteConfirmed(int id)
        {
            SchedulerEvent grdn = await GetSchedulerEvent(id);
            if (grdn != null)
            {
                _context.SchedulerEvents.Remove(grdn);
                _context.SaveChanges();
            }


        }

        //---------------------------------End SchedulerEvent---------------------------------------------

        #region 
        public void DetachAllEntities()
        { // When we have an error, we need 
            // to remove EF Core change tracking. 
            var changedEntriesCopy = _context.ChangeTracker.Entries() 
                .Where(e => e.State == EntityState.Added 
                || e.State == EntityState.Modified 
                || e.State == EntityState.Deleted) .ToList();
            foreach (var entry in changedEntriesCopy)
            {
                entry.State = EntityState.Detached;
            }
        }
        #endregion
    }
}

