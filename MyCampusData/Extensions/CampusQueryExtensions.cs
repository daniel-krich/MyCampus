using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCampusData.Data;
using MyCampusData.Entities;
using MyCampusData.Models;

namespace MyCampusData.Extensions
{
    public static class CampusQueryExtensions
    {
        public static async Task<long> GetStudentAssignmentCountAsync(this CampusContext ctx, Guid studentId)
        {
            return await (from userClass in ctx.UserClasses
                          join classEntity in ctx.Classes on userClass.ClassId equals classEntity.Id
                          join assignment in ctx.ClassAssignments on classEntity.Id equals assignment.ClassId
                          where userClass.StudentId == studentId
                          select assignment.Id).ToAsyncEnumerable().LongCountAsync();
        }

        public static async Task<List<StudentAssignmentModel>> GetStudentAssignmentsPaginationAsync(this CampusContext ctx, Guid studentId, int pageId, int assignmentsPerPage)
        {
            return await (from userClass in ctx.UserClasses
                          join classEntity in ctx.Classes on userClass.ClassId equals classEntity.Id
                          join course in ctx.Courses on classEntity.CourseId equals course.Id
                          join assignment in ctx.ClassAssignments on classEntity.Id equals assignment.ClassId
                          join assignmentSub in ctx.ClassAssignmentSubmissions
                                 on new { p1 = studentId, p2 = assignment.Id }
                                 equals new { p1 = assignmentSub.StudentId, p2 = assignmentSub.AssignmentId } into assignmentsSubmissions
                          from assignmentSubDefault in assignmentsSubmissions.DefaultIfEmpty()
                          where userClass.StudentId == studentId
                          orderby assignment.CreatedAt descending
                          select new StudentAssignmentModel { Class = classEntity, Assignment = assignment, Course = course, AssignmentSubmission = assignmentSubDefault })
                                                .Skip((pageId - 1) * assignmentsPerPage).Take(assignmentsPerPage).ToAsyncEnumerable().ToListAsync();
        }

        public static async Task<long> GetClassAssignmentsCountAsync(this CampusContext ctx, Guid classId)
        {
            return await (from classEntity in ctx.Classes
                          join assignment in ctx.ClassAssignments on classEntity.Id equals assignment.ClassId
                          where assignment.ClassId == classId
                          select assignment.Id).ToAsyncEnumerable().LongCountAsync();
        }

        public static async Task<List<ClassAssignmentModel>> GetClassAssignmentsPaginationAsync(this CampusContext ctx, Guid classId, int pageId, int assignmentsPerPage)
        {
            return await (from classEntity in ctx.Classes
                          join assignment in ctx.ClassAssignments on classEntity.Id equals assignment.ClassId
                          where assignment.ClassId == classId
                          orderby assignment.CreatedAt descending
                          select new ClassAssignmentModel { Assignment = assignment, AssignmentSubmissions = assignment.AssignmentSubmissions.LongCount() }).Skip((pageId - 1) * assignmentsPerPage).Take(assignmentsPerPage).ToAsyncEnumerable().ToListAsync();
        }

        public static async Task<long> GetStudentMeetingCountAsync(this CampusContext ctx, Guid studentId)
        {
            return await (from userClass in ctx.UserClasses
                          join classEntity in ctx.Classes on userClass.ClassId equals classEntity.Id
                          join meeting in ctx.ClassMeetings on classEntity.Id equals meeting.ClassId
                          where userClass.StudentId == studentId
                          select meeting.Id).ToAsyncEnumerable().LongCountAsync();
        }

        public static async Task<List<MeetingModel>> GetStudentMeetingsPaginationAsync(this CampusContext ctx, Guid studentId, int pageId, int meetingsPerPage)
        {
            return await (from userClass in ctx.UserClasses
                          join classEntity in ctx.Classes on userClass.ClassId equals classEntity.Id
                          join meeting in ctx.ClassMeetings on classEntity.Id equals meeting.ClassId
                          join course in ctx.Courses on classEntity.CourseId equals course.Id
                          where userClass.StudentId == studentId
                          orderby meeting.StartAt descending
                          select new MeetingModel { Class = classEntity, Course = course, Meeting = meeting, Lecturer = meeting.Lecturer})
                          .Skip((pageId - 1) * meetingsPerPage).Take(meetingsPerPage).ToAsyncEnumerable().ToListAsync();
        }

        public static async Task<long> GetLecturerClassesCountAsync(this CampusContext ctx, Guid lecturerId)
        {
            return await (from classEntity in ctx.Classes
                          where classEntity.LecturerId == lecturerId
                          select classEntity.Id).ToAsyncEnumerable().LongCountAsync();
        }

        public static async Task<List<ClassModel>> GetLecturerClassesPaginationAsync(this CampusContext ctx, Guid lecturerId, int pageId, int classesPerPage)
        {
            return await (from classEntity in ctx.Classes
                          join course in ctx.Courses on classEntity.CourseId equals course.Id
                          where classEntity.LecturerId == lecturerId
                          select new ClassModel { Class = classEntity, Course = course, Lecturer = classEntity.Lecturer })
                          .Skip((pageId - 1) * classesPerPage).Take(classesPerPage).ToAsyncEnumerable().ToListAsync();
        }
    }
}
