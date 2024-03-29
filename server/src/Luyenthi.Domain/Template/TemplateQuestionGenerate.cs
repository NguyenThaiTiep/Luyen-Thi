﻿using Luyenthi.Core.Enums;
using Luyenthi.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyenthi.Domain
{
    public class TemplateQuestionGenerate : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public virtual Guid TemplateQuestionSetId { get; set; }
        public double OrderNumber { get; set; }
        public virtual Guid? GradeId { get; set; }
        public virtual Guid? ChapterId { get; set; }
        public virtual Guid? UnitId { get; set; }
        public virtual Guid? LevelQuestionId { get; set; }
        public int NumberQuestion { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual LevelQuestion LevelQuestion { get; set; }
        public virtual TemplateQuestionSet TemplateQuestionSet { get; set; }
    }
}
