using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class TriageContent
    {
        private int _MainContentId;

        private string _ContentHeading;

        private string _ContentDescription;

        private int _ContentGUID;

        private string _EmailId;

        private string _FileNameContentId;

        private string _BlobPath;

        private string _FileNameList;

        private int _SmeTopicsId;

        private int _ContentLevel;

        public int MainContentId
        {
            get
            {
                return _MainContentId;
            }

            set
            {
                _MainContentId = value;
            }
        }

        public string ContentHeading
        {
            get
            {
                return _ContentHeading;
            }

            set
            {
                _ContentHeading = value;
            }
        }

        public string ContentDescription
        {
            get
            {
                return _ContentDescription;
            }

            set
            {
                _ContentDescription = value;
            }
        }

        public int ContentGUID
        {
            get
            {
                return _ContentGUID;
            }

            set
            {
                _ContentGUID = value;
            }
        }

        public string EmailId
        {
            get
            {
                return _EmailId;
            }

            set
            {
                _EmailId = value;
            }
        }

        public string FileNameContentId
        {
            get
            {
                return _FileNameContentId;
            }

            set
            {
                _FileNameContentId = value;
            }
        }

        public string BlobPath
        {
            get
            {
                return _BlobPath;
            }

            set
            {
                _BlobPath = value;
            }
        }

        public string FileNameList
        {
            get
            {
                return _FileNameList;
            }

            set
            {
                _FileNameList = value;
            }
        }

        public int SmeTopicsId
        {
            get
            {
                return _SmeTopicsId;
            }

            set
            {
                _SmeTopicsId = value;
            }
        }

        public int ContentLevel
        {
            get
            {
                return _ContentLevel;
            }

            set
            {
                _ContentLevel = value;
            }
        }
    }
}
