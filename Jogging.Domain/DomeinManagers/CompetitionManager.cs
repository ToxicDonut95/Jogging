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

    public async Task<CompetitionDOM> AddAsync(CompetitionDOM competition)
    {
        var response = await _competitionRepo.AddAsync(_mapper.Map<Competition>(competition));
        return _mapper.Map<CompetitionDOM>(response);
    }

    public async Task<CompetitionDOM> GetById(int id)
    {
        var response = await _competitionRepo.GetByIdAsync(id);
        return _mapper.Map<CompetitionDOM>(response);
    }
}