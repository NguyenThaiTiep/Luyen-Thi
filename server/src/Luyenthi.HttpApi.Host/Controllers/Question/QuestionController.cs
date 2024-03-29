﻿using AutoMapper;
using Luyenthi.Core;
using Luyenthi.Core.Dtos;
using Luyenthi.Core.Dtos.GoogleDoc;
using Luyenthi.Core.Enums;
using Luyenthi.Domain;
using Luyenthi.Services;
using Luyenthi.Services.GoolgeAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Luyenthi.HttpApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly FileService _fileService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly QuestionService _questionService;
        private readonly IMapper _mapper;
        public QuestionController(
            FileService fileService, 
            IWebHostEnvironment hostEnvironment,
            QuestionService questionService,
            IMapper mapper
            )
        {
            _fileService = fileService;
            _hostingEnvironment = hostEnvironment;
            _questionService = questionService;
            _mapper = mapper;
        }
        [HttpPost]
        public QuestionDto CreateQuestion(QuestionCreateDto questionCreate)
        {
            var question = _mapper.Map<Question>(questionCreate);
            question = _questionService.Create(question);
            return _mapper.Map<QuestionDto>(question);
        }
        [HttpGet("{questionId}")]
        public QuestionDto GetQuestion(Guid questionId)
        {
            var question = _questionService.GetQuestion(questionId);
            return _mapper.Map<QuestionDto>(question);
        }
        [HttpGet("{questionId}/matrix")]
        public QuestionMatrixDto GetQuestionMatrix(Guid questionId)
        {
            var question = _questionService.GetById(questionId);
            return _mapper.Map<QuestionMatrixDto>(question);
        }
        [HttpDelete("{id}")]
        public void DeleteQuestion (Guid id)
        {
            var question = _questionService.GetById(id);
            if(question == null)
            {
                throw new KeyNotFoundException("Không tìm thấy bản ghi");
            }
             _questionService.Remove(question);
            
        }
        [HttpPut("update-content")]
        public QuestionDto UpdateQuestionContent(QuestionUpdateContentDto questionUpdate)
        {
            var question = _questionService.GetQuestion(questionUpdate.Id);
            if (question == null)
            {
                throw new KeyNotFoundException("Không tìm thấy bản ghi");
            }
            question.Content =questionUpdate.Content;
            question.Solve = questionUpdate.Solve;
            question.Introduction = questionUpdate.Introduction;
            question.CorrectAnswer = questionUpdate.CorrectAnswer;
            question = _questionService.Update(question);
            return _mapper.Map<QuestionDto>(question);

        }
        [HttpPut("update-matrix")]
        public QuestionMatrixDto UpdateMatrixQuestion(QuestionMatrixDto questionUpdateMatrixDto)
        {
            var question = _questionService.GetQuestion(questionUpdateMatrixDto.Id);
            if (question == null)
            {
                throw new KeyNotFoundException("Không tìm thấy câu hỏi");
            }
            question.GradeId = questionUpdateMatrixDto.GradeId;
            question.SubjectId = questionUpdateMatrixDto.SubjectId;
            question.ChapterId = questionUpdateMatrixDto.ChapterId;
            question.UnitId = questionUpdateMatrixDto.UnitId;
            question.LevelId = questionUpdateMatrixDto.LevelId;
            question.TemplateQuestionId = questionUpdateMatrixDto.TemplateQuestionId;
            
            question = _questionService.Update(question);
            return _mapper.Map<QuestionMatrixDto>(question);

        }
        [HttpPut("add-to-bank/{id}")]
        public QuestionMatrixDto AddToBank(Guid id)
        {
            var question = _questionService.GetById(id);
            question.Status = QuestionStatus.Used;
            question = _questionService.Update(question);
            return _mapper.Map<QuestionMatrixDto>(question);

        }
        [HttpDelete("remove-from-bank/{id}")]
        public void RemoveFromBank(Guid id)
        {
            var question = _questionService.GetById(id);
            question.Status = QuestionStatus.Waiting;
            question = _questionService.Update(question);
        }
    }
}
