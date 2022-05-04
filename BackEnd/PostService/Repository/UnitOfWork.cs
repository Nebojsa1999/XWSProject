﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostService.Models;
using PostService.Repository.Core;

namespace PostService.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, dynamic> _repositories;
        private readonly ProjectContext _context;
        public IPostRepository Posts { get; set; }

        public UnitOfWork(ProjectContext context)
        {
            _context = context;
            Posts = new PostRepository(_context);


        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }
            string type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }
            Type repositoryType = typeof(BaseRepository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));

            return (IBaseRepository<TEntity>)_repositories[type];
        }
        public ProjectContext Context
        {
            get { return _context; }
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