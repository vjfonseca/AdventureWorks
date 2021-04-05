using System.Collections.Generic;

namespace AdventureWorks.Data
{
    public interface IPersonRepo
    {
        public Person Get(int id);
    }
}
