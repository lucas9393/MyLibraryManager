using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Model
{
    public class Conference
    {
        public int ConferenceID { get; set; }

        [StringLength(50)]
        public string NameConference { get; set; }

        public ICollection<AuthorConference> AuthorConferences { get; set; } = new List<AuthorConference>();
    }
}
