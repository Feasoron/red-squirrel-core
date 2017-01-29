using System;
using System.Linq;
using RedSquirrel.Models;
using AutoMapper;
using ApplicationDbContext = RedSquirrel.Data.ApplicationDbContext;
using System.Collections.Generic;

namespace RedSquirrel.Services
{
    public class UnitService
    {
        
        private readonly ApplicationDbContext _context ;

        public UnitService(ApplicationDbContext mapper)
        {
            _context = mapper;
        }

        public List<Unit> GetAll()
        {
            try
            {
                var all =  _context.Units.ToList();
                
                return _context.Units.ToList().Select(unit => Mapper.Map<Unit>(unit)).ToList();
            }
            catch(Exception ex)
            {
                return new List<Unit>();
            }
        }

        public Unit GetById(Int32 id)
        {
            try
            {
                var unit = _context.Units.FirstOrDefault(u => u.Id == id);
                return Mapper.Map<Unit>(unit);
            }
            catch(Exception ex)
            {
                return null;
            }
        }


    }
}