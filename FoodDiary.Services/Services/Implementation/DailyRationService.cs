using AutoMapper;
using FoodDiary.Entities.Models;
using FoodDiary.Repository;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;

namespace FoodDiary.Services.Implementation;

public class DailyRationService : IDailyRationService
{
    private readonly IRepository<Entities.Models.DailyRation> dailyRationsRepository;
    private readonly IMapper mapper;
    public DailyRationService(IRepository<Entities.Models.DailyRation> dailyRationsRepository, IMapper mapper)
    {
        this.dailyRationsRepository = dailyRationsRepository;
        this.mapper = mapper;
    }

    public void DeleteDailyRation(Guid id)
    {
        var dailyRationToDelete = dailyRationsRepository.GetById(id);
        if (dailyRationToDelete == null)
        {
            throw new Exception("Daily ration not found");
        }

        dailyRationsRepository.Delete(dailyRationToDelete);
    }

    public DailyRationModel GetDailyRation(Guid id)
    {
        var dailyRation = dailyRationsRepository.GetById(id);
        return mapper.Map<DailyRationModel>(dailyRation);
    }

    public PageModel<DailyRationPreviewModel> GetDailyRations(int limit = 20, int offset = 0)
    {
        var dailyRations = dailyRationsRepository.GetAll();
        int totalCount = dailyRations.Count();
        var chunk = dailyRations.OrderBy(x => x.Date).Skip(offset).Take(limit);

        return new PageModel<DailyRationPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<DailyRationPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public DailyRationModel UpdateDailyRation(Guid id, UpdateDailyRationModel dailyRation)
    {
        var existingDailyRation = dailyRationsRepository.GetById(id);
        if (existingDailyRation == null)
        {
            throw new Exception("Daily ration not found");
        }

        existingDailyRation.Date = dailyRation.Date;

        existingDailyRation = dailyRationsRepository.Save(existingDailyRation);
        return mapper.Map<DailyRationModel>(existingDailyRation);
    }


   public CreateDailyRationModel AddDailyRation(Guid UserId, DailyRationModel dailyRation)
   {
        if(dailyRationsRepository.GetAll(x => x.Id == dailyRation.Id).FirstOrDefault() != null)
        {
            throw new Exception ("Attempt to create a non-unique object!");
        }

        CreateDailyRationModel dailyRationModel = new CreateDailyRationModel();

        dailyRationModel.UserId = dailyRation.UserId;
        dailyRationModel.Date = dailyRation.Date;

        dailyRationsRepository.Save(mapper.Map<Entities.Models.DailyRation>(dailyRationModel));
        return dailyRationModel;
    }
}