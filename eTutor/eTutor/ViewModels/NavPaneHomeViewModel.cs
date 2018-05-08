using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTutor.ViewModels
{
    class NavPaneHomeViewModel
    {
        public static Boolean isUserStudent()
        {
            if(new WelcomeViewModel().getCurrent().getType().Equals("Student")) return true;
            return false;
        }
    }
}
