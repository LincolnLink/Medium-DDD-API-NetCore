using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<User> where T : BaseEntity
    {
        //private MySqlContext context = new MySqlContext();

        private readonly MySqlContext _contexto;

        public BaseRepository(MySqlContext ctx)
        {
            _contexto = ctx;
        }

        public void Insert(User usuario)
        {
            _contexto.User.Add(usuario);
            _contexto.SaveChanges();
        }

        public void Update(User usuario)
        {
            _contexto.User.Update(usuario);
            _contexto.SaveChanges();
        }        

        public User Select(int id)
        {
            return _contexto.User.FirstOrDefault(u => u.Id == id);
        }

        public void Remove(int id)
        {
            var entity = _contexto.User.First(u => u.Id == id);

            if (entity != null)
            {
                _contexto.User.Remove(entity);
                _contexto.SaveChanges();
            }
        }

        public IList<User> SelectAll()
        {
            return _contexto.User.ToList();
        }
    }
}
