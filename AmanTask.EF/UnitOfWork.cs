﻿
using AmanTask.EF.Data;
using AmanTask.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanTask.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IBaseRepository<Employee> Employees { get; private set; }

        public IBaseRepository<Department> Departments { get; private set; }

        public IEmployeeRepository EmployeeRepositoru { get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;

            Employees = new BaseRepository<Employee>(_context);
            Departments = new BaseRepository<Department>(_context);
            EmployeeRepositoru = new EmployeeRepository(_context);

        }
        public int Complete()
        {
            return _context.SaveChanges();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
