using ABPTicketProject.Samples;
using Xunit;

namespace ABPTicketProject.MongoDB.Domains;

[Collection(ABPTicketProjectTestConsts.CollectionDefinitionName)]
public class MongoDBSampleDomainTests : SampleDomainTests<ABPTicketProjectMongoDbTestModule>
{

}
