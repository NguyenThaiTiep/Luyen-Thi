﻿using Luyenthi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyenthi.Core.Dtos
{
    public class DocumentUpdateMatrixRequest
    {
        public Guid Id { get; set; }
        public Guid? GradeId { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? ChapterId { get; set; }
        public Guid? UnitId { get; set; }
        public Guid? TemplateQuestionId { get; set; }
        public Guid? LevelId { get; set; }
        public QuestionStatus? Status { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

    }
}
