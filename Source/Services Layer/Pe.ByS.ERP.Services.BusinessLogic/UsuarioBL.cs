using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.CrossCutting.Aspects;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.Domain;
using Pe.ByS.ERP.Infrastructure.Persistence.Aspects;
using Pe.ByS.ERP.Infrastructure.Repository;
using Pe.ByS.ERP.Services.BusinessLogic.Inter;

namespace Pe.ByS.ERP.Services.BusinessLogic
{
    public class UsuarioBL : IUsuarioBL
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioBL()
        {
        }

        public UsuarioBL(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [TryCatch(ExceptionTypeExpected = typeof (Exception), RethrowException = true)]
        public Usuario Login(string username, string password)
        {
            return _usuarioRepository.Login(username, password);
        }

        [TryCatch(ExceptionTypeExpected = typeof (Exception), RethrowException = true)]
        public bool IsUserInRole(string username, string roleName)
        {
            return _usuarioRepository.IsUserInRole(username, roleName);
        }

        [TryCatch(ExceptionTypeExpected = typeof (Exception), RethrowException = true)]
        public Usuario Get(Expression<Func<Usuario, bool>> where)
        {
            return _usuarioRepository.FindOne(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof (Exception), RethrowException = true)]
        [CommitsOperation]
        public void Add(Usuario entity)
        {
            _usuarioRepository.Add(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof (Exception), RethrowException = true)]
        [CommitsOperation]
        public void Update(Usuario entity)
        {
            _usuarioRepository.Update(entity);
        }

        [TryCatch(ExceptionTypeExpected = typeof (Exception), RethrowException = true)]
        public Usuario GetById(int id)
        {
            return _usuarioRepository.FindOne(p => p.Id == id);
        }

        [TryCatch(ExceptionTypeExpected = typeof (Exception), RethrowException = true)]
        public int Count(Expression<Func<Usuario, bool>> where)
        {
            return _usuarioRepository.Count(where);
        }

        [TryCatch(ExceptionTypeExpected = typeof (Exception), RethrowException = true)]
        public IList<Usuario> GetAll(string sidx, string sord, int rows, int start, Expression<Func<Usuario, bool>> where)
        {
            return _usuarioRepository.FindAllPaging(sidx, sord, rows, start, @where);
        }

        [TryCatch(ExceptionTypeExpected = typeof (Exception), RethrowException = true)]
        public IQueryable<Usuario> GetAll(JQGridParameters<Usuario> parameters)
        {
            return _usuarioRepository.FindAllPaging(parameters);
        }
    }
}