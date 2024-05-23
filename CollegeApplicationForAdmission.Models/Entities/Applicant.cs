using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public class Applicant
    {

        public Guid Id { get; set; }

        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public PersonalInformation PersonalInformation { get; set; }
        public EducationalBackground EducationalBackground { get; set; }
        public ParentGuardianInformation ParentGuardianInformation { get; set; }

        public string? ControlNo { get; set; }
        public DateTime DateRegistered { get; set; }
        public string? ExamTimeTaken { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string ApplicantStatus { get; set; }
        public string CourseName { get; set; }
        public bool IsExamined { get; set; } = false;
        public bool IsInterviewed { get; set; } = false;
        public int? ReadingRawScore { get; set; }

        public int? MathRawScore { get; set; }

        public int? ScienceRawScore { get; set; }

        public int? InterviewReading { get; set; }

        public int? InterviewCommunication { get; set; }

        public int? InterviewAnalytical { get; set; }

        public int? IntelligenceRawScore { get; set; }
        public double? GWA { get; set; }

        [NotMapped]
        public bool IsCompleted => GetStatus();

        bool GetStatus()
        {
            return PersonalInformation != null && EducationalBackground != null && ParentGuardianInformation != null;
        }
      
        public string? ReadingInterpretation()
        {
            if (ReadingRawScore.HasValue)
            {                
                string result = ReadingRawScore >= 0 && ReadingRawScore <= 31 ? "BA" : ReadingRawScore >= 32 && ReadingRawScore <= 49 ? "A" : "AA";               
                return result;
            }
            else
            {                
                return string.Empty;
            }
            
        }
        public double? ReadingEquivalent()
        {
            if (ReadingRawScore.HasValue)
            {
                // Calculate the reading equivalent score
                double result = (ReadingRawScore.Value / 55.0) * 35.0 + 60.0;

                // Return the result
                return result;
            }
            else
            {
                // If ReadingRawScore is null, return null
                return null;
            }
        }

        public string? MathInterpretation()
        {
            if (MathRawScore.HasValue)
            {
                string result = MathRawScore >= 0 && MathRawScore <= 26 ? "BA" : MathRawScore >= 27 && MathRawScore <= 39 ? "A" : "AA";
                return result;
            }
            else
            {
                return string.Empty;
            }

        }
        public double? MathEquivalent()
        {
            if (MathRawScore.HasValue)
            {
                // Calculate the reading equivalent score
                double result = (MathRawScore.Value / 50.0) * 35.0 + 60.0;

                // Return the result
                return result;
            }
            else
            {
                // If ReadingRawScore is null, return null
                return null;
            }
        }

        public string? ScienceInterpretation()
        {
            if (ScienceRawScore.HasValue)
            {
                string result = ScienceRawScore >= 0 && ScienceRawScore <= 31 ? "BA" : ScienceRawScore >= 32 && ScienceRawScore <= 49 ? "A" : "AA";
                return result;
            }
            else
            {
                return string.Empty;
            }

        }
        public double? ScienceEquivalent()
        {
            if (ScienceRawScore.HasValue)
            {
                // Calculate the reading equivalent score
                double result = (ScienceRawScore.Value / 55.0) * 35.0 + 60.0;

                // Return the result
                return result;
            }
            else
            {
                // If ReadingRawScore is null, return null
                return null;
            }
        }

        public string? IntelligenceInterpretation()
        {
            if (IntelligenceRawScore.HasValue)
            {
                string result = IntelligenceRawScore == null ? "" 
                    : IntelligenceRawScore >= 0 && IntelligenceRawScore <= 41 ? "Very Low"
                    : IntelligenceRawScore >= 42 && IntelligenceRawScore <= 47 ? "Low" 
                    : IntelligenceRawScore >= 48 && IntelligenceRawScore <= 55 ? "BA" 
                    : IntelligenceRawScore >= 56 && IntelligenceRawScore <= 64 ? "LA" 
                    : IntelligenceRawScore >= 65 && IntelligenceRawScore <= 74 ? "A" 
                    : IntelligenceRawScore >= 75 && IntelligenceRawScore <= 82 ? "HA" 
                    : IntelligenceRawScore >= 83 && IntelligenceRawScore <= 89 ? "AA" 
                    : IntelligenceRawScore >= 90 && IntelligenceRawScore <= 95 ? "H" 
                    : "VH";  
                return result;
            }
            else
            {
                return string.Empty;
            }

        }
        public double? IntelligenceEquivalent()
        {
            if (IntelligenceRawScore.HasValue)
            {
                // Calculate the reading equivalent score
                double result = (IntelligenceRawScore.Value / 135.0) * 35.0 + 60.0;

                // Return the result
                return result;
            }
            else
            {
                // If ReadingRawScore is null, return null
                return null;
            }
        }
        public double? TotalAchievement()
        {
            double? readingEquivalent = ReadingEquivalent();
            double? mathEquivalent = MathEquivalent();
            double? scienceEquivalent = ScienceEquivalent();

            if (readingEquivalent.HasValue && mathEquivalent.HasValue && scienceEquivalent.HasValue)
            {
                // Calculate the total equivalent score
                double result = (readingEquivalent.Value + mathEquivalent.Value + scienceEquivalent.Value) / 3;
                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        }

        public double? TotalAchievementIntelligence()
        {
            double? totalAchievement = TotalAchievement();
            double? intelligenceEquivalent = IntelligenceEquivalent();           

            if (totalAchievement.HasValue && intelligenceEquivalent.HasValue)
            {
                // Calculate the total equivalent score
                double result = (totalAchievement.Value + intelligenceEquivalent.Value) / 2.0;

                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        }
        public double? TotalRating()
        {
            double? totalAchievementIntelligence = TotalAchievementIntelligence();
           

            if (totalAchievementIntelligence.HasValue)
            {
                // Calculate the total equivalent score
                double result = (totalAchievementIntelligence.Value) *0.5;

                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        }

        public double? GWAPercentage()
        {        
            if (GWA.HasValue)
            {
                // Calculate the total equivalent score
                double result = GWA.Value * 0.20;

                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        }
        public double? InterViewTotal()
        {
            if(InterviewReading.HasValue && InterviewCommunication.HasValue && InterviewAnalytical.HasValue)
            {
                double result = (InterviewReading.Value + InterviewCommunication.Value + InterviewAnalytical.Value) / 3;
                return result;
            }
            else
            {
                return null;
            }
        }
        public double? InterviewReadingPercentage()
        {
            if (InterviewReading.HasValue)
            {
                // Calculate the total equivalent score
                double result = InterviewReading.Value * .10;

                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        }
        public double? InterviewCommunicationPercentage()
        {
            if (InterviewCommunication.HasValue)
            {
                // Calculate the total equivalent score
                double result = InterviewCommunication.Value * 0.10;

                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        }
        public double? InterviewAnalyticalPercentage()
        {
            if (InterviewAnalytical.HasValue)
            {
                // Calculate the total equivalent score
                double result = InterviewAnalytical.Value * 0.10;

                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        }
        public double? InterviewRCAPercentage()
        {
            double? interviewReadingPercentage = InterviewReadingPercentage();
            double? interviewCommunicationPercentage = InterviewCommunicationPercentage();
            double? interviewAnalyticalPercentage = InterviewAnalyticalPercentage();
            if (interviewReadingPercentage.HasValue && interviewCommunicationPercentage.HasValue && interviewAnalyticalPercentage.HasValue)
            {
                // Calculate the total equivalent score
                double result = interviewReadingPercentage.Value + interviewCommunicationPercentage.Value + interviewCommunicationPercentage.Value;

                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        }
        public double? InterviewTotalPercentage()
        {
            double? interviewRCAPercentage = InterviewRCAPercentage();
            double? gwaPercentage = GWAPercentage();
            if (interviewRCAPercentage.HasValue && gwaPercentage.HasValue)
            {
                // Calculate the total equivalent score
                double result = interviewRCAPercentage.Value + gwaPercentage.Value;
                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        }
        public double? ExamTotalRating()
        {
            double? totalRating = TotalRating();
            if (totalRating.HasValue)
            {
                // Calculate the total equivalent score
                double result = totalRating.Value;
                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        } 
        public double? InterviewTotalRating()
        {
            double? interviewTotalPercentage = InterviewTotalPercentage();
            if (interviewTotalPercentage.HasValue)
            {
                // Calculate the total equivalent score
                double result = interviewTotalPercentage.Value;
                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        } 
        public double? OverallTotalRating()
        {
            double? examTotalRating = ExamTotalRating();
            double? interviewTotalRating = InterviewTotalRating();
            if (examTotalRating.HasValue && interviewTotalRating.HasValue)
            {
                // Calculate the total equivalent score
                double result = examTotalRating.Value + interviewTotalRating.Value;
                // Return the result
                return result;
            }
            else
            {
                // If any of the equivalent scores are null, return null
                return null;
            }
        }
        public string? Remarks()
        {
            double? overallTotalRating = OverallTotalRating();
            if (overallTotalRating.HasValue)
            {
                string result = overallTotalRating.Value >= 75 ? "Passed" : "Failed";
                return result;
            }
            else
            {
                return string.Empty;
            }

        }
    }
}
