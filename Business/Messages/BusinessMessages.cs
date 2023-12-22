using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public class BusinessMessages
    {
        //-------------------USER---------------
        public static string NationalIdNumberCannotBeTheSame = "Your National Identity cannot be the same as another user";
        public static string EmailShouldBeUnique = "There is a registered membership with the e-mail address you entered.";
        public static string PhoneShouldBeUnique = "There is a registered membership with the phone number you entered.";
        public static string NationalIdMust11Count = "National identity number must be 11 digits. ";

        //-------------------STUDENT---------------
        public static string StudentNumberShouldBeUnique = "Unable to generate a unique student number.";

        //-------------------COURSE---------------

        public static string CertificateCanNotBeGivenDueToProgress = "Certificate is not ready, keep working!";

        public static string CourseOrExamNotFound = "Course or Exam can not be found!";




        //-------------------EXAM---------------
        public static string ValidateExamPoint = "Exam point should be between 0 and 100.";
        public static string CantGetRandomQuestionsByExamId = "Exam questions can not be found!";


        //------------------ASSIGNMENT----------------

        public static string DoNotSendItAfterTheAssignmentPeriodIsOver = "You cannot submit this assignment because it is overdue.";


        //------------------EDUCATIONINFORMATION-------------

        public static string TheBeginnerYearCannotBeGreaterThanTheGraduationYear = "The beginner year cannot be greater than the graduation year.";

        //-------------------USEREXPERİENCE---------------------------------
        public static string WorkBeginDateCannotBeGreatherThanWorkEndDate = "Job Start Date cannot be greater than Job End Date";
    }
}
