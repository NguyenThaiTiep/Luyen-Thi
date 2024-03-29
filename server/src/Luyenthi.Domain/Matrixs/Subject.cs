﻿using Luyenthi.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luyenthi.Domain
{
    public class Subject:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int OrderNumber { get; set; }
        public string BackgroundUrl { get; set; }
        public string AvatarUrl { get; set; }
        public virtual List<Grade> Grades { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<Document> Documents { get; set; }
        public virtual TemplateDocument TemplateDocument { get; set; }
        
        
    }
}
