using AutoMapper;
using Common.Dtos;
using Data.Entities;
using Data.Interfaces;
using Moq;
using Services;
using Services.Interfaces;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services
{
    [TestClass()]
    public class JournalServiceTests
    {
        private IJournalService _journalService;
        private IMapper _mapper;
        private Mock<IJournalRepository> _journalRepository;

        [TestInitialize]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceProfiles>();
            });

            _mapper = new Mapper(mapperConfig);
            _journalRepository = new();
            _journalService = new JournalService(_mapper, _journalRepository.Object);
        }

        //Create Test

        [TestMethod]
        public void GetJournalWithValidIdShouldReturnHydratedJournalDto()
        {
            //Arrange
            var journalId = Guid.NewGuid();    
            var ownerId = Guid.NewGuid();
            var title = "Test Journal";
            var country = "Sweden";
            var city = "Stockholm";
            var startDate = DateTime.Parse("21/06/23");
            var endDate = DateTime.Parse("24/06/23");
            var totalDays = 4;


            var expectedJournal = new JournalDto()
            {
                Id = journalId,
                OwnerId = ownerId,
                Title = title,
                Country = country,
                City = city,
                StartDate = startDate,
                EndDate = endDate,
                TotalDays = totalDays,
                JournalDays = new() { new JournalDayDto(), new JournalDayDto(), new JournalDayDto(), new JournalDayDto() }
            };

            _journalRepository.Setup(x => x.GetJournal(journalId)).Returns(expectedJournal);

            //Act
            var result = _journalService.GetJournal(journalId);

            //Assert
            _journalRepository.Verify(x => x.GetJournal(journalId));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id.Equals(journalId));
            Assert.IsTrue(result.OwnerId.Equals(ownerId));
            Assert.IsTrue(result.Title.Equals(title));
            Assert.IsTrue(result.Country.Equals(country));
            Assert.IsTrue(result.City.Equals(city));
            Assert.IsTrue(result.StartDate.Equals(startDate));
            Assert.IsTrue(result.EndDate.Equals(endDate));
            Assert.IsTrue(result.TotalDays.Equals(totalDays));
            Assert.IsTrue(result.JournalDays.Count == 4);
        }

        [TestMethod]
        public void GetJournalWithDeletedIdShouldReturnEmptyDto()
        {
            //Arrange
            var journalId = Guid.NewGuid();
            _journalRepository.Setup(x => x.GetJournal(journalId)).Returns(new JournalDto());

            //Act
            var result = _journalService.GetJournal(journalId);

            //Assert
            _journalRepository.Verify(x => x.GetJournal(journalId));
            Assert.IsTrue(result.Id == Guid.Empty);
        }

        [TestMethod]
        public void GetJournalsWithExistingJournalsShouldReturnHydratedResultDto()
        {
            //Arrange
            var ownerId = Guid.NewGuid();

            var journalId1 = Guid.NewGuid();
            var title1 = "Test Journal";
            var country1 = "Sweden";
            var city1 = "Stockholm";
            var startDate1 = DateTime.Parse("21/06/23");
            var endDate1 = DateTime.Parse("24/06/23");
            var totalDays1 = 4;

            var journalId2 = Guid.NewGuid();
            var title2 = "Test Journal 2";
            var country2 = "Germany";
            var city2 = "Berlin";
            var startDate2 = DateTime.Parse("05/02/22");
            var endDate2 = DateTime.Parse("07/02/22");
            var totalDays2 = 3;


            var expectedJournal1 = new JournalDto()
            {
                Id = journalId1,
                OwnerId = ownerId,
                Title = title1,
                Country = country1,
                City = city1,
                StartDate = startDate1,
                EndDate = endDate1,
                TotalDays = totalDays1,
                JournalDays = new() { new JournalDayDto(), new JournalDayDto(), new JournalDayDto(), new JournalDayDto() }
            };

            var expectedJournal2 = new JournalDto()
            {
                Id = journalId2,
                OwnerId = ownerId,
                Title = title2,
                Country = country2,
                City = city2,
                StartDate = startDate2,
                EndDate = endDate2,
                TotalDays = totalDays2,
                JournalDays = new() { new JournalDayDto(), new JournalDayDto(), new JournalDayDto() }
            };

            _journalRepository.Setup(x => x.GetJournals(ownerId)).Returns(
                new List<JournalDto>() { expectedJournal1, expectedJournal2}.AsQueryable
                );

            //Act
            var result = _journalService.GetJournals(ownerId);

            //Assert
            _journalRepository.Verify(x => x.GetJournals(ownerId));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Items.Count == 2);

            var journals = result.Items.Cast<JournalDto>().ToList();

            Assert.IsTrue(journals[0].Id == journalId1);
            Assert.IsTrue(journals[0].OwnerId == ownerId);
            Assert.IsTrue(journals[0].Title == title1);
            Assert.IsTrue(journals[0].Country == country1);
            Assert.IsTrue(journals[0].City == city1);
            Assert.IsTrue(journals[0].StartDate == startDate1);
            Assert.IsTrue(journals[0].EndDate == endDate1);
            Assert.IsTrue(journals[0].TotalDays == totalDays1);
            Assert.IsTrue(journals[0].JournalDays.Count == 4);

            Assert.IsTrue(journals[1].Id == journalId2);
            Assert.IsTrue(journals[1].OwnerId == ownerId);
            Assert.IsTrue(journals[1].Title == title2);
            Assert.IsTrue(journals[1].Country == country2);
            Assert.IsTrue(journals[1].City == city2);
            Assert.IsTrue(journals[1].StartDate == startDate2);
            Assert.IsTrue(journals[1].EndDate == endDate2);
            Assert.IsTrue(journals[1].TotalDays == totalDays2);
            Assert.IsTrue(journals[1].JournalDays.Count == 3);

        }

        [TestMethod]
        public void GetJournalsWithNoExistingJournalsShouldReturnEmptyResultDto()
        {
            //Arrange
            var ownerId = Guid.NewGuid();

            //Act
            var result = _journalService.GetJournals(ownerId);

            //Assert
            _journalRepository.Verify(x => x.GetJournals(ownerId));
            Assert.IsTrue(result.Id == Guid.Empty);
            Assert.IsTrue(result.Success == false);
        }
    }
}
