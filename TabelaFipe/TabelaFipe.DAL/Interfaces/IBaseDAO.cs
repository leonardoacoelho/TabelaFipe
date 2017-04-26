using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TabelaFipe.DAL.Interfaces
{
    public interface IBaseDAO<T>
    {
        List<T> Listar();

        List<T> Listar(Expression<Func<T, bool>> filtro);

        T Encontrar(int id);

        T Encontrar(Expression<Func<T, bool>> filtro);

        void Inserir(T entidade);

        void Editar(T entidade);

        void Remover(int id);
    }
}

