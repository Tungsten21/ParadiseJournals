using Common.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IJournalRepository
    {
        ResultDto CreateJournal(JournalDto journal);

        JournalDto GetJournal(Guid journalId);

        IQueryable<JournalDto>? GetJournals(Guid userId);
    }
}
