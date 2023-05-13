﻿namespace BeFit_API.Model
{
    public class Exercises
    {
        public Guid id { get; set; }
        public string bodyPart { get; set; } = string.Empty;
        public string equipment { get; set; } = string.Empty;
        public string gifUrl { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string target { get; set; } = string.Empty;
        public string plan { get; set; } = string.Empty;
    }
}
