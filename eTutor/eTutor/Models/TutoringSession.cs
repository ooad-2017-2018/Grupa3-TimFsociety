using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTutor.Models
{
    class TutoringSession
    {
        private DateTime dateTime;
        private String status;
        private Boolean confirmedStatus;

        public TutoringSession() { }
        public TutoringSession(DateTime _dateTime)
        {
            this.dateTime = _dateTime;
            this.status = "pending"; //pending- waiting for confirmation, free, full, upcoming, canceled - (by either party), held 
            this.confirmedStatus = false;
        }
        public TutoringSession(DateTime _dateTime, String _status, Boolean _confirmedStatus)
        {
            this.dateTime = _dateTime;
            this.status = _status;
            this.confirmedStatus = _confirmedStatus;
        }

        public DateTime GetDateTime() { return dateTime; }
        public String getStatus() { return status; }
        public Boolean getConfirmedStatus() { return confirmedStatus; }

        public void setDateTime(DateTime _dateTime) { this.dateTime = _dateTime; }
        public void setStatus(String _status) { this.status = _status; }
        public void setConfirmedStatus(Boolean _confirmedStatus) { this.confirmedStatus = _confirmedStatus; }
    }
}
