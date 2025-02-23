﻿using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.SchoolClasses;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Services;

public class SchoolClassService : ServiceBase, ISchoolClassService
{
    public SchoolClassService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    public async Task<IEnumerable<GetAllSchoolClassDto>> GetAll(OptionFilterSchoolClass option)
    {
        IEnumerable<SchoolClass> schoolClasses = await _unitOfWork.SchoolClass.GetAll(option);
        return _mapper.Map<IEnumerable<GetAllSchoolClassDto>>(schoolClasses);
    }
    public async Task<GetByIdSchoolClassDto> GetById(int id)
    {
        SchoolClass schoolClass = await _unitOfWork.SchoolClass.GetById(id);
        return _mapper.Map<GetByIdSchoolClassDto>(schoolClass);
    }
    public async Task<bool> Update(GetByIdSchoolClassDto model)
    {
        SchoolClass schoolClass = _mapper.Map<SchoolClass>(model);
        await _unitOfWork.SchoolClass.Update(schoolClass);  
        return true;
    }
    public async Task<bool> Delete(int id)
    {
        await _unitOfWork.SchoolClass.Delete(id);
        return true;
    }
    public async Task AddStudentsToClass(AddStudentsToClassDto model)
    {
        SchoolClass schoolClass = await _unitOfWork.SchoolClass.GetById(model.SchoolClassId);
        if(schoolClass == null)
        {
            return;
        }
        if(schoolClass.AvailableSlots < model.StudentIds.Count())
        {
            throw new Exception("Không đủ slot");
        }
        foreach (var item in model.StudentIds)
        {
            await _unitOfWork.SchoolClassesStudent.Create(new SchoolClassStudent()
            {
                StudentsId = item,
                SchoolClassesId = schoolClass.Id
            });
            schoolClass.AvailableSlots--;
            schoolClass.IsAvailableSlot = schoolClass.AvailableSlots > 0;
        }
        await _unitOfWork.SchoolClass.Update(schoolClass);
    }
    public async Task RemoveStudentFromClass(int studentId, int schoolClassId)
    {
        SchoolClass schoolClass = await _unitOfWork.SchoolClass.GetById(studentId);
        schoolClass.AvailableSlots++;
        schoolClass.IsAvailableSlot = true;
        await _unitOfWork.SchoolClassesStudent.Delete(studentId, schoolClassId);
    }
    public async Task AddTeachersToClass(AddTeachersToClassDto model)
    {
        SchoolClass schoolClass = await _unitOfWork.SchoolClass.GetById(model.SchoolClassId);
        foreach (var teacherDto in model.Teachers)
        {
            if(schoolClass.SchoolClassTeacherSubject.Any(x => x.SubjectId == teacherDto.SubjectId))
            {
                throw new Exception("Đã có GV dạy môn này ");
            }
            schoolClass.UpdatedAt = DateTime.Now;
            schoolClass.SchoolClassTeacherSubject.Add(new()
            {
                SubjectId = teacherDto.SubjectId,
                TeacherId = teacherDto.TeacherId,
            });
        }
        await _unitOfWork.SchoolClass.Update(schoolClass);
    }
    public async Task RemoveTeacher(int schoolClassId, int teacherId, int subjectId)
    {
        await _unitOfWork.SchoolClass.RemoveeacherSubject(schoolClassId,teacherId,subjectId);
    }
}
