﻿using Core3Layers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core3Layers.Core.Interfaces
{
    public interface IPersonRepository
    {
        void CreatePerson(Person person);
    }
}
