namespace CRMS.Blazor.ApplicationState
{
    public class AllState
    {

        //Scope Action
        public Action? Action { get; set; }

        //Show General Department
        public bool ShowGeneralDepartment { get; set; }
        public void GeneralDepartmentClicked()
        {
            ResetAllDepartments();
            ShowGeneralDepartment = true;
            Action?.Invoke();
        }

        //Faculty
        public bool ShowFaculty { get; set; }
        public void FacultyClicked() 
        {
            ResetAllDepartments();
            ShowFaculty = true;
            Action?.Invoke();
        }

        //Branch
        public bool ShowBranch { get; set; }
        public void BranchClicked() 
        {
            ResetAllDepartments();
            ShowBranch = true;
            Action?.Invoke();
        }

        //Country
        public bool ShowCountry { get; set; }
        public void CountryClicked()
        {
            ResetAllDepartments();
            ShowCountry = true;
            Action?.Invoke();
        }

        //City
        public bool ShowCity { get; set; }
        public void CityClicked()
        {
            ResetAllDepartments();
            ShowCity = true;
            Action?.Invoke();
        }

        //Town
        public bool ShowTown { get; set; }
        public void TownClicked()
        {
            ResetAllDepartments();
            ShowTown = true;
            Action?.Invoke();
        }

        //User
        public bool ShowUser { get; set; }
        public void UserClicked()
        {
            ResetAllDepartments();
            ShowUser = true;
            Action?.Invoke();
        }

        //Complaint
        public bool ShowComplaint { get; set; } = true;
        public void ComplaintClicked()
        {
            ResetAllDepartments();
            ShowComplaint = true;
            Action?.Invoke();
        }

        //Feedback
        public bool ShowFeedback { get; set; }
        public void FeedbackClicked()
        {
            ResetAllDepartments();
            ShowFeedback = true;
            Action?.Invoke();
        }

        //DataPending
        public bool ShowDataPending { get; set; }   
        public void DataPendingClicked()
        {
            ResetAllDepartments();
            ShowDataPending = true;
            Action?.Invoke();
        }

        //DataPendingType
        public bool ShowDataPendingType { get; set; }
        public void DataPendingTypeClicked()
        {
            ResetAllDepartments();
            ShowDataPendingType = true;
            Action?.Invoke();
        }

        //ComplaintComplete
        public bool ShowComplaintComplete { get; set; }
        public void ComplaintCompleteClicked()
        {
            ResetAllDepartments();
            ShowComplaintComplete = true;
            Action?.Invoke();
        }

        //ComplaintCompleteType
        public bool ShowComplaintCompleteType { get; set; }
        public void ComplaintCompleteTypeClicked()
        {
            ResetAllDepartments();
            ShowComplaintCompleteType = true;
            Action?.Invoke();
        }

        private void ResetAllDepartments()
        {
            ShowGeneralDepartment = false;
            ShowFaculty = false;
            ShowBranch = false;
            ShowCountry = false;
            ShowCity = false;
            ShowTown = false;
            ShowUser = false;
            ShowComplaint = false;
            ShowFeedback = false;
            ShowDataPending = false;
            ShowDataPendingType = false;
            ShowComplaintComplete = false;
            ShowComplaintCompleteType = false;  
        }
    }
}
