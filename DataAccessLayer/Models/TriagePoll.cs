using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class TriagePoll
    {
        private int _PollID;

        private string _IsTriageAttended;

        private string _Alias;

        private int _TriageLevel;

        private string _TriageQuality;

        private string _Presentation;

        private string _Reason;

        private string _Comments;

        private DateTime _TriageDate;

        public int PollID
        {
            get
            {
                return _PollID;
            }

            set
            {
                _PollID = value;
            }
        }

        public string IsTriageAttended
        {
            get
            {
                return _IsTriageAttended;
            }

            set
            {
                _IsTriageAttended = value;
            }
        }

        public string Alias
        {
            get
            {
                return _Alias;
            }

            set
            {
                _Alias = value;
            }
        }

        public int TriageLevel
        {
            get
            {
                return _TriageLevel;
            }

            set
            {
                _TriageLevel = value;
            }
        }

        public string TriageQuality
        {
            get
            {
                return _TriageQuality;
            }

            set
            {
                _TriageQuality = value;
            }
        }

        public string Reason
        {
            get
            {
                return _Reason;
            }

            set
            {
                _Reason = value;
            }
        }

        public string Comments
        {
            get
            {
                return _Comments;
            }

            set
            {
                _Comments = value;
            }
        }

        public string Presentation
        {
            get
            {
                return _Presentation;
            }

            set
            {
                _Presentation = value;
            }
        }

        public DateTime TriageDate
        {
            get
            {
                return _TriageDate;
            }

            set
            {
                _TriageDate = value;
            }
        }
    }
}
