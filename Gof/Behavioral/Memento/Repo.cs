using System;
using System.Collections.Generic;
using System.Linq;

namespace Gof.Behavioral.Memento
{
    public class Repo
    {
        private readonly Resource _resource;
        private readonly IList<Commit> _history = new List<Commit>();

        public Repo(Resource resource) => _resource = resource;

        public Guid Commit(string description)
        {
            var commit = new Commit(description, _resource.Content);
            _history.Add(commit);
            return commit.Hash;
        }

        public bool Checkout(Guid hash)
        {
            var commit = _history.FirstOrDefault(it => it.Hash == hash);
            if (commit is null)
                return false;
            _resource.Content = commit.Content;
            return true;
        }
    }
}
