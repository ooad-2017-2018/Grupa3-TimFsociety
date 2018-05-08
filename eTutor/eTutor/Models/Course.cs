using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTutor.Models
{
    class Course
    {
        private String category;
        private String name;
        private Double price;
        private String description;
        private List<TutoringSession> tutoringSessions = new List<TutoringSession>();

        public Course() { }
        public Course(String _category, String _name, Double _price, String _description)
        {
            this.category = _category;
            this.name = _name;
            this.price = _price;
            this.description = _description;
        }
        public String getName() { return name; }
        public String getCategory() { return category; }
        public Double getPrice() { return price; }
        public String getDescription() { return description; }
        public List<TutoringSession> getSessions() { return tutoringSessions; }

        public void setName(String _name) { this.name = _name; }
        public void setCategory(String _category) { this.category = _category; }
        public void setPrice(Double _price) { this.price = _price; }
        public void setDescription(String _description) { this.description = _description; }
        public void setSessions(List<TutoringSession> _sessions) { this.tutoringSessions = _sessions; }
        public void addSessions(TutoringSession _session) { this.tutoringSessions.Add(_session); }
    }
}
