using System;
using Volo.Abp.Application.Dtos;

namespace ABPTicketProject.Events;

public class EventDto : AuditedEntityDto<Guid>
{
    public string name { get; set; }
    public bool ageRestriction { get; set; }
    public double price { get; set; }
    public DateTime date { get; set; }
    public string location { get; set; }
    public string description { get; set; }
    public string imageURL { get; set; }
    public int quota { get; set; }
    public int userQuota { get; set; }
    public bool active { get; set; }
}