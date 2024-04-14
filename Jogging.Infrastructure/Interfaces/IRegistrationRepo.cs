﻿using Jogging.Infrastructure.Models;

namespace Jogging.Infrastructure.Interfaces
{
    public interface IRegistrationRepo
    {
        public Task<Registration> SigninToContestAsync(Registration registration, int personId);

        public Task<List<CompetitionPerCategory>> GetRegisteredCompetionsOfPerson(int personId);
    }
}