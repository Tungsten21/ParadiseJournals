using AutoMapper;
using Common.Dtos;
using Data.Entities;
using Data.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class JournalService : IJournalService
    {
        private IMapper _mapper;
        private IJournalRepository _journalRepo;

        public JournalService(IMapper mapper, IJournalRepository journalRepository)
        {
            _mapper = mapper;
            _journalRepo = journalRepository;
        }

        public ResultDto CreateJournal(JournalDto journal)
        {
            var journalId = Guid.NewGuid();

            journal.Id = journalId;

            var result = _journalRepo.CreateJournal(journal);

            if (!result.Success)
            {
                result.Message = "Error creating journal: Journal not created.";
            }

            return result;
        }

        public JournalDto GetJournal(Guid journalId)
        {
            return _journalRepo.GetJournal(journalId);
        }

        public ResultDto GetJournals(Guid userId)
        {
            var result = new ResultDto();
    
            var journals = _journalRepo.GetJournals(userId);

            if(journals.Any())
            {
                result.Success = true;
                result.Items = journals.ToList<object>();
            }
            else
            {
                result.Message = "Error creating journal: Journal not created.";
            }

            return result;
        }
    }
}
