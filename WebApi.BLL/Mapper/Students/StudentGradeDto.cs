﻿namespace WebApi.BLL.Mapper.Students;

public class StudentGradeDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string? StudentCode { get; set; }
    public string? StudentName { get; set; }
    public int SubjectId { get; set; }
    public string? SubjectName { get; set; }
    public double PracticalGrade { get; set; }
    public double HomeworkGrade { get; set; }
    public double ExamGrade { get; set; }
    public double AttendanceGrade { get; set; }
    public int? Status { get; set; }
    public int Version { get; set; }
}
