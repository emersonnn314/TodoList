﻿namespace TodoList
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public bool IsDone { get; set; }

        public int Priority { get; set; }

        public TodoItem()
        {
            Id = Guid.NewGuid();
        }
    }
}
