using AutoMapper;
using Jogging.Contracts.Interfaces.RepoInterfaces;
using Jogging.Domain.Helpers;
using Jogging.Domain.Models;
using Jogging.Infrastructure.Models;

namespace Jogging.Domain.DomeinControllers;

public class CompetitionManager
{
    private readonly IGenericRepo<Competition> _competitionRepo;
    private readonly IMapper _mapper;
    public CompetitionManager(IGenericRepo<Competition> competitionRepo, IMapper mapper)
    {
        _mapper = mapper;
        _competitionRepo = competitionRepo;
    }

    public async Task<PagedList<CompetitionDOM>> GetAll(QueryStringParameters parameters)
    {
        var competitions = await _competitionRepo.GetAllAsync();
        var competitionsDto = competitions.Select(competition => _mapper.Map<CompetitionDOM>(competition));
        return PagedList<CompetitionDOM>.ToPagedList(competitionsDto, parameters.PageNumber, parameters.PageSize);
    }

    public object GetById(int id)
    {
        throw new NotImplementedException();
    }
}