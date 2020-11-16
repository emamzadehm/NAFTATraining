﻿using _01.Framework.Application;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using NT.CM.Domain;
using NT.CM.Domain.CourseInstructorAgg;
using System.Collections.Generic;

namespace NT.CM.Application
{
    public class CourseInstructorApplication : ICourseInstructorApplication
    {
        private readonly ICourseInstructorRepository _icourseInstructorRepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;

        public CourseInstructorApplication(ICourseInstructorRepository icourseInstructorRepository, IUnitOfWorkNT IUnitOfWorkNT)
        {
            _icourseInstructorRepository = icourseInstructorRepository;
            _IUnitOfWorkNT = IUnitOfWorkNT;
        }

        public OperationResult Create(CourseInstructorViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new CourseInstructor(command.CourseID, command.InstructorID, command.SDate, command.EDate, command.Capacity, command.Venue, command.Location);
            _icourseInstructorRepository.Create(NewItem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(CourseInstructorViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _icourseInstructorRepository.GetBy(command.ID);
            SelectedItem.Edit(command.CourseID, command.InstructorID, command.SDate, command.EDate, command.Capacity, command.Venue, command.Location);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Remove(long id)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _icourseInstructorRepository.GetBy(id);
            SelectedItem.Remove();
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public CourseInstructorViewModel GetBy(long id)
        {
            var SelectedItem = _icourseInstructorRepository.GetBy(id);
            var result = new CourseInstructorViewModel
            {
                ID = SelectedItem.ID,
                CourseID=SelectedItem.CourseID,
                CourseName=SelectedItem.Course.CName,
                InstructorID=SelectedItem.InstructorID,
                //InstructorName=SelectedItem.Instructor.FirstName + " " + SelectedItem.Instructor.LastName,
                SDate=SelectedItem.SDate,
                EDate=SelectedItem.EDate,
                Capacity=SelectedItem.Capacity,
                Venue=SelectedItem.Venue,
                Location = SelectedItem.Location,
                LocationName = SelectedItem.BaseInfo.Title
            };
            return result;
        }

        public List<CourseInstructorViewModel> Search(CourseInstructorViewModel searchmodel)
        {
            return _icourseInstructorRepository.Search(searchmodel);
        }
    }
}
