using IdGen;
using Samat.Framework.Domain;

namespace Samat.Framework.Utilities.IdGenerators
{
    internal class SnowflakeIdGenerator : IIdGenerator
    {
        private readonly IdGenerator _idGenerator;

        public SnowflakeIdGenerator(IdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public long GetNewId()
        {
            return _idGenerator.CreateId();
        }
    }
}