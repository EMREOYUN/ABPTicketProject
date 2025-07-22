using ABPTicketProject.MongoDB;
using ABPTicketProject.Samples;
using Xunit;

namespace ABPTicketProject.MongoDb.Applications;

[Collection(ABPTicketProjectTestConsts.CollectionDefinitionName)]
public class MongoDBSampleAppServiceTests : SampleAppServiceTests<ABPTicketProjectMongoDbTestModule>
{

}
