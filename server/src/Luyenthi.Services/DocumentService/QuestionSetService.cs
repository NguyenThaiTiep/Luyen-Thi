﻿using Luyenthi.Domain;
using Luyenthi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyenthi.Services
{
    public class QuestionSetService
    {
        private readonly QuestionSetRepository _questionSetRepository;
        public QuestionSetService(
            QuestionSetRepository questionSetRepository
            )
        {
            _questionSetRepository = questionSetRepository;
        }
        public QuestionSet Create(QuestionSet questionSet)
        {
            _questionSetRepository.Add(questionSet);
            return questionSet;
        }
        public List<QuestionSet> CreateMany(List<QuestionSet> questionSets)
        {
            try
            {
                _questionSetRepository.AddRange(questionSets);
                return questionSets;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        public List<QuestionSet> GetByDocumentId(Guid DocumentId)
        {
            return _questionSetRepository.Find(questionSet => questionSet.DocumentId == DocumentId)
                                            .Include(qs => qs.Document)
                                            .Include(qs => qs.Questions)
                                            .ThenInclude(q => q.SubQuestions).ToList();
        }
    }
}
