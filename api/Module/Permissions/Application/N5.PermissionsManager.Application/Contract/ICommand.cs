﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.PermissionsManager.Application.Contract
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
