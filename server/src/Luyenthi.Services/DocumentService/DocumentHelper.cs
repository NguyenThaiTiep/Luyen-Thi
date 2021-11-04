﻿using Luyenthi.Core.Dtos;
using Luyenthi.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace Luyenthi.Services
{
    public class DocumentHelper
    {
        public static string ConvertToUnSign(string inputStr)
        {
            var input = inputStr.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            return str2;
        }
        public static dynamic ParseDocumentImport()
        {
            // tạo ra form part document => trả về partDocument
            return null;
        }
        public static List<QuestionSet> MakeIndexQuestions(List<QuestionSet> questionSets)
        {
            int curentIndex = 1;
            foreach (QuestionSet questionSet in questionSets)
            {
                var startQuestionIndex = curentIndex;
                var endQuestionIndex = curentIndex;
                // var questionSet 
                foreach (Question question in questionSet.Questions)
                {
                    if (question.SubQuestions != null && question.SubQuestions.Count > 0)
                    {
                        // bộ câu hỏi
                        foreach (Question subQ in question.SubQuestions)
                        {
                            var contenQuestion = JsonConvert.SerializeObject(subQ.Introduction);
                            contenQuestion = Regex.Replace(contenQuestion, @"(#{index})", curentIndex.ToString());
                            subQ.Introduction = JsonConvert.DeserializeObject<List<ExpandoObject>>(contenQuestion);
                            curentIndex++;
                        }
                    }
                    else
                    {
                        //câu hỏi thường
                        var contenQuestion = JsonConvert.SerializeObject(question.Introduction);
                        contenQuestion = Regex.Replace(contenQuestion, @"(#{index})", curentIndex.ToString());
                        question.Introduction = JsonConvert.DeserializeObject<List<ExpandoObject>>(contenQuestion);
                        curentIndex++;
                    }
                }
            }
            return questionSets;
        }
        public static QuestionSet MakeIndexQuestionSet(QuestionSet questionSetInput)
        {
            var curentIndex = 1;
            var questionSet = questionSetInput;
            // var questionSet 
            foreach (Question question in questionSet.Questions)
            {
                if (question.SubQuestions != null && question.SubQuestions.Count > 0)
                {
                    // bộ câu hỏi
                    foreach (Question subQ in question.SubQuestions)
                    {
                        var contenQuestion = JsonConvert.SerializeObject(subQ.Introduction);
                        contenQuestion = Regex.Replace(contenQuestion, @"(#{index})", curentIndex.ToString());
                        subQ.Introduction = JsonConvert.DeserializeObject<List<ExpandoObject>>(contenQuestion);
                        curentIndex++;
                    }
                }
                else
                {
                    //câu hỏi thường
                    var contenQuestion = JsonConvert.SerializeObject(question.Introduction);
                    contenQuestion = Regex.Replace(contenQuestion, @"(#{index})", curentIndex.ToString());
                    question.Introduction = JsonConvert.DeserializeObject<List<ExpandoObject>>(contenQuestion);
                    curentIndex++;
                }
            }
            return questionSet;
        }
        public static int CountQuestions(List<QuestionSet> questionSets)
        {
            var count =(int)questionSets.SelectMany(qs => qs.Questions).Sum(i => i.NumberQuestion);
            return count;
        } 
        public static TimeAnalytic GetTimeAnalytic(UserHistoryAnalyticType type)
        {
            var StartTime = DateTime.UtcNow;
            var EndTime = DateTime.UtcNow;
            switch (type)
            {
                case UserHistoryAnalyticType.Today:
                    StartTime = DateTime.UtcNow.AddDays(-1).AddHours(1);
                    EndTime = DateTime.UtcNow;
                    break;
                case UserHistoryAnalyticType.InWeek:
                    StartTime = DateTime.UtcNow.AddDays(-6).Date;
                    break;
                case UserHistoryAnalyticType.InMonth:
                    StartTime = DateTime.UtcNow.AddMonths(-1).AddDays(1).Date;
                    break;
                case UserHistoryAnalyticType.InYear:
                    StartTime = DateTime.UtcNow.AddYears(-1).AddMonths(1).Date;
                    break;
            }

            return new TimeAnalytic
            {
                StartTime = StartTime,
                EndTime = EndTime
            };
        }
        public static string GetLabelAnalytic(UserHistoryAnalyticType type, int key, TimeZoneInfo timeZoneInfo)
        {
            var StartTime = DateTime.UtcNow;
            var EndTime = DateTime.UtcNow;
            var label = "";
            switch (type)
            {
                case UserHistoryAnalyticType.Today:
                    EndTime = DateTime.UtcNow.AddHours(-key);
                    EndTime = TimeZoneInfo.ConvertTimeFromUtc(EndTime, timeZoneInfo);
                    label = $"{EndTime.Hour}h";
                    break;
                case UserHistoryAnalyticType.InWeek:
                    StartTime = DateTime.UtcNow.AddDays(-key);
                    StartTime = TimeZoneInfo.ConvertTimeFromUtc(StartTime, timeZoneInfo);
                    label = StartTime.ToString("dd");
                    break;
                case UserHistoryAnalyticType.InMonth:
                    StartTime = DateTime.UtcNow.AddDays(-key);
                    StartTime = TimeZoneInfo.ConvertTimeFromUtc(StartTime, timeZoneInfo);
                    label = StartTime.ToString("dd");
                    break;
                case UserHistoryAnalyticType.InYear:
                    label = $"T{key}";
                    break;
            }
            return label;
        }

    }
}
