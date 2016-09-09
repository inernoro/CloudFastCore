using Cloud.EntityFrameworkCore;

namespace Cloud.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly CloudDbContext _context;

        public TestDataBuilder(CloudDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}