﻿namespace Backend.Models.Entities
{
    public class Work
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public byte[] Data { get; set; }
    }
}
