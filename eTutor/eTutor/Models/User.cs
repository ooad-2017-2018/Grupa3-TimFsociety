using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTutor.Models
{
    class User:BaseModel
    {
        private String name;
        private String username;
        private String email;
        private String password;
        private String paypalEmail;
        private String type;
        private List<Course> courses = new List<Course>();

        public User() {}
        public User(String _username, String _email, String _password, String _paypalEmail, String _type)
        {
            //this.name = _name;
            this.username = _username;
            this.email = _email;
            this.password = _password;
            this.paypalEmail = _paypalEmail;
            this.type = _type;
            courses = new List<Course>();
        }

        public String getName() { return name; }
        public String getUsername() { return username; }
        public String getEmail() { return email; }
        public String getPassword() { return password; }
        public String getPayPalEmail() { return paypalEmail; }
        public String getType() { return type; }
        public List<Course> GetCourses() { return courses; }

        public void setName(String _name) { this.name = _name; }
        public void setUsername(String _username) { this.username = _username; }
        public void setEmail(String _email) { this.email = _email; }
        public void setPayPalEmail(string _paypalEmail) { this.paypalEmail = _paypalEmail; }
        public void addCourse(Course _course) { this.courses.Add(_course); }
    }
}
