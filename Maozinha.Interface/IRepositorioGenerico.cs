using System.Collections.Generic;

namespace Maozinha.Interface
{
    public interface IRepositorioGenerico<T> where T : class
    {
        void Inserir(T entidade);

        void Alterar(T entidade);

        void Excluir(T entidade);

        List<T> ListarTodos();

        T SelecionarPorId(T entidade);
    }
}
