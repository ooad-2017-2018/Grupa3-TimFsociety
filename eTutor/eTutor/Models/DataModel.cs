using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTutor.Models
{
    class DataModel
    {
        public List<User> users = new List<User>();
        public List<Course> courses = new List<Course>();
        

        public DataModel()
        {
            this.users.AddRange(
                new List<User>
                {
                    //username, mail, password, paypalmail, tip
                    new User("jons", "jons22@gmail.com", "password123", "jons22@gmail.com", "Tutor"),
                    new User("emmaSean", "emma.sean@gmail.com", "12031995", "emmet.sean@gmail.com", "Student"),
                    new User("godrikG", "gMan@hotmail.com", "aSWRD000", "gMan@Hotmail.com", "Tutor"),
                    new User("AlanDonaldWatson", "a.watson@yahoo.com", "12acd12", "a.watson@yahoo.com", "Tutor"),
                    new User("DianaPrince", "dianaprince@gmail.com", "tmas12451912", "dianaprince@gmail.com","Tutor"),
                    new User("123ed", "123ed.d@gmail.com", "666fdk", "jSparrow@yahoo.com", "Student")
                    
                }
                );

           

            DateTime date1 = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            TutoringSession tut1= new TutoringSession(date1, "free", false);
            DateTime date2 = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            TutoringSession tut2= new TutoringSession(date2, "free", false);
            DateTime date3 = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            TutoringSession tut3= new TutoringSession(date3, "free", false);
            DateTime date4 = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            TutoringSession tut4= new TutoringSession(date4, "free", false);

            Course cour1 = new Course("Computer Science", "MongoDB Basics", 150.00, "This course will provide an introduction to MongoDB, Compass (the MongoDB GUI), the MongoDB query language, and Atlas, MongoDB's hosted database as a service.");
            Course cour2 = new Course("Computer Science", "Introduction to the Internet of Things (IoT)", 200.00, "Gain an understanding of what the IoT is and the requirements to design your own IoT solutions. Start developing IoT ideas in your industry.");
            Course cour3 = new Course("Physics", "Plasma Physics: Introduction", 120.00, "Learn the basics of plasma, one of the fundamental states of matter, and the different types of models used to describe it, including fluid and kinetic.");
            Course cour4 = new Course("Physics", "Electricity and Magnetism: Magnetic Fields and Forces", 250.00, "Learn how charges create and move in magnetic fields and how to analyze simple DC circuits in this introductory-level physics course.");
            Course cour5 = new Course("Data Analysis & Statistics", "Data Science: R Basics", 180.00, "Build a foundation in R and learn how to wrangle, analyze, and visualize data. This course covers common programming commands, how to operate on vectors, and when to use advanced functions such as sorting.");

            cour1.addSessions(tut1);
            cour2.addSessions(tut2);
            cour2.addSessions(tut3);
            cour3.addSessions(tut1);
            cour3.addSessions(tut3);
            cour4.addSessions(tut4);
            cour5.addSessions(tut4);
            cour5.addSessions(tut1);
            cour5.addSessions(tut2);

            this.courses.AddRange(
                new List<Course> { cour1, cour2, cour3, cour4, cour5});
        }

        //delete user 
        public void deleteUser(String username)
        {
            User user = users.Find(item => item.getUsername() == username);
            users.Remove(user);
        }
        //delete course
        public void deleteCourse(String courseName)
        {
            Course course = courses.Find(item => item.getName() == courseName);
            courses.Remove(course);
        }

        //delete course from students list
        //add course to students list


    }
}
