﻿
using Entities.Models;

namespace Contract
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid ownerId);

        Owner GetOwnerWithDetails(Guid ownerId);

        void CreateOwner(Owner owner);

        void DeleteOwner(Owner owner);
    }
}