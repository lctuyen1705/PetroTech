using PetroTech.Data.Infa;
using PetroTech.Data.Repo;
using PetroTech.Model.Models;

namespace PetroTech.Service.Manager
{
    public interface ILogService
    {
        Log Create(Log error);

        void Save();
    }

    public class LogService : ILogService
    {
        private ILogRepository _logRepository;
        private IUnitOfWork _unitOfWork;

        public LogService(ILogRepository logRepository, IUnitOfWork unitOfWork)
        {
            this._logRepository = logRepository;
            this._unitOfWork = unitOfWork;
        }

        public Log Create(Log error)
        {
            return _logRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}