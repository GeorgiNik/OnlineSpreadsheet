//namespace LibertyGlobalBP.Web.ViewModels.Exports
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel;
//    using System.Linq;

//    using AutoMapper;

//    using LibertyGlobalBP.Data.Models;
//    using LibertyGlobalBP.Web.Infrastructure;

//    public class ExcelExportVM : IMapFrom<SurveyResponse>, IHaveCustomMappings
//    {
//        [Export]
//        [DisplayName("ID")]
//        public string ID { get; set; }

//        [Export]
//        [DisplayName("Survey")]
//        public string SurveyName { get; set; }

//        [Export]
//        [DisplayName("Customer ID")]
//        public string Customer_ID { get; set; }

//        [Export]
//        [DisplayName("Business Line")]
//        public string BusinessLine { get; set; }

//        [Export]
//        [DisplayName("Touch point")]
//        public string TouchpointName { get; set; }

//        [Export]
//        [DisplayName("Country")]
//        public string CountryName { get; set; }

//        [Export]
//        [DisplayName("First Name")]
//        public string FirstName { get; set; }

//        [Export]
//        [DisplayName("Last Name")]
//        public string LastName { get; set; }

//        [Export]
//        [DisplayName("Email")]
//        public string Email { get; set; }

//        [Export]
//        [DisplayName("Phone number 1")]
//        public string Phone { get; set; }

//        [Export]
//        [DisplayName("Phone number 2")]
//        public string Phone2 { get; set; }

//        [Export]
//        [DisplayName("Phone number 3")]
//        public string Phone3 { get; set; }

//        [Export]
//        [DisplayName("Gender")]
//        public string Gender { get; set; }

//        [Export]
//        [DisplayName("Salulation")]
//        public string Salutation { get; set; }

//        [Export]
//        [DisplayName("Date of birth")]
//        public string DateOfBirth { get; set; }

//        [Export]
//        [DisplayName("City")]
//        public string City { get; set; }

//        [Export]
//        [DisplayName("Martial status")]
//        public string MaritalStatus { get; set; }

//        [Export]
//        [DisplayName("Occupation")]
//        public string Occupation { get; set; }

//        [Export]
//        [DisplayName("Email of Follow-up owner")]
//        public string EmailFollowupOwner { get; set; }

//        [Export]
//        [DisplayName("Email for escalation")]
//        public string EmailEscalation { get; set; }

//        [Export]
//        [DisplayName("Claims")]
//        public string Claims { get; set; }

//        [Export]
//        [DisplayName("Policy opened date")]
//        public string PolicyOpenedDate { get; set; }

//        [Export]
//        [DisplayName("Policy name")]
//        public string PolicyName { get; set; }

//        [Export]
//        [DisplayName("Policy number")]
//        public string PolicyNumber { get; set; }

//        [Export]
//        [DisplayName("Premium")]
//        public string Premium { get; set; }

//        [Export]
//        [DisplayName("Payment method")]
//        public string PaymentMethod { get; set; }

//        [Export]
//        [DisplayName("Payment frequency")]
//        public string PaymentFrequency { get; set; }

//        [Export]
//        [DisplayName("Sum assured main coverage")]
//        public string SumAssuredMainCoverage { get; set; }

//        [Export]
//        [DisplayName("Product code")]
//        public string ProductCode { get; set; }

//        [Export]
//        [DisplayName("Contract status")]
//        public string ContractStatus { get; set; }

//        [Export]
//        [DisplayName("Service owner")]
//        public string ServiceOwner { get; set; }

//        [Export]
//        [DisplayName("Transaction type")]
//        public string TransactionType { get; set; }

//        [Export]
//        [DisplayName("Channel out")]
//        public string ChannelOut { get; set; }

//        [DisplayName("Agent First name")]
//        public string AgentFirstName { get; set; }

//        [Export]
//        [DisplayName("Agent surname")]
//        public string AgentSurname { get; set; }

//        [Export]
//        [DisplayName("Agent with ING since")]
//        public string AgentWithIngSince { get; set; }

