using System;

namespace Metron
{
    public abstract class Model
    {
        protected Model()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
        }
        
        public Guid Id { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }
    }
}