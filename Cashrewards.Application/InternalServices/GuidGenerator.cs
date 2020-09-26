using System;

namespace Cashrewards.Application.InternalServices
{
    public class GuidGenerator : IGuidGenerator
    {
        public string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
