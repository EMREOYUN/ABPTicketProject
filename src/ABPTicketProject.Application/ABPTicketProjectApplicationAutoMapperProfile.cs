using AutoMapper;
using ABPTicketProject.Events;

namespace ABPTicketProject;

public class ABPTicketProjectApplicationAutoMapperProfile : Profile
{
    public ABPTicketProjectApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Event, EventDto>();
        CreateMap<CreateUpdateEventDto, Event>();
        CreateMap<PurchasedTicket, PurchasedTicketDto>();
    }
}
