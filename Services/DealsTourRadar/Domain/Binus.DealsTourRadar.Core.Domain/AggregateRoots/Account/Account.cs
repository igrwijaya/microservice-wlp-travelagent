using System.Collections.Generic;
using Binus.DealsTourRadar.Core.Domain.AggregateRoots.Post;
using Binus.DealsTourRadar.Core.Domain.Commons;

namespace Binus.DealsTourRadar.Core.Domain.AggregateRoots.Account
{
    public class Account : CoreEntity, IAggregateRoot
    {
        #region Constructors

        public Account(string name)
        {
            Name = name;
        }

        #endregion

        #region Entity Properties

        public string Name { get; private set; }

        #endregion

        #region Entity Relation Properties

        public IEnumerable<Post.Post> Posts { get; set; }
        
        public IEnumerable<Comment> Comments { get; set; }

        #endregion
        
    }
}