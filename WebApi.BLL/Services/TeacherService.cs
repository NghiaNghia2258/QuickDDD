﻿using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Teachers;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Const;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Mapper.Identity;

namespace WebApi.BLL.Services;

public class TeacherService : ServiceBase, ITeacherService
{
    public TeacherService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    public async Task<bool> Create(CreateTeacherDto model)
    {
        Teacher newTeacher = _mapper.Map<Teacher>(model);

        Faculty isExistFaculty = await _unitOfWork.Faculty.GetById(newTeacher.FacultyId);
        if (isExistFaculty == null)
        {
            return false;
        }
        int ordinal = await _unitOfWork.Teacher.GetOrdinalNumberOfCurrentYear();
        newTeacher.Code = $"{isExistFaculty.Code}_{TimeConst.CurrentYear}_{ordinal:D3}";
        foreach (int subjectId in model.SubjectIds)
        {
            Subject subject = await _unitOfWork.Subject.GetById(subjectId);
            if(subject != null) { 
                newTeacher.Subjects.Add(subject);
            }
        }

        RoleGroup roleTeacher = await _unitOfWork.Identity.GetRoleGroupByCode("TEACHER");

        UserLogin newUser = new UserLogin()
        {
            Username = newTeacher.Code,
            Password = newTeacher.Code,
            RoleGroupId = roleTeacher.Id
        };

        newTeacher.UserLogin = newUser;
        await _unitOfWork.Teacher.Create(newTeacher);

        return true;
    }
    public async Task<List<GetAllTeacherDto>> GetAll(OptionFilterTeacher option)
    {
        List<Teacher> teachers = await _unitOfWork.Teacher.GetAll(option);
        return _mapper.Map<List<GetAllTeacherDto>>(teachers);
    }
    public async Task<GetByIdTeacherDto> GetById(int id)
    {
        Teacher teacher = await _unitOfWork.Teacher.GetById(id);
        return _mapper.Map<GetByIdTeacherDto>(teacher);
    }
    public async Task<bool> Delete(int id)
    {
        await _unitOfWork.Teacher.Delete(id);
        return true;
    }
    public async Task<bool> Update(GetByIdTeacherDto model)
    {
        Teacher teacher = _mapper.Map<Teacher>(model);
        await _unitOfWork.Teacher.Update(teacher);
        return true;
    }
}
