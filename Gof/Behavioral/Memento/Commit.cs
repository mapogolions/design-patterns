using System;

namespace Gof.Behavioral.Memento
{
    public class Commit
    {
        public Guid Hash { get; }
        public string Description { get; }
        public DateTime Date { get; }
        public string Content { get; }

        public Commit(string description, string content)
        {
            Description = description;
            Hash = Guid.NewGuid();
            Date = DateTime.Now;
            Content = content;
        }

        public string Info(string format = "")
        {
            switch (format)
            {
                case "oneline":
                    return $"{Hash} {Description}";
                default:
                    return $"commit {Hash}\nDate: {Date}\n{Description}";
            }
        }
    }
}
