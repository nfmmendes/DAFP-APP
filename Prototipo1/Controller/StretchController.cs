﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Controller
{
    class StretchController: AbstractController<DbStretches, CustomSqlContext>
    {
        public override void setContext(CustomSqlContext context)
        {
            throw new NotImplementedException();
        }

        public override void Add(DbStretches item)
        {
            throw new NotImplementedException();
        }

        public override void Edit(DbStretches item, long IdItem)
        {
            throw new NotImplementedException();
        }

        public override void Delete(DbStretches item)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValidItem(DbStretches item)
        {
            throw new NotImplementedException();
        }
    }
}