//        [Export]
//        [DisplayName("Agent ID")]
//        public string AgentID { get; set; }

//        [Export]
//        [DisplayName("Agency name")]
//        public string AgencyName { get; set; }

//        [DisplayName("Agency number")]
//        public string AgencyNumber { get; set; }

//        [Export]
//        [DisplayName("Agent phone 1")]
//        public string AgentPhone1 { get; set; }

//        [Export]
//        [DisplayName("Agent phone 2")]
//        public string AgentPhone2 { get; set; }

//        [Export]
//        [DisplayName("Unit ID")]
//        public string UnitID { get; set; }

//        [Export]
//        [DisplayName("Distribution channel")]
//        public string DistributionChannel { get; set; }

//        [Export]
//        [DisplayName("Region")]
//        public string Region { get; set; }

//        [Export]
//        [DisplayName("Region ID")]
//        public string RegionID { get; set; }

//        [Export]
//        [DisplayName("Business unit")]
//        public string BusinessUnit { get; set; }

//        [Export]
//        [DisplayName("Pension account amount")]
//        public string PensionAccountAmount { get; set; }

//        [Export]
//        [DisplayName("Visited medical center")]
//        public string VisitedMedicalCenter { get; set; }

//        [Export]
//        [DisplayName("Company Name")]
//        public string CompanyName { get; set; }

//        [Export]
//        [DisplayName("Agent date of birth")]
//        public string AgentDateOfBirth { get; set; }

//        [Export]
//        [DisplayName("Service date open-display")]
//        public string ServiceDateOpenDisplay { get; set; }

//        [Export]
//        [DisplayName("Status")]
//        public SurveyResponseStatus SurveyResponseStatus { get; set; }

//        [Export]
//        [DisplayName("NPS Question name")]
//        public string NpsQuestionName => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.NpsQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Title;

//        [Export]
//        [DisplayName("NPS Question text")]
//        public string NpsQuestionText
//           => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.NpsQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Description;

//        [Export]
//        [DisplayName("NPS answer")]
//        public string NpsAnswer
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.NpsQuestion)?.Answer;

//        [Export]
//        [DisplayName("Open-ended question name")]
//        public string OpenEndedQuestionName
//             => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.OpenEndedQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Title;

//        [Export]
//        [DisplayName("Open-ended question text")]
//        public string OpenEndedQuestionText
//             => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.OpenEndedQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Description;

//        [Export]
//        [DisplayName("Open-ended question answer")]
//        public string OpenEndedQuestionAnswer
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.OpenEndedQuestion)?.Answer;

//        [Export]
//        [DisplayName("Effort question name")]
//        public string EffortQuestionName
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.EffortQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Title;

//        [Export]
//        [DisplayName("Effort question text")]
//        public string EffortQuestionText
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.EffortQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Description;

//        [Export]
//        [DisplayName("Effort question answer")]
//        public string EffortQuestionAnswer
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.EffortQuestion)?.Answer;

//        [Export]
//        [DisplayName("Driver question name")]
//        public string DriverQuestionName
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.DriverQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Title;

//        [Export]
//        [DisplayName("Driver question text")]
//        public string DriverQuestionText
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.DriverQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Description;

//        [Export]
//        [DisplayName("Driver question answer")]
//        public string DriverQuestionAnswer
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.DriverQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(this.DriverQuestionAnswerPosition - 1)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question name")]
//        public string SatisfactionQuestionName
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Title;

