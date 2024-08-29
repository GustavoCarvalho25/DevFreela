﻿using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CompleteProject
{
    public class CompleteProjectCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public CompleteProjectCommand(int id)
        {
            Id = id;
        }
    }
}
