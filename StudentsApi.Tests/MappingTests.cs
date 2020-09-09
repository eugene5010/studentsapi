using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using StudentsApi.Data.Models;
using StudentsApi.Data.Profiles;
using StudentsApi.Features.GetManyStudents;
using StudentsApi.Models;
using Student = StudentsApi.Data.Models.Student;

namespace StudentsApi.Tests
{
    public class MappingTests
    {
        private AutoMapper.IMapper mapper;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.AddProfiles(new[] { new StudentProfile() }));
            mapperConfiguration.CompileMappings();
            mapperConfiguration.AssertConfigurationIsValid();
            mapper = mapperConfiguration.CreateMapper();
        }

        [Test]
        public void MapDataModelToApi_AllProperties_ShouldSuccess()
        {
            //arrange
            var target = new Student()
            {
                Code = "123",
                Firstname = "John",
                Patronymic = "Robert",
                Lastname = "Doe",
                Sex = "Female",
                StudentGroups = new List<StudentGroups>()
                {
                    new StudentGroups()
                    {
                        Group = new Data.Models.Group()
                        {
                            Name = "Group1"
                        }
                    },
                    new StudentGroups()
                    {
                        Group = new Data.Models.Group()
                        {
                            Name = "Group2"
                        }
                    }

                }
            };
            //act
            var actual = mapper.Map<Features.GetManyStudents.Student>(target);

            //assert
            actual.Should().BeEquivalentTo(
                new Features.GetManyStudents.Student()
                {
                    Lastname = target.Lastname,
                    Sex = Sex.Female,
                    Firstname = target.Firstname,
                    Patronymic = target.Patronymic,
                    Code = target.Code,
                    StudentGroups = "Group1,Group2"
                });
        }
    }
}