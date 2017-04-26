using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TabelaFipe.DAL.Interfaces;
using TabelaFipe.Interfaces;

namespace TabelaFipe.BLL.Base
{
    /// <summary>
    /// Cria uma instância da classe de logica de negocios conforme o tipo passado em T e acesso a dados conforme o tipo passado em TDAO
    /// </summary>
    /// <typeparam name="T">Tipo da ENTIDADE</typeparam>
    /// <typeparam name="TDAO">Tipo do ACESSO A DADOS (T seguido do sufixo DAO)</typeparam>
    public abstract class BaseBO<T, TDAO>
            where T : class, IBaseEntidade
            where TDAO : class, IBaseDAO<T>, new()
    {
        TDAO dao;

        public BaseBO()
        {
            dao = new TDAO();
        }

        protected virtual void Inserir(T entidade)
        {
            try
            {
                dao.Inserir(entidade);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected virtual void Editar(T entidade)
        {
            try
            {
                dao.Editar(entidade);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public virtual void Salvar(T entidade)
        {
            try
            {
                if (entidade.Id == 0)
                    Inserir(entidade);
                else
                    Editar(entidade);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T Encontrar(int id)
        {
            try
            {
                return dao.Encontrar(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual T Encontrar(Expression<Func<T, bool>> filtro)
        {
            try
            {
                return dao.Encontrar(filtro);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public virtual List<T> Listar()
        {
            try
            {
                return dao.Listar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual List<T> Listar(Expression<Func<T, bool>> filtro)
        {
            try
            {
                return dao.Listar(filtro);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void Remover(int id)
        {
            try
            {
                dao.Remover(id);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}