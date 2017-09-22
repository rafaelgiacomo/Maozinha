namespace Maozinha.Interface
{
    public interface IUnitOfWork
    {
        void Commit();

        void RollBack();

        void AbrirTransacao();

        void AbrirConexao();

        void FecharConexao();
    }
}
