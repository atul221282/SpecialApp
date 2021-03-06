﻿using System;
using SpecialApp.Context;
using SpecialApp.Entity;
using SpecialApp.Repository;
using SpecialApp.Repository.Repository.Specials;

namespace SpecialApp.UnitOfWork
{
    public class SpecialUOW : BaseUOW, ISpecialUOW
    {
        private readonly SpecialContext context;
        private ISpecialRepository _specialRepository;

        public SpecialUOW(SpecialContext context) : base(context)
        {
            this.context = context;
        }

        public ISpecialRepository SpecialRepository
            => _specialRepository = _specialRepository ?? new SpecialRepository(context);

    }
}