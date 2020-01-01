using System;

namespace TripLog.Models
{
    public class TripLogEntry: IEquatable<TripLogEntry>
    {
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is TripLogEntry))
            {
                return false;
            }

            var instance = (TripLogEntry)obj;

            return this.Equals(instance);
        }

        public bool Equals(TripLogEntry other)
        {
            var areTitlesEquals = (other.Title == null && Title == null) ||
                                  (other.Title != null && Title != null && other.Title.Equals(Title));

            var areNotesEquals = (other.Notes == null && Notes == null) ||
                                 (other.Notes != null && Notes != null && other.Notes.Equals(Notes));

            return areTitlesEquals &&
                  other.Latitude.Equals(Latitude) &&
                  other.Longitude.Equals(Longitude) &&
                  other.Date.Equals(Date) &&
                  other.Rating.Equals(Rating) &&
                  areNotesEquals;
        }

        public override int GetHashCode()
        {
            var hash = 2108858624 * (string.IsNullOrEmpty(Title) ? Title.GetHashCode() : 1);
            hash *= (string.IsNullOrEmpty(Notes) ? Notes.GetHashCode() : 1);
            hash *= Latitude != 0 ? Latitude.GetHashCode() : 1;
            hash *= Longitude != 0 ? Longitude.GetHashCode() : 1;
            hash *= Rating != 0 ? Rating.GetHashCode() : 1;
            hash *= Date.GetHashCode();

            return hash;
        }
    }
}

