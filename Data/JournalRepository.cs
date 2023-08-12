using AutoMapper;
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
            journalToCreate.UserJournalId = journal.UserJournalId;

            var userJournalMap = new UserJournal();
            userJournalMap.Id = journal.UserJournalId;
            userJournalMap.OwnerId = journal.OwnerId;
            userJournalMap.JournalId = journal.Id;


            _context.Journals.Add(journalToCreate);
            _context.UserJournals.Add(userJournalMap);

            _context.SaveChanges();

            //UPDATE
            return new ResultDto() { Success = true };
        }

        public JournalDto GetJournal(Guid journalId)
        {
            throw new NotImplementedException();
        }
    }
}
