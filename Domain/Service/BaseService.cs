using Domain.Interfaces;
using Domain.Models;
using FluentValidation;

namespace Domain.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository) => _baseRepository = baseRepository;

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());

            _baseRepository.Insert(obj);

            return obj;
        }

        public IEnumerable<TEntity> GetAll() => _baseRepository.GetAll();

        public TEntity GetById(int id)
        {
            var entity = _baseRepository.GetById(id);

            if (entity == null)
                throw new Exception("Registro não encontrado no banco de dados!");

            return entity;
        }

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());

            _baseRepository.Update(obj);

            return obj;
        }
        public void Delete(int id) => _baseRepository.Delete(id);

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros inválidos!");

            validator.ValidateAndThrow(obj);
        }
    }
}
