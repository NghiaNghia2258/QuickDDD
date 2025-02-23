﻿using WebApi.BLL.Mapper.SchoolClasses;
using WebApi.BLL.Mapper.Subjects;

namespace WebApi.BLL.Mapper.Teachers;

public class GetByIdTeacherDto: GetAllTeacherDto
{
    public int UserLoginId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedName { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public string? UpdatedName { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public string? DeletedName { get; set; }
    public int Version { get; set; }
    public IEnumerable<GetAllSchoolClassDto> SchoolClasses { get; set; }
    public IEnumerable<GetAllSubjectDto> Subjects { get; set; }
}
