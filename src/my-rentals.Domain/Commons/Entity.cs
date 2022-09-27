using LanguageExt.Common;
using System;

namespace my_rental.Domain.Commons
{
    public class Entity<T>
    {
        public Guid Id { get; protected set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public Result<T> OperationResult;

        public bool IsSuccess => OperationResult.IsSuccess;

        public Entity()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
        }
    }
}
