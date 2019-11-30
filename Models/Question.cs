using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackExchangeApiViewer.Models
{
    public class Question
    {
        public List<string> tags { get; set; }
        public Owner owner { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public int? accepted_answer_id { get; set; }
        public int? closed_date { get; set; }
        public DateTime? CloseDate
        {
            get
            {
                try
                {
                    return FromUnixTime(int.Parse(closed_date.ToString()));
                }
                catch
                {
                    return null;
                }
            }
        }

        public string closed_reason { get; set; }
        public bool is_answered { get; set; }
        public int view_count { get; set; }
        public int answer_count { get; set; }
        public int score { get; set; }
        public int last_activity_date { get; set; }
        public DateTime LastActivityDate
        {
            get
            {
                return FromUnixTime(last_activity_date);
            }
        }
        public int creation_date { get; set; }

        public DateTime CreationDate
        {
            get
            {
                return FromUnixTime(creation_date);
            }
        }
        public int last_edit_date { get; set; }

        public DateTime LastEditDate
        {
            get
            {
                return FromUnixTime(last_edit_date);
            }
        }
        public int question_id { get; set; }



        public static DateTime FromUnixTime(long unixTime)
        {
            return epoch.AddSeconds(unixTime);
        }
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}