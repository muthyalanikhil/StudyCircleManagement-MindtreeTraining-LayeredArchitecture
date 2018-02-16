using StudyCircleManagementSystem.DataAccess;
using StudyCircleManagementSystem.Entities;

namespace StudyCircleManagementSystem.BusinessLayer
{
    public class LoginManager
    {
        public StudyCircleManagementSystem.Web.Models.LoginDetail GetDetails(string userName)
        {
            LoginDAO loginData = new LoginDAO();
            var details = loginData.GetDetails(userName);
            return details;
        }
    }
}
