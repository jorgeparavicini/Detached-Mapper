﻿using Detached.Mappers.Model;
using Detached.Mappers.Model.Types.Class;
using System;

namespace Detached.Mappers.Annotations
{
    public interface IAnnotationHandler
    {
        public abstract void Apply(Attribute annotation, MapperOptions modelOptions, ClassTypeOptions typeOptions, ClassMemberOptions memberOptions);
    }
}