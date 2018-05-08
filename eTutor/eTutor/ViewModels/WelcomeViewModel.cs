using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTutor.ViewModels
{
    class WelcomeViewModel
    {
        public static Models.User currentUser;
        public Models.DataModel data
        {
            get { return new Models.DataModel(); }
            set { this.data = value; }
        }

        public Models.DataModel getData() { return data; }
        public Models.User getCurrent() { return currentUser; }

        public void setCurrent(Models.User user) { currentUser = user; }
        public void addUser(Models.User user)
        {
            this.data.users.Add(user);
            currentUser = user;
        }
        public void addCourse(Models.Course course) { this.data.courses.Add(course); }

        public Boolean FindUser(String _username, String _password)
        {
            currentUser = data.users.Find(item => _username == item.getUsername() && _password == item.getPassword());
            if (currentUser != null) return true; 
            return false;
        }

        public Boolean FindByName(String _username)
        {
            currentUser = data.users.Find(item => _username == item.getUsername());
            if (currentUser != null) return true;
            return false;
        }

        //TO DO: add user to user list and set current user

    }
}
