using Domain;
using MediatR;
using Persistence;

namespace Application.Activities;

public class Update
{
    public class Command : IRequest
    {
        public Activity Activity { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _dataContext;

        public Handler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            Activity activityFromDbToUpdate = await _dataContext.Activities.FindAsync(request.Activity.Id);

            activityFromDbToUpdate.Title = request.Activity.Title ?? activityFromDbToUpdate.Title;
            activityFromDbToUpdate.Date = request.Activity.Date;
            activityFromDbToUpdate.Description = request.Activity.Description ?? activityFromDbToUpdate.Description;
            activityFromDbToUpdate.Category = request.Activity.Category ?? activityFromDbToUpdate.Category;
            activityFromDbToUpdate.City = request.Activity.City ?? activityFromDbToUpdate.City;
            activityFromDbToUpdate.Venue = request.Activity.City ?? activityFromDbToUpdate.Venue;

            await _dataContext.SaveChangesAsync();
        }
    }
}