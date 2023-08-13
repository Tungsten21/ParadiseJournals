﻿using AutoMapper;
using Common.Dtos;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class JournalRepository : IJournalRepository
    {
        private IMapper _mapper;
        private ApplicationDbContext _context;

        public JournalRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public ResultDto CreateJournal(JournalDto journal)
        {
            var journalToCreate = _mapper.Map<Journal>(journal);
            journalToCreate.OwnerId = journal.OwnerId;

            var journalDays = new List<JournalDay>();

            for (DateTime beginDate = journal.StartDate; beginDate <= journal.EndDate; beginDate = beginDate.AddDays(1))
            {
                var journalDay = new JournalDay() { ShortDateFormat = beginDate.ToShortDateString(), JournalId = journal.Id };
                journalDays.Add(journalDay);
            }

            _context.Journals.Add(journalToCreate);
            _context.JournalDays.AddRange(journalDays);

            _context.SaveChanges();


            //UPDATE
            return new ResultDto() { Id = journal.Id, Success = true };
        }

        public JournalDto GetJournal(Guid journalId)
        {
            var result = new JournalDto();

            var journal = _context.Journals.FirstOrDefault(x => x.Id == journalId);
            var journalDays = _context.JournalDays.Where(x => x.JournalId == journalId);

            if(journal != null && journalDays != null)
            {
                journal.JournalDays = journalDays;
                result = _mapper.Map<JournalDto>(journal);
            }

            return result;
        }
    }
}
