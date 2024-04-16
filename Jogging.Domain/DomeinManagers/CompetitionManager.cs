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

    public async Task<PagedList<CompetitionResponseDOM>> GetAll(QueryStringParameters parameters)
    {
        var competitions = await _competitionRepo.GetAllAsync();
        var competitionsDto = competitions.Select(competition => _mapper.Map<CompetitionResponseDOM>(competition));
        return PagedList<CompetitionResponseDOM>.ToPagedList(competitionsDto, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<CompetitionResponseDOM> AddAsync(CompetitionRequestDOM competitionRequest)
    {
        var response = await _competitionRepo.AddAsync(_mapper.Map<Competition>(competitionRequest));
        return _mapper.Map<CompetitionResponseDOM>(response);
    }

    public async Task<CompetitionResponseDOM> GetById(int id)
    {
        var response = await _competitionRepo.GetByIdAsync(id);
        return _mapper.Map<CompetitionResponseDOM>(response);
    }

    public async Task<CompetitionResponseDOM> UpdateAsync(int id, CompetitionRequestDOM competitionRequest)
    {
        var response =  await _competitionRepo.UpdateAsync(id, _mapper.Map<Competition>(competitionRequest));
        return _mapper.Map<CompetitionResponseDOM>(response);
    }

    public async Task DeleteAsync(int competitionId)
    {
        await _competitionRepo.DeleteAsync(competitionId);
    }
}