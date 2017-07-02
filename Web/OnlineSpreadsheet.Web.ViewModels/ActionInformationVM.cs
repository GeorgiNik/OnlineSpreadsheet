namespace OnlineSpreadsheet.Web.ViewModels
{
    public class ActionInformationVM
    {
        public ActionInformationVM()
        {
        }

        public int proposedProjects { get; set; }

        public int projectsStarted { get; set; }

        public int projectsOnHold { get; set; }

        public int completedProjects { get; set; }

        public int pendingCommunication { get; set; }
    }
}
