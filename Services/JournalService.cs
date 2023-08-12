﻿using AutoMapper;
using Common.Dtos;
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
            var userJournalId = Guid.NewGuid();

            journal.Id = journalId;
            journal.UserJournalId = userJournalId;
            journal.OwnerId= journal.OwnerId;

            var result = _journalRepo.CreateJournal(journal);

            if (result.Success)
            {
                return result;
            }

            return result;
        }

        public JournalDto GetJournal(Guid journalId)
        {
            throw new NotImplementedException();
        }
    }
}
