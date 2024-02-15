﻿namespace ChatApi.Entities
{
    public class Chat : EntityBase
    {
        public string? Name { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}