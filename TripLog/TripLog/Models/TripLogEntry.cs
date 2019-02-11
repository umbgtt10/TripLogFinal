﻿using System;

namespace TripLog.Models
{
    public class TripLogEntry
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }

        public TripLogEntry()
        {
            Title = string.Empty;
            Id = Guid.NewGuid().ToString();
            Notes = string.Empty;
        }

        public TripLogEntry(string title) : this()
        {
            Title = title;
        }
    }
}