//        [Export]
//        [DisplayName("Satisfaction question text")]
//        public string SatisfactionQuestionText
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Description;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 1 text")]
//        public string SatisfactionQeustionCriteriaText1
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(0)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 1 answer")]
//        public string SatisfactionQeustionCriteriaAnswer1 => this.SatisfationQuestionAnswersPossition?.ElementAtOrDefault(0);

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 2 text")]
//        public string SatisfactionQeustionCriteriaText2
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(1)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 2 answer")]
//        public string SatisfactionQeustionCriteriaAnswer2 => this.SatisfationQuestionAnswersPossition?.ElementAtOrDefault(1);

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 3 text")]
//        public string SatisfactionQeustionCriteriaText3
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(2)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 3 answer")]
//        public string SatisfactionQeustionCriteriaAnswer3 => this.SatisfationQuestionAnswersPossition?.ElementAtOrDefault(2);

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 4 text")]
//        public string SatisfactionQeustionCriteriaText4
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(3)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 4 answer")]
//        public string SatisfactionQeustionCriteriaAnswer4 => this.SatisfationQuestionAnswersPossition?.ElementAtOrDefault(3);

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 5 text")]
//        public string SatisfactionQeustionCriteriaText5
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(4)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 5 answer")]
//        public string SatisfactionQeustionCriteriaAnswer5 => this.SatisfationQuestionAnswersPossition?.ElementAtOrDefault(4);

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 6 text")]
//        public string SatisfactionQeustionCriteriaText6
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(5)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 6 answer")]
//        public string SatisfactionQeustionCriteriaAnswer6 => this.SatisfationQuestionAnswersPossition?.ElementAtOrDefault(5);

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 7 text")]
//        public string SatisfactionQeustionCriteriaText7
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(6)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 7 answer")]
//        public string SatisfactionQeustionCriteriaAnswer7 => this.SatisfationQuestionAnswersPossition?.ElementAtOrDefault(6);

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 8 text")]
//        public string SatisfactionQeustionCriteriaText8
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(7)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 8 answer")]
//        public string SatisfactionQeustionCriteriaAnswer8 => this.SatisfationQuestionAnswersPossition?.ElementAtOrDefault(7);

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 9 text")]
//        public string SatisfactionQeustionCriteriaText9
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(8)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 9 answer")]
//        public string SatisfactionQeustionCriteriaAnswer9 => this.SatisfationQuestionAnswersPossition?.ElementAtOrDefault(8);

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 10 text")]
//        public string SatisfactionQeustionCriteriaText10
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Answers?.ElementAtOrDefault(9)?.Name;

//        [Export]
//        [DisplayName("Satisfaction question: Criteria 10 answer")]
//        public string SatisfactionQeustionCriteriaAnswer10 => this.SatisfationQuestionAnswersPossition?.ElementAtOrDefault(9);

//        [Export]
//        [DisplayName("Additional comments question name")]
//        public string AdditionalCommentsQeustionName
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.DriverQuestion && !string.IsNullOrEmpty(x.AdditionalData))?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Title;

//        [Export]
//        [DisplayName("Additional comments question text")]
//        public string AdditionalCommentsQeustionText
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.DriverQuestion && !string.IsNullOrEmpty(x.AdditionalData))?
//            .QuestionBlock?.Question?.QuestionTranslations?.FirstOrDefault(x => x.LanguageID == this.LanguageID.Value)?.Description;

//        [Export]
//        [DisplayName("Additional comments question answer")]
//        public string AdditionalCommentsQuestionAnswer
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.DriverQuestion && !string.IsNullOrEmpty(x.AdditionalData))?.AdditionalData;

//        [Export]
//        [DisplayName("Task Creation Date")]
//        public DateTime? TaskCreationDate { get; set; }

//        [Export]
//        [DisplayName("Survey invitation sent date")]
//        public DateTime? SurveyInvitationSentDate { get; set; }

//        [Export]
//        [DisplayName("Unsubscribed customer")]
//        public string UnsubscribedCustomer { get; set; }

//        [Export]
//        [DisplayName("Reminder sent date")]
//        public DateTime? ReminderSentDate { get; set; }

//        [Export]
//        [DisplayName("Online questionnaire completion date")]
//        public DateTime? OnlineQeustionnaireCompletionDate { get; set; }

//        [Export]
//        [DisplayName("What are we doing well?")]
//        public string WhatAreWeDoingWell { get; set; }

//        [Export]
//        [DisplayName("What should we improve?")]
//        public string WhatShouldWeImprove { get; set; }

//        [Export]
//        [DisplayName("Additional comments")]
//        public string AdditionalComments { get; set; }

