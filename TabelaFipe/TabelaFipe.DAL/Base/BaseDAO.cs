using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TabelaFipe.DAL.Context;
using TabelaFipe.DAL.Interfaces;
using TabelaFipe.Interfaces;

namespace TabelaFipe.DAL.Base
{
    /// <summary>
    /// Cria uma instância da classe de acesso a dados conforme o tipo passado em T
    /// </summary>
    /// <typeparam name="T">Tipo da ENTIDADE</typeparam>
    public abstract class BaseDAO<T> : IBaseDAO<T> where T : class, IBaseEntidade
    {
        public virtual List<T> Listar()
        {
            //Quando passa pela ultima chave mata o objeto, limpa a memoria
            using (var _context = new DataContext())
            {
                var dbSet = _context.Set<T>();

                return dbSet.ToList();
            }
        }

        public virtual List<T> Listar(Expression<Func<T, bool>> filtro)
        {
            //Quando passa pela ultima chave mata o objeto, limpa a memoria
            using (var _context = new DataContext())
            {
                var dbSet = _context.Set<T>();

                return dbSet.Where(filtro).ToList();
            }
        }

        public virtual T Encontrar(int id)
        {
            using (var _context = new DataContext())
            {
                var dbSet = _context.Set<T>();
                return dbSet.FirstOrDefault(x => x.Id == id);
            }
        }

        public virtual T Encontrar(Expression<Func<T, bool>> filtro)
        {
            using (var _context = new DataContext())
            {
                var dbSet = _context.Set<T>();
                return dbSet.FirstOrDefault(filtro);
            }
        }

        public virtual void Inserir(T entidade)
        {
            using (var _context = new DataContext())
            {
                var dbSet = _context.Set<T>();
                dbSet.Add(entidade);
                _context.SaveChanges();
            }
        }

        public virtual void Editar(T entidade)
        {
            using (var _context = new DataContext())
            {
                var dbSet = _context.Set<T>();
                dbSet.Attach(entidade);
                _context.Entry(entidade).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public virtual void Remover(int id)
        {
            using (var _context = new DataContext())
            {
                var entidade = Encontrar(id);

                var dbSet = _context.Set<T>();
                dbSet.Attach(entidade);
                dbSet.Remove(entidade);
                _context.SaveChanges();
            }
        }
    }

}