//        [Export]
//        [DisplayName("Feedback call interviewer")]
//        public string FeedbackCallInterviewer { get; set; }

//        [Export]
//        [DisplayName("Task completion date")]
//        public DateTime? TaskCompletionData { get; set; }

//        public int? LanguageID { get; set; }

//        public ICollection<SurveyResponseAnswer> SurveyResponseAnswers { get; set; }

//        public int DriverQuestionAnswerPosition
//            => int.Parse(this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.DriverQuestion)?.Answer);

//        public string[] SatisfationQuestionAnswersPossition
//            => this.SurveyResponseAnswers?.FirstOrDefault(x => x.QuestionBlock.Question.QuestionType == QuestionType.SatisfactionQuestion)
//            ?.Answer?.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

//        public void CreateMappings(IConfiguration configuration)
//        {
//            configuration.CreateMap<SurveyResponse, ExcelExportVM>("ExportConfig")
//                        .ForMember(x => x.ID, opt => opt.Ignore())
//                        .ForMember(x => x.LanguageID, opt => opt.MapFrom(x => x.LanguageID.HasValue ? x.LanguageID.Value : x.Survey.DefaultLanguageID.Value))
//                        .ForMember(x => x.SurveyName, opt => opt.MapFrom(x => x.Survey.Name))
//                        .ForMember(x => x.Customer_ID, opt => opt.MapFrom(x => x.Touchpoint.Customer.Name))
//                        .ForMember(x => x.BusinessLine, opt => opt.MapFrom(x => x.Touchpoint.BusinessLine.Name))
//                        .ForMember(x => x.TouchpointName, opt => opt.MapFrom(x => x.Touchpoint.TouchpointType.Name))
//                        .ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Touchpoint.Country.Name))
//                        .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.Touchpoint.FirstName))
//                        .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.Touchpoint.LastName))
//                        .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Touchpoint.Email))
//                        .ForMember(x => x.Phone, opt => opt.MapFrom(x => x.Touchpoint.Phone))
//                        .ForMember(x => x.Phone2, opt => opt.MapFrom(x => x.Touchpoint.Phone2))
//                        .ForMember(x => x.Phone3, opt => opt.MapFrom(x => x.Touchpoint.Phone3))
//                        .ForMember(x => x.Gender, opt => opt.MapFrom(x => x.Touchpoint.Gender))
//                        .ForMember(x => x.Salutation, opt => opt.MapFrom(x => x.Touchpoint.Salutation))
//                        .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.Touchpoint.DateOfBirth))
//                        .ForMember(x => x.City, opt => opt.MapFrom(x => x.Transaction.City))
//                        .ForMember(x => x.MaritalStatus, opt => opt.MapFrom(x => x.Transaction.MaritalStatus))
//                        .ForMember(x => x.Occupation, opt => opt.MapFrom(x => x.Transaction.Occupation))
//                        .ForMember(x => x.EmailFollowupOwner, opt => opt.MapFrom(x => x.Transaction.FollowupOwner))
//                        .ForMember(x => x.EmailEscalation, opt => opt.MapFrom(x => x.Transaction.EscalationOwner.Email))
//                        .ForMember(x => x.Claims, opt => opt.MapFrom(x => x.Transaction.Claims))
//                        .ForMember(x => x.PolicyOpenedDate, opt => opt.MapFrom(x => x.Transaction.PolicyOpenedDate))
//                        .ForMember(x => x.PolicyName, opt => opt.MapFrom(x => x.Transaction.PolicyName))
//                        .ForMember(x => x.PolicyNumber, opt => opt.MapFrom(x => x.Transaction.PolicyNumber))
//                        .ForMember(x => x.Premium, opt => opt.MapFrom(x => x.Transaction.Premium))
//                        .ForMember(x => x.PaymentMethod, opt => opt.MapFrom(x => x.Transaction.PaymentMethod))
//                        .ForMember(x => x.PaymentFrequency, opt => opt.MapFrom(x => x.Transaction.PaymentFrequency))
//                        .ForMember(x => x.SumAssuredMainCoverage, opt => opt.MapFrom(x => x.Transaction.SumAssuredMainCoverage))
//                        .ForMember(x => x.ProductCode, opt => opt.MapFrom(x => x.Transaction.ProductCode))
//                        .ForMember(x => x.ContractStatus, opt => opt.MapFrom(x => x.Transaction.ContractStatus))
//                        .ForMember(x => x.ServiceOwner, opt => opt.MapFrom(x => x.Transaction.ServiceOwner))
//                        .ForMember(x => x.TransactionType, opt => opt.MapFrom(x => x.Transaction.TransactionType))
//                        .ForMember(x => x.ChannelOut, opt => opt.MapFrom(x => x.Transaction.ChannelOut))
//                        .ForMember(x => x.AgentFirstName, opt => opt.MapFrom(x => x.Transaction.AgentFirstName))
//                        .ForMember(x => x.AgentSurname, opt => opt.MapFrom(x => x.Transaction.AgentSurname))
//                        .ForMember(x => x.AgentWithIngSince, opt => opt.MapFrom(x => x.Transaction.AgentWithIngSince))
//                        .ForMember(x => x.AgencyName, opt => opt.MapFrom(x => x.Transaction.AgencyName))
//                        .ForMember(x => x.AgencyNumber, opt => opt.MapFrom(x => x.Transaction.AgencyNumber))
//                        .ForMember(x => x.AgentID, opt => opt.MapFrom(x => x.Transaction.AgentID))
//                        .ForMember(x => x.AgentPhone1, opt => opt.MapFrom(x => x.Transaction.AgentPhone1))
//                        .ForMember(x => x.AgentPhone2, opt => opt.MapFrom(x => x.Transaction.AgentPhone2))
//                        .ForMember(x => x.UnitID, opt => opt.MapFrom(x => x.Transaction.UnitID))
//                        .ForMember(x => x.DistributionChannel, opt => opt.MapFrom(x => x.Transaction.DistributionChannel))
//                        .ForMember(x => x.Region, opt => opt.MapFrom(x => x.Transaction.Region))
//                        .ForMember(x => x.RegionID, opt => opt.MapFrom(x => x.Transaction.RegionID))
//                        .ForMember(x => x.BusinessUnit, opt => opt.MapFrom(x => x.Transaction.BusinessUnit))
//                        .ForMember(x => x.PensionAccountAmount, opt => opt.MapFrom(x => x.Transaction.PensionAccountAmount))
//                        .ForMember(x => x.VisitedMedicalCenter, opt => opt.MapFrom(x => x.Transaction.VisitedMedicalCenter))
//                        .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.Transaction.CompanyName))
//                        .ForMember(x => x.AgentDateOfBirth, opt => opt.MapFrom(x => x.Transaction.AgentDateOfBirth))
//                        .ForMember(x => x.UnsubscribedCustomer, opt => opt.MapFrom(x => (x.Touchpoint.EntityStatus == EntityStatus.Inactive || x.Touchpoint.Customer.EntityStatus == EntityStatus.Inactive) ? "Yes" : "No"))
//                        .ForMember(x => x.ServiceDateOpenDisplay, opt => opt.MapFrom(x => x.Transaction.ServiceDateOpenDisplay))
//                        .ForMember(x => x.TaskCreationDate, opt => opt.MapFrom(x => x.CreatedOn))
//                        .ForMember(x => x.SurveyInvitationSentDate, opt => opt.MapFrom(x => x.InvitationSentDate))
//                        .ForMember(x => x.FeedbackCallInterviewer, opt => opt.MapFrom(x => x.FeedbackCallInterviewer.Name))
//                        .ForMember(x => x.OnlineQeustionnaireCompletionDate, opt => opt.MapFrom(x => x.DateResponded))
//                        .ForMember(x => x.AdditionalComments, opt => opt.MapFrom(x => x.GlobalNeedsAnalysis))
//                        .ForMember(x => x.TaskCompletionData, opt => opt.MapFrom(x => x.EnteredCompleted));
//        }
//    }
//}